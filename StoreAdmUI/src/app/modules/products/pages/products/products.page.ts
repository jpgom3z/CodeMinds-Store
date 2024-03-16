import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from '@services/product/product.service';
import { Router } from '@angular/router';
import { Observable, bindCallback } from 'rxjs';
import { JsonPipe } from '@angular/common';
import { LayoutService } from '@services/layout/layout.service';


@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrl: '../../../shared/layouts/main/main.layout.css',
})
export class ProductsPage implements OnInit{
  public products: Product[];
  public noData: any;
  public response: Response;
  public results: any = [];

  constructor(
    private productService: ProductService,
    private router: Router,
    ){
      console.log('constructor ppage');
    }

  public ngOnInit(): void {
    console.log('On Init ProductPage')
    this.productService.list().subscribe((results) => {
      this.results = results;
      this.products = this.results.data;
      console.log(JSON.stringify(this.results));
      console.log('JSON Response =', JSON.stringify(results));
    });
  }

  public goToProduct(id: number): void {
    this.router.navigate(['product', id]);
  }
}