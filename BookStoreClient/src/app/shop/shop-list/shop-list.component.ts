import { Component, ElementRef, ViewChild } from '@angular/core';
import { RequestModel } from '../../models/request.model';
import { ShoppingCartService } from '../../services/shopping-cart.service';
import { ProductModel } from '../../models/product.models';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrl: './shop-list.component.css'
})
export class ShopListComponent {

  constructor(private http: HttpService, private shopping: ShoppingCartService) {
    this.getAll()
    this.getAllCategory()
    this.getAllAuthor()
  }
  response: any = []
  request: RequestModel = new RequestModel()
  pageNumbers: number[] = []
  books: any = []
  category: any = []
  author: any = []
  searchAuthor: string = ""
  authorName: string = ""
  filterSort: string = "default"
  searchBook: string = ""
  getAll(pageNumber = 1) {
    this.request.pageNumber = pageNumber
    this.request.search = this.searchBook
    this.http.post(`ShopList/GetAllShop`, this.request, (res) => {
      this.response = res
      this.setPageNumber();
    })
  }
  getAllCategory() {
    this.http.get(`ShopList/GetAllCategory`, (res) => {
      this.category = res
    })
  }
  getAllAuthor() {
    this.http.get(`ShopList/GetAllAuthor`, (res) => { this.author = res })
  }
  getAllFilter(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue === "default") {
      this.request.filter = "default"
      this.getAll()
    } else if (selectedValue === "price") {
      this.request.filter = "price"
      this.getAll()
    } else if (selectedValue === "price-desc") {
      this.request.filter = "price-desc"
      this.getAll()
    }
  }
  categoryReset() {
    this.request.categoryId = null
    this.getAll();
  }
  authorReset() {
    this.request.author = null
    this.getAll();
  }
  categoryFilter(categoryId: number) {
    this.request.categoryId = categoryId
    this.getAll()
  }
  authorFilter(authorName: string) {
    this.request.author = authorName
    this.getAll()
    this.request.author = null
  }
  pageSize(event: any) {
    const selectedValue = event.target.value;
    this.request.pageSize = selectedValue
    this.getAll()
  }
  setPageNumber() {
    this.pageNumbers = []
    for (let i = 0; i < this.response.totalPageCount; i++) {
      this.pageNumbers.push(i + 1)
    }
  }
  addShopping(product: ProductModel) {
    this.shopping.addShoppingCart(product)
  }
}
