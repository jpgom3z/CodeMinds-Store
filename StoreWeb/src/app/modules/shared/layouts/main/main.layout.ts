import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LayoutService } from '../../../../services/layout/layout.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.layout.html',
  styleUrl: './main.layout.css'
})
export class MainLayout implements OnInit, OnDestroy {
  public theme: string;
  public themes: {[key: string]: string};
  private subscriptions: Subscription;

  constructor(
    private layoutService: LayoutService
  ) {
    this.theme = null;
    this.themes = {
      light: 'dark',
      dark: 'light'
    };

    this.subscriptions = new Subscription();
  }


  public ngOnInit(): void {
    this.subscriptions.add(this.layoutService.themeSubject.subscribe((theme) => {
      this.theme = theme;
    }))
  }

  public ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  public changeTheme(): void {
    this.layoutService.themeSubject.next(this.themes[this.theme]);
  }

}
