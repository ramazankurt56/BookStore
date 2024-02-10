import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { TokenModel } from '../models/token.model';
import { BehaviorSubject } from 'rxjs';
import { SetShoppingCartsModel } from '../models/set-shopping-carts.model';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: TokenModel = new TokenModel();
  tokenString: string = "";
  login:boolean=false
  userId:number=0
  constructor() {this.checkLogin() ,this.checkAuthentication() }

  checkAuthentication() {
    const responseString = localStorage.getItem("response");
    if (!responseString) {
      return this.redirectToLogin();
    }
  
    const responseJson = JSON.parse(responseString);
    this.tokenString = responseJson?.accessToken;
    if (!this.tokenString) {
      return this.redirectToLogin();
    }
    this.login=true
    const decode:any = jwtDecode(this.tokenString);
    this.token.email = decode?.Email;
    this.token.name = decode?.Name;
    this.token.userId = decode?.UserId;
    this.token.exp = decode?.exp;
    this.userId=decode?.UserId;
    //window.location.reload();
    return true;
  }
  // checkAuthenticationShop2() {
  //   const responseString = localStorage.getItem("response");
  //   if (!responseString) {
  //     return this.redirectToLogin();
  //   }
  
  //   const responseJson = JSON.parse(responseString);
  //   this.tokenString = responseJson?.accessToken;
  //   if (!this.tokenString) {
  //     return this.redirectToLogin();
  //   }
  //   this.login=true
  //   const decode:any = jwtDecode(this.tokenString);
  //   this.token.email = decode?.Email;
  //   this.token.name = decode?.Name;
  //   this.token.userId = decode?.UserId;
  //   this.token.exp = decode?.exp;
  //   return true;
  // }

  checkLogin(){
    const responseString = localStorage.getItem("response");
    if(responseString){
    this.login=true
    }else 
    {
      this.login=false
    }
  }
  redirectToLogin() {
   
    return false;
  }
}
