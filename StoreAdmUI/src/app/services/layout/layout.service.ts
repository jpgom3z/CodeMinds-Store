import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {
  public theme$: BehaviorSubject<string>;

  constructor() {
    this.theme$ = new BehaviorSubject('light');
   }
}
