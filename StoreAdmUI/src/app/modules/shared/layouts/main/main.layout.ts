import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { LayoutService } from '@services/layout/layout.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './main.layout.html',
  styleUrl: './main.layout.css'
})
export class MainLayout implements OnInit, OnDestroy {
  public theme: string;
  public themes: { [key: string]: string};

  private subscriptions: Subscription;

  public constructor (
    private layoutService: LayoutService
  ){
    this.theme = null;
    this.themes = {
      light: 'dark',
      dark: 'light'
    };

    this.subscriptions = new Subscription();
  }

  public ngOnInit(): void {
    this.subscriptions.add(this.layoutService.theme$.subscribe((theme) => {
      this.theme = theme;
    }));
  }

  public ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  public changeTheme() {
    this.layoutService.theme$.next(this.themes[this.theme]);
  }
}
