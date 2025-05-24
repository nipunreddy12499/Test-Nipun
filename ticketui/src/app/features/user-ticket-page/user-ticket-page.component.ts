import { Component } from '@angular/core';
import { UserListComponent } from '../user-list/user-list.component';

@Component({
  selector: 'app-user-ticket-page',
  standalone: true,
  imports: [UserListComponent],
  templateUrl: './user-ticket-page.component.html',
  styleUrls: ['./user-ticket-page.component.scss']
})
export class UserTicketPageComponent {}
