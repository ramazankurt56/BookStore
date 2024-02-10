import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit } from '@angular/core';
import { ReviewModel } from '../../models/review.models';
import { ActivatedRoute } from '@angular/router';
import { ProductModel } from '../../models/product.models';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrl: './single-product.component.css'
})
export class SingleProductComponent implements OnInit {
  constructor(private http: HttpService,private shopping:ShoppingCartService,private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.productId = +params['id'];
      this.getAll()
      this.getById()
      this.getAllByIdReview()
    });
  }
  productId:number=0;
  scrollNav1: boolean = true
  scrollNav2: boolean = false
  scrollNav3: boolean = false
  navActive1: boolean = true
  navActive2: boolean = false
  navActive3: boolean = false
  product: any = []
  books: any = [];
  review: any = []
  fas: number = 0
  far: number = 0
  reviewAddModel: ReviewModel =new ReviewModel();
  star: number = 0;

  setStar(value: number): void {
    this.star = value;
  }
  scrollNavCheck(navCheck: number) {
    if (1 == navCheck) {
      this.scrollNav1 = true
      this.scrollNav2 = false
      this.scrollNav3 = false
      this.navActive1 = true
      this.navActive2 = false
      this.navActive3 = false

    } else if (2 == navCheck) {
      this.scrollNav1 = false
      this.scrollNav2 = true
      this.scrollNav3 = false
      this.navActive1 = false
      this.navActive2 = true
      this.navActive3 = false
    } else if (3 == navCheck) {
      this.scrollNav1 = false
      this.scrollNav2 = false
      this.scrollNav3 = true
      this.navActive1 = false
      this.navActive2 = false
      this.navActive3 = true
    }
  }
  getById() {
      this.http.get(`Books/GetById?Id=${this.productId}`,(res)=>{this.product=res})
  }

  getAll() {
    this.http.get(`Books/GetAll`,(res)=>{this.books=res})
  }
  getAllByIdReview() {
    this.http.get(`Reviews/GetById?Id=${this.productId}`,(res)=>{this.review = res})
  }
  reviewAdd() {
    this.reviewAddModel.bookId=this.productId
    this.reviewAddModel.rating=this.star
    this.http.post(`Reviews/Add`,this.reviewAddModel,(res)=>{window.location.reload()})
  }
  addShopping(product:ProductModel){
    this.shopping.addShoppingCart(product)
  }
}
