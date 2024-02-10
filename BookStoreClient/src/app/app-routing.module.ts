import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './others/about/about.component';
import { AuthorsListComponent } from './others/authors-list/authors-list.component';
import { AuthorsSingleComponent } from './others/authors-single/authors-single.component';
import { ComingSoonComponent } from './others/coming-soon/coming-soon.component';
import { ContactComponent } from './others/contact/contact.component';
import { FaqComponent } from './others/faq/faq.component';
import { NotFoundComponent } from './others/not-found/not-found.component';
import { TermsConditionsComponent } from './others/terms-conditions/terms-conditions.component';
import { CartComponent } from './shop/cart/cart.component';
import { MyAccountComponent } from './shop/my-account/my-account.component';
import { OrderReceivedComponent } from './shop/order-received/order-received.component';
import { OrderTrackingComponent } from './shop/order-tracking/order-tracking.component';
import { ShopListComponent } from './shop/shop-list/shop-list.component';
import { SingleProductComponent } from './shop/single-product/single-product.component';
import { StoreLocationComponent } from './shop/store-location/store-location.component';
import { CheckoutComponent } from './shop/checkout/checkout.component';

const routes: Routes = [
  {
    path: "",
    component: LayoutComponent,
    children: [
      {
        path: "",
        component: HomeComponent
      },
      {
        path: "about",
        component: AboutComponent
      },
      {
        path: "authors-list",
        component: AuthorsListComponent
      },
      {
        path: "authors-single",
        component: AuthorsSingleComponent
      },
      {
        path: "coming-soon",
        component: ComingSoonComponent
      },
      {
        path: "contact",
        component: ContactComponent
      },
      {
        path: "faq",
        component: FaqComponent
      },
      {
        path: "not-found",
        component: NotFoundComponent
      },
      {
        path: "term-conditions",
        component: TermsConditionsComponent
      },
      {
        path: "cart",
        component: CartComponent
      },
      {
        path: "checkout",
        component: CheckoutComponent
      },
      {
        path: "my-account",
        component: MyAccountComponent
      },
      {
        path: "order-received",
        component: OrderReceivedComponent
      },
      {
        path: "order-tracking",
        component: OrderTrackingComponent
      },
      {
        path: "shop-list",
        component: ShopListComponent
      },
      {
        path: "single-product",
        component: SingleProductComponent
      },
      {
        path: "store-location",
        component: StoreLocationComponent
      },
      
    ]
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
