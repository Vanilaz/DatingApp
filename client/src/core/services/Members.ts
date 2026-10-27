import { HttpClient } from '@angular/common/http';
import { inject, Service, signal } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { User } from '../../types/User';



@Service()
export class MemberService {
  private http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7010/api/members';

  members = signal<User[]>([]);
  isLoading = signal<boolean>(false);

  async loadMembers(){
    this.isLoading.set(true);
    try {
      const data = await lastValueFrom(this.http.get<User[]>(this.apiUrl));
      this.members.set(data);
    } catch (error) {
      console.error('โหลดข้อมูลสมาชิกไม่สำเร็จ', error);
    } finally {
      this.isLoading.set(false);
    }
  }

}
