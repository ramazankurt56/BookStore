import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { AuthService } from '../../services/auth.service';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-cart-sidebar',
  templateUrl: './cart-sidebar.component.html',
  styleUrl: './cart-sidebar.component.css'
})
export class CartSidebarComponent {
 @ViewChild('CloseBtn') CloseBtn: any;
totalPrice:number=0
shoppingCarts:any=[]
constructor(private shoppingCartSidebar:ShoppingCartService,private http:HttpService, private auth:AuthService ) {
  this.shoppingCartSidebar.totalPrice$.subscribe(event=>{
    this.totalPrice = event;
  })
  this.shoppingCartSidebar.shoppingCartsTest$.subscribe(event=>{
    this.shoppingCarts = event;
  })
}
triggerButton2() {
  this.CloseBtn.nativeElement.click();
}
removeProduct(product: number) {
  this.http.get("ShoppingCarts/RemoveById/"+product,(res)=>{
    this.shoppingCartSidebar.getAllShoppingCarts()
  })
}
}
