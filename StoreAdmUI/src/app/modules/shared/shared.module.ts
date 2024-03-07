import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MainLayout } from './layouts/main/main.layout';
import { FormsModule } from '@angular/forms';
import { ProductsModule } from '@products/products.module';



@NgModule({
  declarations: [
    MainLayout
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ProductsModule,
  ],
  exports: [
  ]
})
export class SharedModule { }