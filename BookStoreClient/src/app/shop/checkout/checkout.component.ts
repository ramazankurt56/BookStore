import { Component } from '@angular/core';
import { AddressModel } from '../../models/address.model';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../services/auth.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { PaymentModel } from '../../models/payment.model';
import { ProductModel } from '../../models/product.models';
import { HttpService } from '../../services/http.service';
import { OrderService } from '../../services/order.service';
import { Router } from '@angular/router';
interface CityDistrictMap {
  [city: string]: string[];
}
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.css'
})
export class CheckoutComponent {
  cities: string[] = ['İstanbul', 'Ankara'];
  cityDistricts: CityDistrictMap = {
    'İstanbul': ['Beşiktaş', 'Taksim'],
    'Ankara': ['Mamak', 'Kızılay']
  };
  [key: string]: any
  selectedCity: string = '';
  selectedDistrict: string = '';
  districts: string[] = [];
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  orderNote: string = "";
  telephone: string = "";
  postCode: string = "";
  addressField: string = "";
  addressName: string = ""
  address: AddressModel = new AddressModel()
  addressSet: AddressModel[] = []
  selectedName: string = ""
  cardNumber1: string = "5526"
  cardNumber2: string = "0800"
  cardNumber3: string = "0000"
  cardNumber4: string = "0006"
  expireMonthAndYear: string = "2025-05"
  cvc: string = ""
  shoppingCarts: ProductModel[] = []
  totalPrice: number = 0
  country: string = "Türkiye"
  request: PaymentModel = new PaymentModel();
  orderNumber:string=""
  constructor(private http: HttpService, private auth: AuthService,private router:Router, private shopping: ShoppingCartService,private order:OrderService) {
    shopping.getAllShoppingCarts()
    this.addressGetById();
    this.shopping.totalPrice$.subscribe(event => {
      this.totalPrice = event;
    })
    this.shopping.shoppingCartsTest$.subscribe(event => {
      this.shoppingCarts = event;
    })
  }
  updateDistricts(): void {
    this.districts = this.cityDistricts[this.selectedCity] || [];
  }
  gotoNextInputIf4Lenght(inputCount: string = "", value: string = "") {
    this[`cardNumber${inputCount}`] = value.replace(/[^0-9]/g, "");
    value = value.replace(/[^0-9]/g, "");
    if (value.length === 4) {
      if (inputCount === "4") {
        const el = document.getElementById("expireMonthAndYear")
        el?.focus();
      }
      else {
        const id: string = `cartNumber${+inputCount + 1}`
        const el: HTMLInputElement = document.getElementById(id) as HTMLInputElement;
        el.focus();
      }
    }
  }
  addressAdd() {
    this.address.name = this.firstName
    this.address.lastName = this.lastName
    this.address.city = this.selectedCity
    this.address.district = this.selectedDistrict
    this.address.email = this.email
    this.address.postCode = this.postCode
    this.address.telephone = this.telephone
    this.address.addressField = this.addressField
    this.address.orderNote = this.orderNote
    this.address.userId = this.auth.token.userId
    this.address.addressName = this.addressName
    this.http.post("Checkout/AddressAdd", this.address,(res)=>{})
  }
  addressGetById() {
    this.http.get("Checkout/AddressGetById/" + this.auth.token.userId,(res)=>{this.addressSet = res;})
  }
  addressSelected(name: string) {
    for (let i = 0; i < this.addressSet.length; i++) {
      if (this.addressSet[i].addressName === name) {
        this.addressName = this.addressSet[i].addressName
        this.firstName = this.addressSet[i].name
        this.lastName = this.addressSet[i].lastName
        this.selectedCity = this.addressSet[i].city

        this.updateDistricts()

        this.selectedDistrict = this.addressSet[i].district
        this.email = this.addressSet[i].email
        this.postCode = this.addressSet[i].postCode
        this.telephone = this.addressSet[i].telephone
        this.addressField = this.addressSet[i].addressField
        this.orderNote = this.addressSet[i].orderNote
      }

    }

  }
  payment() {
    this.request.books = this.shoppingCarts 
    this.request.paymentCard.expireMonth=this.expireMonthAndYear.substring(5);
    this.request.paymentCard.expireYear=this.expireMonthAndYear.substring(0,4);
    this.request.paymentCard.cardNumber=this.cardNumber1+this.cardNumber2+this.cardNumber3+this.cardNumber4
    this.request.buyer.registrationAddress=this.request.billingAddress.description
    this.request.buyer.city=this.request.billingAddress.city
    this.request.buyer.country=this.request.billingAddress.country
    this.request.userId=this.auth.token.userId
    this.shopping.payment(this.request, (res) => {
      this.shopping.getAllShoppingCarts();
      if(res.success===true){
        this.orderNumber=res.orderNumber
        this.order.getAll(res.orderNumber)
        console.log(res.orderNumber)
        this.router.navigateByUrl("order-received")
      }
    })
  }

}
