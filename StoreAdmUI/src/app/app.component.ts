import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { LayoutService } from './services/layout/layout.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor (
    private layoutService: LayoutService
  ){}

  public ngOnInit(): void {
    this.layoutService.theme$.subscribe((theme) => {
      document.body.className = theme;
    })
  }
}
