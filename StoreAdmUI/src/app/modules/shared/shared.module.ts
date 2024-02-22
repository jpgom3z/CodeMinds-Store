import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MainLayout } from './layouts/main/main.layout';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { ProductsModule } from '@products/products.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ProductsPage } from '@products/pages/products/products.page';
import { AppComponent } from 'src/app/app.component';
import { OrdersPage } from '@orders/pages/orders/orders.page';
import { CategoryPage } from '@categories/pages/category/category.page';
import { FormsModule } from '@angular/forms';
import { CheckComponent } from './components/form-field/check/check.component';
import { InputComponent } from './components/form-field/input/input.component';
import { SelectComponent } from './components/form-field/select/select.component';
import { TextareaComponent } from './components/form-field/textarea/textarea.component';
import { RadioComponent } from './components/form-field/radio/radio.component';
import { ModalComponent } from './components/modal/modal/modal.component';
import { TableComponent } from './components/table/table.component';
import { PanelComponent} from './components/panel/panel.component';
import { SnackbarComponent } from './components/snackbar/snackbar/snackbar.component';
import { CustomFieldComponent } from './components/form-field/custom-field/custom-field.component';



@NgModule({
  declarations: [
    MainLayout,
    PanelComponent,
    InputComponent,
    SelectComponent,
    TextareaComponent,
    CheckComponent,
    RadioComponent,
    ModalComponent,
    TableComponent,
    SnackbarComponent,
    CustomFieldComponent,
    
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  exports: [
    PanelComponent,
    InputComponent,
    SelectComponent,
    TextareaComponent,
    CheckComponent,
    RadioComponent,
    ModalComponent,
    TableComponent,
    SnackbarComponent,
    CustomFieldComponent
  ]
})
export class SharedModule { }