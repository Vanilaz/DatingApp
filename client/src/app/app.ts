import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { MemberService } from '../services/Members.service';
import { Member } from '../models/member.model';

@Component({
  imports: [],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit {
  private http =inject(HttpClient);
  private memberService = inject(MemberService);

  protected readonly title = signal('Dating App');


  async ngOnInit() {
      await this.memberService.loadMembers();
  }

}
