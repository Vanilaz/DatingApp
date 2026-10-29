import { HttpClient } from '@angular/common/http';
import { inject, Service, signal } from '@angular/core'; // <-- เปลี่ยนแค่ Inject เป็น inject (ตัวพิมพ์เล็ก)
import { LoginCreds, RegisterCreds, User } from '../../types/User';
import { tap } from 'rxjs';

@Service() // <-- ใน Angular 22 ใช้ตัวนี้ได้เลยถูกต้องแล้วครับ (เป็น root-provided อัตโนมัติ)
export class AccountService {
  private http = inject(HttpClient); // <-- ใช้ inject ตัวพิมพ์เล็ก
  currentUser = signal<User | null>(this.getUserFromStorage());
  baseUrl = 'https://localhost:7010/api/';
  
  private getUserFromStorage(): User | null {
    const userString = localStorage.getItem('user');
    if (!userString) return null;
    try {
      return JSON.parse(userString) as User;
    } catch {
      localStorage.removeItem('user');
      return null;
    }
  }
  register(creds: RegisterCreds) {
    return this.http.post<User>(this.baseUrl + 'Account/register', creds).pipe(
      tap((user) => {
        if (user) {
          this.setCurrentUser(user);
        }
      }),
    );
  }

  login(creds: LoginCreds) {
    return this.http.post<User>(this.baseUrl + 'Account/login', creds).pipe(
      tap((user) => {
        if (user) {
          this.setCurrentUser(user);
        }
      }),
    );
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
