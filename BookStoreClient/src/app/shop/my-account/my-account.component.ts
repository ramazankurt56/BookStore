import { Component } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { HttpService } from '../../services/http.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrl: './my-account.component.css'
})
export class MyAccountComponent {
  orderList:any=[]
  addressList:any=[]
constructor(private http:HttpService,public auth:AuthService) {
}
getAllOrder(){
  this.http.get(`Orders/GetAll/`+this.auth.userId,(res) => { 
    this.orderList=res;
    })
  }
  getAllAddress(){
    this.http.get(`Checkout/AddressGetById/`+this.auth.userId,(res) => { 
      this.addressList=res;
      })
    }
    logout(){
      localStorage.removeItem("response");
      window.location.reload()
    }
}
