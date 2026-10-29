import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../services/account-service';
import { Toast } from '../services/toast';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const toast = inject(Toast);

  if(accountService.currentUser()) return true;
  else {
    toast.error('You Shall not pass');
    return false;
  }

};
