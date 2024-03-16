import { Component, OnInit } from '@angular/core';
import { LayoutService } from '@services/layout/layout.service';
import { ProductService } from '@services/product/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor (
    private layoutService: LayoutService,
    private productService: ProductService,
  ){
    console.log('constructor component');
  }

  public ngOnInit(): void {

    this.layoutService.theme$.subscribe((theme) => {
        document.body.className = theme;
    });
  }
}