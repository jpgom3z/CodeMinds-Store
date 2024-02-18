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


  public  ngOnInit(): void {
    this.subscriptions.add(this.layoutService.themeSubject.subscribe((theme) => {
      this.theme = theme;
    }))
  }

  public ngOnDestroy(): void {
    /* Al destruir el componente mandamos a llamar la cancelación del objeto de suscripción
    lo que causa que todas las suscripciones agregadas se desuscriban */
    this.subscriptions.unsubscribe();
  }

  public changeTheme(): void {
    /* Con esta función mandamos a cambiar el valor del BehaviorSubject de tema activo
    el cual notificará a todos sus suscriptores del nuevo cambio */
    this.layoutService.themeSubject.next(this.themes[this.theme]);
  }

}
