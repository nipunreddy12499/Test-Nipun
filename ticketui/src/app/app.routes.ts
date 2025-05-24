import { Routes } from '@angular/router';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { SummaryPageComponent } from './features/summary-page/summary-page.component';
import { ProjectPageComponent } from './features/project-page/project-page.component';
import { UserTicketPageComponent } from './features/user-ticket-page/user-ticket-page.component';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'summary', component: SummaryPageComponent },
  { path: 'projects', component: ProjectPageComponent },
  { path: 'assigned-tickets', component: UserTicketPageComponent }
];
