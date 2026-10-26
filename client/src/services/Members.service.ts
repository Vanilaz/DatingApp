import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private http = inject(HttpClient);

  private readonly apiUrl = 'https://localhost:7010/api/members';

  async getMember() {
    try {
      return lastValueFrom(this.http.get(this.apiUrl));
    } catch (error) {
      console.log(error);
      throw error;
    }
  }
}
