import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ProjectService } from '../project.service';

@Component({
  selector: 'app-project-create',
  standalone: true,
  templateUrl: './project-create.html',
  styleUrls: ['./project-create.css'],
  imports: [CommonModule, FormsModule]
})
export class ProjectCreate {
  error: string | null = null;
  // Use a fixed WorkspaceId for all projects
  private readonly DEFAULT_WORKSPACE_ID = '00000000-0000-0000-0000-000000000001';
  model = { name: '', description: '', isPublic: true };

  constructor(private projectService: ProjectService, private router: Router) {}

  createProject() {
    this.error = null;
    if (!this.model.name) {
      this.error = 'Name is required.';
      return;
    }
    // Always send the hardcoded WorkspaceId
    const payload = { ...this.model, workspaceId: this.DEFAULT_WORKSPACE_ID };
    this.projectService.create(payload).subscribe({
      next: (project) => this.router.navigate(['/projects', project.id]),
      error: () => this.error = 'Failed to create project'
    });
  }
}