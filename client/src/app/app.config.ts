import { lastValueFrom } from 'rxjs';
import {
  ApplicationConfig,
  inject,
  provideAppInitializer,
  provideBrowserGlobalErrorListeners,
} from '@angular/core';
import { provideRouter, withViewTransitions } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { InitService } from '../core/services/init-service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes, withViewTransitions()),
    provideHttpClient(),
    provideAppInitializer(async () => {
      const initService = inject(InitService);

      // หน่วงเวลา 500ms ให้เห็นหน้า Splash สวยๆ
      await new Promise((resolve) => setTimeout(resolve, 300));

      try {
        await initService.init(); // (หรือถ้า init() ไม่ใช่ Observable ก็เรียก initService.init() เฉยๆ)
      } finally {
        document.getElementById('initial-splash')?.remove();
      }
    }),
  ],
};
