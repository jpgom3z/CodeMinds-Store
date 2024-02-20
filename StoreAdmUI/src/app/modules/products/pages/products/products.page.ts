import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MainLayout } from '@shared/layouts/main/main.layout';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [MainLayout],
  templateUrl: './products.page.html',
  styleUrl: '../../../shared/layouts/main/main.layout.css',
})
export class ProductsPage {

}
