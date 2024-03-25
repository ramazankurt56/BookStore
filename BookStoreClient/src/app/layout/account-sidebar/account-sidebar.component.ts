import { Component, ViewChild } from '@angular/core';
import { LoginModel } from '../../models/login.model';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CreateAccountModel } from '../../models/createAccount.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { HttpService } from '../../services/http.service';
@Component({
  selector: 'app-account-sidebar',
  templateUrl: './account-sidebar.component.html',
  styleUrl: './account-sidebar.component.css'
})
export class AccountSidebarComponent {
  @ViewChild('CloseBtn') CloseBtn: any;
  request: LoginModel = new LoginModel();
  account:CreateAccountModel=new CreateAccountModel()
  constructor(private http:HttpService ,private auth:AuthService, private shoppinCart:ShoppingCartService) {}
  signIn() {
    this.http.post("Auth/Login",this.request,(res)=>{
      localStorage.setItem("response", JSON.stringify(res))
      this.auth.checkAuthentication() 
      this.shoppinCart.getAllShoppingCarts();
      console.log(res)
      this.triggerButton2()
    });
  }
  triggerButton2() {
    this.CloseBtn.nativeElement.click();
  }
  createAccount() {
    if(this.account.confirmPassword===this.account.password){
    this.http.post("Auth/CreateAccount", this.account,(res)=>{
      window.location.reload();
    })
  }else{
    alert("Parolalar uyuşmuyor.")
  }
  }
}
