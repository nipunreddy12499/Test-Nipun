import { Component } from '@angular/core';
import { SummaryCardComponent } from '../summary-card.component'; 
import { ProjectService } from '../../services/project.service';
import { TicketService } from '../../services/ticket.service';
@Component({
  selector: 'app-summary-page',
  standalone: true,
  imports: [SummaryCardComponent],
  templateUrl: './summary-page.component.html',
  styleUrls: ['./summary-page.component.scss']
})
export class SummaryPageComponent {
  totalProjects = 0;
  totalTickets = 0;

  constructor(
    private projectService: ProjectService,
    private ticketService: TicketService
  ) {}

  ngOnInit(): void {
    this.projectService.getProjects().subscribe(projects => {
      this.totalProjects = projects.length;
    });

    this.ticketService.getTickets().subscribe(tickets => {
      this.totalTickets = tickets.length;
    });
  }
}
