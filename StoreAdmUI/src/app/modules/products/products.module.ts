import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from 'src/app/app.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductsRoutingModule } from './products-routing.module';
import { RouterOutlet } from '@angular/router';
import { ProductsPage } from './pages/products/products.page';


@NgModule({
  declarations: [ProductsPage],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    HttpClientModule,
    RouterOutlet
  ]
})
export class ProductsModule { }
