import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MainLayout } from './layouts/main/main.layout';



@NgModule({
  declarations: [
    MainLayout
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class SharedModule { }
