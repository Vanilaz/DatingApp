import { Component, inject, Inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { Toast } from '../../core/services/toast';

@Component({
  imports: [FormsModule, RouterLink, RouterLinkActive],
  selector: 'app-nav',
  styleUrl: './nav.css',
  templateUrl: './nav.html',
})
export class Nav {
  protected accountService = inject(AccountService);
  private toast = inject(Toast);
  private router = inject(Router);
  protected creds: any = {};

  login() {
    this.accountService.login(this.creds).subscribe({
      next: (result) => {
        this.router.navigateByUrl('/members');
        this.toast.success('Logged in successfully')
        this.creds = {};
      },
      error: (error) => {
        console.log(error.error);
        this.toast.error(error.error);
      }
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
