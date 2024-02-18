import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {
  public themeSubject: BehaviorSubject<string>;

  constructor() {
    this.themeSubject = new BehaviorSubject('light');
   }
}
