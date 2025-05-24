import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService, User } from '../../services/user.service';
import { TicketService } from '../../services/ticket.service';

@Component({
  selector: 'app-user-list',
  standalone: true,
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  imports: [CommonModule]
})
export class UserListComponent implements OnInit {
  usersWithTickets: { name: string; tickets: string[] }[] = [];

  constructor(
    private userService: UserService,
    private ticketService: TicketService
  ) {}

  ngOnInit() {
    this.userService.getUsers().subscribe(users => {
      this.ticketService.getTickets().subscribe(tickets => {
        this.usersWithTickets = users.map(user => ({
          name: user.name,
          tickets: tickets
            .filter(t => t.userId === user.id)
            .map(t => t.description)
        }));
      });
    });
  }
}