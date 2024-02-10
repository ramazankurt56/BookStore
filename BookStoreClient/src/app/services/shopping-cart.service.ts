import { Injectable} from '@angular/core';
import { ProductModel } from '../models/product.models';
import { addShoppingCartModel } from '../models/add-shopping-cart.model';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Subject } from 'rxjs';
import { PaymentModel } from '../models/payment.model';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  shoppingCarts: any[] = [];
  count: number = 0;
  private totalPrice = new Subject<number>();
  totalPrice$ = this.totalPrice.asObservable();
  private shoppingCartsTest = new BehaviorSubject<any>([]);
  shoppingCartsTest$ = this.shoppingCartsTest.pipe();
  constructor(private auth:AuthService ,private http:HttpService,private router: Router) {this.getAllShoppingCarts()}
 
  addShoppingCart(product: ProductModel) {
    if(localStorage.getItem("response")){
      
      const data:addShoppingCartModel=new addShoppingCartModel();
      data.userId=this.auth.token.userId;
      data.bookId=product.id;
      data.quantity=1;
      console.log(this.auth.token.userId)
      this.http.post("ShoppingCarts/Add/",data,(res)=>{ this.getAllShoppingCarts();})
     }
    }
  getAllShoppingCarts(){

    const shoppingCartString=localStorage.getItem("shoppingCarts");
    if (shoppingCartString) {
      const carts: string | null = localStorage.getItem("shoppingCarts")
      if (carts !== null) {
        this.shoppingCarts = JSON.parse(carts);
      }
    }
    else{
      this.shoppingCarts=[]
    }
    if(localStorage.getItem("response"))
    {
      this.http.get("ShoppingCarts/GetAll/"+this.auth.userId,(res)=>{
        this.shoppingCarts=res
        this.shoppingCartsTest.next(res)
        this.total()
      })
    }
  }


  total() {
    this.http.get("ShoppingCarts/TotalAmount/"+this.auth.token.userId,(res)=>{
      this.totalPrice.next(res);
    })
  }
  payment(data:PaymentModel,callBack:(res:any)=>void){
    this.http.post("ShoppingCarts/Payment",data,(res)=>{
      callBack(res)
    })
  }
}
