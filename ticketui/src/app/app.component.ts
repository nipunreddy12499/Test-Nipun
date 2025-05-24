import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { ProjectService, Project } from './services/project.service';
import { TicketService } from './services/ticket.service';

import { SummaryCardComponent } from './features/summary-card.component';
import { ProjectListComponent } from './features/project-list/project-list.component';
import { UserListComponent } from './features/user-list/user-list.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    DashboardComponent,
    ProjectListComponent,
    SummaryCardComponent,
    UserListComponent
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  projects: Project[] = [];
  totalTickets = 0;

  private projectService = inject(ProjectService);
  private ticketService = inject(TicketService);

  ngOnInit() {
    this.projectService.getProjects().subscribe(data => this.projects = data);
    this.ticketService.getTickets().subscribe(data => this.totalTickets = data.length);
  }
}
