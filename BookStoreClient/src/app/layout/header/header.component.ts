import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent  {
 searchBook:string=""
constructor(public auth:AuthService,public shop:ShoppingCartService,private router:Router) {
  
}
search(){
}
logout(){
  localStorage.removeItem("response");
  window.location.reload()
}
}
