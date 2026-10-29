import { Component, inject, OnInit, signal } from '@angular/core';
import { Nav } from '../layout/nav/nav';
import { Router, RouterOutlet } from '@angular/router';
import { Toast } from '../core/services/toast';

@Component({
  imports: [Nav, RouterOutlet],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  private toastService = inject(Toast);
  protected router = inject(Router);
}
