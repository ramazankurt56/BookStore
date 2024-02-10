
import { NotFoundComponent } from './others/not-found/not-found.component';
import { TermsConditionsComponent } from './others/terms-conditions/terms-conditions.component';
import { FaqComponent } from './others/faq/faq.component';
import { ContactComponent } from './others/contact/contact.component';
import { ComingSoonComponent } from './others/coming-soon/coming-soon.component';
import { AuthorsSingleComponent } from './others/authors-single/authors-single.component';
import { AuthorsListComponent } from './others/authors-list/authors-list.component';
import { AboutComponent } from './others/about/about.component'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './layout/header/header.component';
import { AccountSidebarComponent } from './layout/account-sidebar/account-sidebar.component';
import { CartSidebarComponent } from './layout/cart-sidebar/cart-sidebar.component';
import { CategoriesSidebarComponent } from './layout/categories-sidebar/categories-sidebar.component';
import { FooterComponent } from './layout/footer/footer.component';
import { CartComponent } from './shop/cart/cart.component';
import { CheckoutComponent } from './shop/checkout/checkout.component';
import { OrderReceivedComponent } from './shop/order-received/order-received.component';
import { OrderTrackingComponent } from './shop/order-tracking/order-tracking.component';
import { SingleProductComponent } from './shop/single-product/single-product.component';
import { ShopListComponent } from './shop/shop-list/shop-list.component';
import { StoreLocationComponent } from './shop/store-location/store-location.component';
import { AccountSidebarMobileComponent } from './layout/account-sidebar-mobile/account-sidebar-mobile.component';
import { MyAccountComponent } from './shop/my-account/my-account.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AuthorPipe } from './pipes/author.pipe';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HomeComponent,
    HeaderComponent,
    AccountSidebarComponent,
    CartSidebarComponent,
    CategoriesSidebarComponent,
    FooterComponent,
    CartComponent,
    CheckoutComponent,
    OrderReceivedComponent,
    OrderTrackingComponent,
    SingleProductComponent,
    ShopListComponent,
    StoreLocationComponent,
    AboutComponent,
    AuthorsListComponent,
    AuthorsSingleComponent,
    ComingSoonComponent,
    ContactComponent,
    FaqComponent,
    TermsConditionsComponent,
    NotFoundComponent,
    AccountSidebarMobileComponent,
    MyAccountComponent,
    AuthorPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
