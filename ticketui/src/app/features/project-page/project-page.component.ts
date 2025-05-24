import { Component } from '@angular/core';
import { ProjectListComponent } from '../project-list/project-list.component';

@Component({
  selector: 'app-project-page',
  standalone: true,
  imports: [ProjectListComponent],
  templateUrl: './project-page.component.html',
  styleUrls: ['./project-page.component.scss']
})
export class ProjectPageComponent {}
