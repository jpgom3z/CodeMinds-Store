import { CommonModule } from '@angular/common';
import { APP_INITIALIZER, Component, Input, OnInit } from '@angular/core';
import { MainLayout } from '@shared/layouts/main/main.layout';
import { Product } from 'src/app/models/product';
import { ProductService } from '@services/product/product.service';


@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrl: '../../../shared/layouts/main/main.layout.css',
})
export class ProductsPage implements OnInit{
  public products: Product[];

  constructor(
    private productService: ProductService
    ){
    this.products = [];

  }
  public ngOnInit(): void {
    this.productService.list().subscribe((data) => {
      this.products = data;
      console.log(data);
    });
  }
}