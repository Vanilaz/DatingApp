import { Service, signal } from '@angular/core';

export interface ToastMessage {
  id: number;
  message: string;
  type: 'success' | 'error' | 'info' | 'warning';
}

@Service()
export class Toast {
  toasts = signal<ToastMessage[]>([]);
  private counter = 0;

  show(message: string, type: ToastMessage['type'] = 'info', duration = 3000) {
    const id = this.counter++;
    this.toasts.update((current) => [...current, { id, message, type }]);

    setTimeout(() => {
      this.remove(id);
    }, duration);
  }

  success(message: string) {
    this.show(message, 'success');
  }
  error(message: string) {
    this.show(message, 'error');
  }
  info(message: string) {
    this.show(message, 'info');
  }
  warning(message: string) {
    this.show(message, 'warning');
  }

  remove(id: number) {
    this.toasts.update((current) => current.filter((t) => t.id != id));
  }
}
