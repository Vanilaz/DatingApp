import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { Member } from '../models/member.model';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7010/api/members';

  members = signal<Member[]>([]);
  isLoading = signal<boolean>(false);

  async loadMembers(){
    this.isLoading.set(true);
    try {
      const data = await lastValueFrom(this.http.get<Member[]>(this.apiUrl));
      this.members.set(data);
    } catch (error) {
      console.error('โหลดข้อมูลสมาชิกไม่สำเร็จ', error);
    } finally {
      this.isLoading.set(false);
    }
  }

}
