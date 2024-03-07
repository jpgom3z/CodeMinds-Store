import { JsonPipe } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '@models/category';
import { Product } from '@models/product';
import { BehaviorSubject, Observable, catchError, throwError, of, retry } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public product$: Product | JsonPipe;

  constructor(
    private http: HttpClient
  ) {
    console.log('constructor productService');
  }

  public list(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7131/api/products', {
      observe: 'body',
      responseType: 'json',
    }).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse){
    if (error.error instanceof ErrorEvent){
      console.log(error.error.message)
    } else {
      console.log(error.status)
    }
    return throwError(
      console.log('Something is wrong'));
  }

  public get(id: number): Observable<any> {
    return this.http.get<any>('`https://localhost:7131/api/products/${id}`', {
      headers: {
        'Content-Type': 'application/json'
      },
      observe: 'body',     
      responseType: 'json',
    });
  }
}
