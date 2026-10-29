import { MembersDetailed } from './../features/members/members-detailed/members-detailed';
import { authGuard } from './../core/guards/auth-guard';
import { Routes } from '@angular/router';
import { Home } from '../features/home/home';
import { Lists } from '../features/lists/lists';
import { Messages } from '../features/messages/messages';

export const routes: Routes = [
  { path: '', component: Home },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {
        path: 'members',
        loadComponent: () =>
          import('../features/members/members-list/members-list').then((m) => m.MembersList),
      },
      {
        path: 'members/:id',
        loadComponent: () =>
          import('../features/members/members-detailed/members-detailed').then(
            (m) => m.MembersDetailed,
          ),
      },
      {
        path: 'lists',
        loadComponent: () => import('../features/lists/lists').then((m) => m.Lists),
      },
      {
        path: 'messages',
        loadComponent: () => import('../features/messages/messages').then((m) => m.Messages),
      },
    ],
  },
  { path: '**', component: Home },
];
