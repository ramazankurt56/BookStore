import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../services/shopping-cart.service';
import { ProductModel } from '../models/product.models';
import { HttpService } from '../services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
constructor(private http:HttpService, private shopping:ShoppingCartService) {   }
  ngOnInit(): void {
    this.featured(),this.trending(),this.selected()
  }
date: Date = new Date();
featuredBooks: any = [];
trendingBooks: any = [];
selectedBooks: any = [];
featured() {
    this.http.get(`Home/Featured/`,(res)=>{this.featuredBooks = res;})
  }
  trending() {
    this.http.get(`Home/Trending/`,(res)=>{this.trendingBooks = res})
  }
  selected() {
    this.http.get(`Home/Selected/`,(res)=>{this.selectedBooks=res})
    
  }
  addShopping(product:ProductModel){
    this.shopping.addShoppingCart(product)
  }
}
