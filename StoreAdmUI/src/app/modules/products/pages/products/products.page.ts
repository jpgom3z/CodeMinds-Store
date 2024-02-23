import { CommonModule } from '@angular/common';
import { APP_INITIALIZER, Component, OnInit } from '@angular/core';
import { MainLayout } from '@shared/layouts/main/main.layout';
import { RouterOutlet } from '@angular/router';
import { AppModule } from 'src/app/app.module';
import { SharedModule } from '@shared/shared.module';
import { ProductsModule } from '@products/products.module';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from '@services/http/http.service';
import { Store } from 'src/app/app.store';
import { ProductApi } from 'src/app/api/products/product.api';
import { filter, firstValueFrom } from 'rxjs';
import { FilterProductDTO } from 'src/app/api/products/product.dto';
import { Product } from 'src/app/api/products/product.model';
import { APIResponse } from '@services/http/http.types';

@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrl: '../../../shared/layouts/main/main.layout.css',
})
export class ProductsPage  implements OnInit{
  public products: Product[];
  public filter: FilterProductDTO;
  public product: Product;
  public loading: boolean;

  public constructor (private productApi: ProductApi
  ){
    this.filter = new FilterProductDTO();
    this.loading = false;
  }

  public ngOnInit(): void {
    this.list();
  }

  public async list(): Promise<void> {
    if(!this.loading) {
      this.loading = true;
      this.products = [];

      const response = await firstValueFrom(this.productApi.list(this.filter));
      if(response.success) {
        this.products = response.data;
      }
    }
  }
}