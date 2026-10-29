import { inject, Service } from '@angular/core';
import { AccountService } from './account-service';
import { MemberService } from './Members';
import { User } from '../../types/User';

@Service()
export class InitService {
  private accountService = inject(AccountService);
  private memberService = inject(MemberService);

  async init(): Promise<void> {
    const userString = localStorage.getItem('user');
    if (!userString) return;

    try {
      const user: User = JSON.parse(userString);
      this.accountService.currentUser.set(user);

      // ตัวอย่างงาน Async ที่ทำให้ InitService คุ้มค่าที่จะมีอยู่:
      // รอให้โหลดรายชื่อสมาชิกเสร็จก่อน ค่อยเปิดหน้าเว็บขึ้นมา
      await this.memberService.loadMembers();
    } catch (error) {
      console.error('Initialization failed:', error);
      localStorage.removeItem('user');
    }
  }
}
