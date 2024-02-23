import { CommonModule } from '@angular/common';
import { APP_INITIALIZER, Component, Input, OnInit } from '@angular/core';
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
import { APIResponse, MessageType } from '@services/http/http.types';
import { Status } from 'src/app/api/state/status.model';
import { DateType, InputType } from '@shared/components/form-field/form-field.types';
import { ModalPosition, ModalSize } from '@shared/components/modal/modal/modal.types';
import { StatusApi } from 'src/app/api/state/status.api';

@Component({
  selector: 'app-products',
  templateUrl: './products.page.html',
  styleUrl: '../../../shared/layouts/main/main.layout.css',
})
export class ProductsPage  implements OnInit{
  public get modalTitle() {
    return this.product?.id ? 'Editar Producto' : 'Nuevo Producto';
  }

  public get confirmDelete(): boolean {
    return this.deleteId != null;
  }
  
  public products: Product[];
  public productState: Status[];
  public modalOpen: boolean;
  public panelOpen: boolean;
  public filter: FilterProductDTO;
  public product: Product;
  public loading: boolean;
  public saving: boolean;
  public deleteId: number;
  public messages: string[];

  public InputType = InputType;
  public DateType = DateType;
  public ModalSize = ModalSize;
  public ModalPosition = ModalPosition;

  constructor (
    private productApi: ProductApi,
    private StatusApi: StatusApi,
    private store: Store
  ){
    this.products = [],
    this.productState = [],
    this.modalOpen = false,
    this.panelOpen = false,
    this.product = null;
    this.filter = new FilterProductDTO();
    this.loading = false;
    this.messages = [];
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

      this.loading = false;
    }
  }

  public insertUpdate(data: any = null): void {
    this.product = new Product(data);
    this.modalOpen = true;
  }

  public async saveProduct(): Promise<void> {
    if(!this.saving) {
      this.saving = true;

      const isNew = this.product.id == null;
      const response = await firstValueFrom(isNew ? this.productApi.insert(this.product) : this.productApi.update(this.product));
      this.messages = []

      if(response.success) {
        if(isNew) {
          this.panelOpen = true;
          this.filter = new FilterProductDTO({name:response.data.name})
        }

        this.modalOpen = false;
        this.store.siteMessage = {type: MessageType.Success, text: response.messages[0]};
        this.list();
      }else {
        this.messages = response.messages;
      }

      this.saving = false;
      }
    }

  public async deleteProduct(): Promise<void> {
    if(!this.saving) {
      this.saving = true;

      const response = await firstValueFrom(this.productApi.delete(this.deleteId));
      if(response.success) {
        this.store.siteMessage = {type: MessageType.Success, text: response.messages[0]};
        this.list();
      }else if(response.messages.length > 0) {
        this.store.siteMessage = {type: MessageType.Warning, text: response.messages[0]};
      }

      this.saving = false;
      this.deleteId = null;
    }
  }

  public onModalClose(): void {
    this.product = null;
    this.messages = [];
  }
}