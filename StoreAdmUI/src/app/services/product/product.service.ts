import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private http: HttpClient
  ) { }

  public list(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7131/api/products', {
      headers: {
        'Content-Type': 'application/json',
      }
    });
  }
}
