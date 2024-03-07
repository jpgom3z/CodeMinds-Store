import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterOutlet } from '@angular/router';
import { ProductsPage } from './pages/products/products.page';
import { ProductsRoutingModule } from './products-routing.module';




@NgModule({
  declarations: [ProductsPage],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterOutlet,
    ProductsRoutingModule
  ]
})
export class ProductsModule { }
