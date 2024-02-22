import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, Data, NavigationEnd, Router, Event, NavigationStart, RouterEvent} from '@angular/router';
import { Message, MessageType } from '@services/http/http.types';
import { SnackbarType } from '@shared/components/snackbar/snackbar/snackbar.types';
import { filter, Observable } from 'rxjs';
import { Title } from '@angular/platform-browser';
import { Store } from './app.store';
import { LayoutService } from '@services/layout/layout.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public message$: Observable<Message>;

  constructor (
    private layoutService: LayoutService,
    private store: Store,
    private router: Router,
    private route: ActivatedRoute,
    private title: Title
  ){}

  public ngOnInit(): void {
    this.message$ = this.store.siteMessage$;

    this.store.siteTitle$.subscribe((title) => {
      this.title.setTitle(`${title ? title + ' | ' : ''} Store Web Administration`);
    });
    
    this.layoutService.theme$.subscribe((theme) => {
        document.body.className = theme;
      });

      this.router.events.pipe(
        filter((e): e is NavigationStart => e instanceof NavigationStart)
      ).subscribe((e: RouterEvent) => {
        switch(e.constructor){
          case NavigationEnd:
            const routeData = this.getRouteData();
            this.store.siteTitle = routeData.title;
          break;
        }
      });
    }

  public getSackbarType(type: MessageType): SnackbarType {
    switch(type) {
      case MessageType.Info:
        return SnackbarType.Info;
      case MessageType.Success:
        return SnackbarType.Success;
      case MessageType.Warning:
        return SnackbarType.Warning;
      case MessageType.Error:
        return SnackbarType.Danger;
      default:
        return SnackbarType.Neutral;
    }
  }

  public dismissMessage(): void {
    this.store.siteMessage = null;
  }

  private getRouteData(): Data {
    const data: Data = {};

    let route = this.route.snapshot.firstChild;
    while(route?.firstChild) {
      route = route.firstChild;
      Object.assign(data, route.data);
    }

    return data;
  }
}