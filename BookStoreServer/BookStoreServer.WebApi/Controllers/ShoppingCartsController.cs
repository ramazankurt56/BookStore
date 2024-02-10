using BookStoreServer.WebApi.Context;
using BookStoreServer.WebApi.DTOs;
using BookStoreServer.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Iyzipay.Model;
using BookStoreServer.WebApi.Options;
using Iyzipay.Request;
using BookStoreServer.WebApi.Enum;
using BookStoreServer.WebApi.Services;
using System;
using System.Globalization;

namespace BookStoreServer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IyzicoOptions _iyzicoOptions;

        public ShoppingCartsController(AppDbContext context, IOptions<IyzicoOptions> iyzicoOptions)
        {
            _context = context;
            _iyzicoOptions = iyzicoOptions.Value;
        }

        [HttpPost]
        public IActionResult Add(AddShoppingCartsDto request)
        {
            Book book = _context.Books.Find(request.BookId);
            if (book is null)
            {
                throw new Exception("Kitap bulunmadı!");
            }

            if (book.Quantity < request.Quantity)
            {
                throw new Exception("Kitap stokta kalmadı!");
            }
            ShoppingCart? cart =
              _context.ShoppingCarts
              .Where(p => p.BookId == request.BookId).Where(p => p.UserId == request.UserId)
              .FirstOrDefault();

            if (cart is not null)
            {
                if (cart.Quantity < book.Quantity)
                {
                    if (cart is not null)
                    {
                        cart.Quantity = cart.Quantity + request.Quantity;

                        _context.Update(cart);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                cart = new()
                {
                    BookId = request.BookId,
                    Quantity = 1,
                    UserId = request.UserId,
                };

                _context.Add(cart);
            }

            _context.SaveChanges();
            return NoContent();
        }


        [HttpGet("{id}")]
        public ActionResult TotalAmount(int id)
        {
            decimal Price = 0;
            List<ShoppingCart> carts = _context.ShoppingCarts.Where(p => p.UserId == id).ToList();
            foreach (var item in carts)
            {
                Book? books = _context.Books.Where(p => p.Id == item.BookId).FirstOrDefault();
                if (books is not null)
                {
                    Price += books.Price * item.Quantity;
                }
            }
            return Ok(Price);
        }

        [HttpGet("{id}")]
        public IActionResult RemoveById(int id)
        {
            var shoppingCart = _context.ShoppingCarts.Where(p => p.Id == id).FirstOrDefault();
            if (shoppingCart != null)
            {
                _context.Remove(shoppingCart);
                _context.SaveChanges();
            }

            return NoContent();
        }

        [HttpGet("{userId}")]
        public IActionResult GetAll(int userId)
        {
            ShoppingCart? cart = _context.ShoppingCarts.FirstOrDefault(p => p.UserId == userId);
            if (cart is not null)
            {
                List<ShoppingCartResponeDto> books = _context.ShoppingCarts.Where(p => p.UserId == userId).AsNoTracking().Include(p => p.Book).Select(s => new ShoppingCartResponeDto()
                {
                    Author = s.Book.Author,
                    CoverImageUrl = s.Book.CoverImageUrl,
                    CreateAt = s.Book.CreatedDate,
                    Id = s.Book.Id,
                    IsActive = s.Book.IsActive,
                    IsDeleted = s.Book.IsDeleted,
                    Price = s.Book.Price,
                    Quantity = s.Quantity,
                    Summary = s.Book.Summary,
                    Title = s.Book.Title,
                    ShoppingCartId = s.Id
                }).ToList();
                return Ok(books);
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult QuantityAdd(SetShoppingCartsDto request)
        {
            ShoppingCart? cart = _context.ShoppingCarts.FirstOrDefault(p => p.UserId == request.UserId && p.BookId == request.BookId);
            Book? book = _context.Books.Where(p => p.Id == request.BookId).FirstOrDefault();
            if (cart.Quantity < book.Quantity)
            {
                if (cart is not null)
                {
                    cart.Quantity = cart.Quantity + request.Quantity;

                    _context.Update(cart);
                    _context.SaveChanges();
                }
            }
            else
            {
                return NoContent();
            }

            return NoContent();

        }
        [HttpPost]
        public IActionResult QuantitySubtract(SetShoppingCartsDto request)
        {
            ShoppingCart? cart = _context.ShoppingCarts.FirstOrDefault(p => p.UserId == request.UserId && p.BookId == request.BookId);
            if (cart is not null)
            {
                cart.Quantity = cart.Quantity - request.Quantity;

                _context.Update(cart);
                _context.SaveChanges();
            }
            return NoContent();

        }

        //[HttpPost]
        //public IActionResult SetShoppingCartsFromLocalStorage(List<SetShoppingCartsDto> request)
        //{
        //    List<ShoppingCart> shoppingCarts = new();

        //    foreach (var item in request)
        //    {
        //        ShoppingCart shoppingCart = new()
        //        {
        //            BookId = item.BookId,
        //            UserId = item.UserId,
        //            Price = item.Price,
        //            Quantity = item.Quantity
        //        };

        //        shoppingCarts.Add(shoppingCart);
        //    }

        //    _context.AddRange(shoppingCarts);
        //    _context.SaveChanges();

        //    return NoContent();
        ////}
        [HttpPost]
        public async Task<IActionResult> Payment(PaymentDto requestDto)
        {
            foreach (var item in requestDto.Books)
            {
                Book checkBook = _context.Books.Find(item.Id);
                if (checkBook.Quantity < item.Quantity)
                {
                    throw new Exception($"{item.Title} Kitap stokta kalamdı");
                }
            }
            decimal total = 0;
            decimal commission = 0;//komisyon

            foreach (var book in requestDto.Books)
            {
                total += book.Price;
            }
            commission = total;
            //commission = total * 1.2m / 100;
            Currency currency = Currency.TRY;


            //Default configuration ile bağlantı bilgilerim
            Iyzipay.Options options = new();
            options.ApiKey = "sandbox-3D5dmlUDIpfpUsq5KDZAfqHbfmhXpX7H";
            options.SecretKey = "sandbox-STRKw6vW59dkE6RhrcU3fcjhatdudAsw";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = Guid.NewGuid().ToString();//Benzersiz Id verilmelidir.
            request.Price = total.ToString();//ödeme tutarı
            request.PaidPrice = commission.ToString();//komisyon + ödeme tutarı
            request.Currency = currency.ToString();//Para tipi
            request.Installment = 1;//Taksit seçeneği
            request.BasketId = Order.GetNewOrderNumber();//Sepet Id TNR2023000000001
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = requestDto.PaymentCard;
            request.PaymentCard = paymentCard;

            Buyer buyer = requestDto.Buyer;
            buyer.Id = Guid.NewGuid().ToString();
            request.Buyer = buyer;

            Iyzipay.Model.Address shippingAddress = requestDto.ShippingAddress;
            request.ShippingAddress = shippingAddress;

            Iyzipay.Model.Address billingAddress = requestDto.BillingAddress;
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var book in requestDto.Books)
            {
                BasketItem item = new BasketItem();
                item.Category1 = "Book";
                item.Category2 = "Book";
                item.Id = book.Id.ToString();
                item.Name = book.Title;
                item.ItemType = BasketItemType.PHYSICAL.ToString();
                item.Price = book.Price.ToString();
                basketItems.Add(item);
            }

            request.BasketItems = basketItems;

            Payment payment = Iyzipay.Model.Payment.Create(request, options);


            if (payment.Status == "success")
            {
                try
                {
                    string orderNumber = Order.GetNewOrderNumber();

                    List<Order> orders = new();
                    foreach (var book in requestDto.Books)
                    {
                        Book changeBookQuantity = _context.Books.FirstOrDefault(p => p.Id == book.Id);
                        changeBookQuantity.Quantity -= book.Quantity;
                        _context.Update(changeBookQuantity);

                        Order order = new()
                        {
                            OrderNumber = orderNumber,
                            BookId = book.Id,
                            Quantity = book.Quantity,
                            Price = book.Price,
                            PaymentDate = DateTime.UtcNow,
                            PaymentType = "Credit Cart",
                            PaymentNumber = payment.PaymentId,
                            CreatedAt = DateTime.UtcNow,
                            UserId = requestDto.UserId
                        };
                        orders.Add(order);
                    }

                    OrderStatus orderStatus = new()
                    {
                        OrderNumber = orderNumber,
                        Status = OrderStatusEnum.AwaitingApproval,
                        StatusDate = DateTime.UtcNow
                    };

                    _context.Orders.AddRange(orders);
                    _context.OrderStatuses.Add(orderStatus);

                    //eğer kullanıcı girişi yapıldıysa bu işlemi yap.

                    Models.User user = _context.Users.Find(requestDto.UserId);
                    if (user is not null)
                    {
                        var shoppingCarts = _context.ShoppingCarts.Where(p => p.UserId == requestDto.UserId).ToList();
                        _context.RemoveRange(shoppingCarts);
                    }

                    _context.SaveChanges();

                //    string response = await MailService.SendEmailAsync(requestDto.Buyer.Email, "Siparişiniz Alındı", $@"
                //<h1>Siparişiniz Alındı</h1>
                //<p>Sipariş numaranız: {orderNumber}</p>
                //<p>Ödeme numaranız: {payment.PaymentId}</p>
                //<p>Ödeme tutarınız: {payment.PaidPrice}</p>
                //<p>Ödeme tarihiniz: {DateTime.UtcNow}</p>
                //<p>Ödeme tipiniz: Kredi Kartı</p>
                //<p>Ödeme durumunuz: Onay bekliyor</p>");
                    
                    return Ok(new { orderNumber , success = true });

                }
                catch (Exception ex)
                {
                    //ödeme kırılım ayarı yapmamız lazım ki iyzico ödeme iadesi yapabilsin
                    CreateRefundRequest refundRequest = new CreateRefundRequest();
                    refundRequest.ConversationId = request.ConversationId;
                    refundRequest.Locale = Locale.TR.ToString();
                    refundRequest.PaymentTransactionId = "1";
                    refundRequest.Price = request.Price;
                    refundRequest.Ip = "85.34.78.112";
                    refundRequest.Currency = currency.ToString();

                    Refund refund = Refund.Create(refundRequest, options);

                    return BadRequest(new { Message = "İşlem sırasında bir hata aldık ve paranızı geri iade ettik. Lütfen daha sonra tekrar deneyin ya da müşteri temsilcisi ile iletişime geçin!" });
                }
               // return NoContent();

            }
            else
            {
                return BadRequest(new {message="İşlem başarısız"});
            }
        }
    }
}
