import { Component, Input, input, signal } from '@angular/core';
import { Register } from '../account/register/register';
import { User } from '../../types/User';

@Component({
  imports: [Register],
  selector: 'app-home',
  styleUrl: './home.css',
  templateUrl: './home.html',
})
export class Home {
  protected registerMode = signal(false);

  showRegister(value: boolean) {
    this.registerMode.set(value);
  }
}
