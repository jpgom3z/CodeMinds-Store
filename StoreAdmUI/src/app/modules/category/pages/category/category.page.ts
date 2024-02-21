import { Component } from '@angular/core';
import { MainLayout } from '@shared/layouts/main/main.layout';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [MainLayout],
  templateUrl: './category.page.html',
  styleUrl: '../../../shared/layouts/main/main.layout.css'
})
export class CategoryPage {

}
