import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {
  public theme$: BehaviorSubject<string>;

  constructor() {
    this.theme$ = new BehaviorSubject('light');
    console.log('constructor layservice');
  }
}
