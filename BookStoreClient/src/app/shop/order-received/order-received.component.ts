  import { Component } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-order-received',
  templateUrl: './order-received.component.html',
  styleUrl: './order-received.component.css'
})
export class OrderReceivedComponent {

constructor(public orders:OrderService,public shop:ShoppingCartService,private http:HttpService) {
  
}
getAll() {
  //this.http.get(`Books/GetAll`, (res) => { this.author = res })
}
}
