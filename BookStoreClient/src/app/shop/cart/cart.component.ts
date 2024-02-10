import { Component } from '@angular/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { SetShoppingCartsModel } from '../../models/set-shopping-carts.model';
import { AuthService } from '../../services/auth.service';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent {
totalPrice:number=0
  constructor(public shopping: ShoppingCartService, private http: HttpService, private auth: AuthService) 
  { 
    this.shopping.getAllShoppingCarts()
    this.shopping.totalPrice$.subscribe(event=>{
      this.totalPrice = event;
    })
  }
  QuantityAdd(product: any) {
    const cart = new SetShoppingCartsModel();
    cart.bookId = product.id;
    cart.userId = this.auth.token.userId;
    cart.quantity = 1;
    this.http.post("ShoppingCarts/QuantityAdd/",cart,(res)=>{
      this.shopping.getAllShoppingCarts()
    })
  }
  quantitySubtract(product: any) {
    if(product.quantity>1){
    const cart = new SetShoppingCartsModel();
    cart.bookId = product.id;
    cart.userId = this.auth.token.userId;
    cart.quantity = 1;
    this.http.post("ShoppingCarts/QuantitySubtract/",cart,(res)=>{
      this.shopping.getAllShoppingCarts()
    })
      }
      else{
        this.removeProduct(product.shoppingCartId)
      }
  }
  removeProduct(product: number) {
    this.http.get("ShoppingCarts/RemoveById/"+product,(res)=>{
      this.shopping.getAllShoppingCarts()
    })
  }
}
