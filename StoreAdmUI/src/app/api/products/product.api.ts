import { Injectable } from '@angular/core';
import { HttpService } from '@services/http/http.service';
import { APIResponse } from '@services/http/http.types';
import { Observable, map } from 'rxjs';
import { FilterProductDTO, InsertUpdateProductDTO } from './product.dto';
import { Product } from './product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductApi {
  private readonly _api: string;

  constructor(
    private httpService: HttpService
  ) {
    this._api = 'products';
  }

  public list(filter: FilterProductDTO): Observable<APIResponse<Product[]>> {
    return this.httpService.get(this._api, { params: filter })//.mapArrayResponse((item: object) => new Product(item));
  }

  public insert(data: Product): Observable<APIResponse<Product>> {
    return this.httpService.post(this._api, new InsertUpdateProductDTO(data))//.mapObjectResponse((item: object) => new Product(item));
  }

  public update(data: Product): Observable<APIResponse<Product>> {
    return this.httpService.put(`${this._api}/${data.id}`, new InsertUpdateProductDTO(data))//.mapObjectResponse((item: object) => new Product(item));;
  }

  public delete(id: number): Observable<APIResponse<Product>> {
    return this.httpService.delete(`${this._api}/${id}`)//.mapObjectResponse((item: object) => new Product(item));;
  }
}