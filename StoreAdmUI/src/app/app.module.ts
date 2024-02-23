import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ProductsPage } from '@products/pages/products/products.page';
import { ProductsModule } from '@products/products.module';
import { OrdersModule } from '@orders/orders.module';
import { CategoryModule } from '@categories/category.module';
import { MainLayout } from '@shared/layouts/main/main.layout';
import { SharedModule } from '@shared/shared.module';


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
