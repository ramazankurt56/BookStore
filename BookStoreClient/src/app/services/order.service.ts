import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
orderList:any=[]
totalPrice:number=0
  constructor(private http:HttpService) { }
  getAll(orderNumber:string){
    this.http.get(`Orders/GetById/`+orderNumber, (res) => { 
      this.orderList=res;
       for (let i = 0; i < this.orderList.length; i++) {
        this.totalPrice += this.orderList[i].price
      }
    })
  }
}
