import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from '../project.service';

@Component({
  selector: 'app-project-edit',
  standalone: true,
  templateUrl: './project-edit.html',
  styleUrls: ['./project-edit.css'],
  imports: [CommonModule, FormsModule]
})
export class ProjectEdit implements OnInit {
  error: string | null = null;
  model = { name: '', description: '', isPublic: true };
  id: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private projectService: ProjectService,
    private router: Router
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id) {
      this.projectService.getById(this.id).subscribe({
        next: (project) => this.model = {
          name: project.name,
          description: typeof project.description === 'string' ? project.description : '',
          isPublic: project.isPublic
        },
        error: () => this.error = 'Project not found'
      });
    }
  }

  updateProject() {
    if (!this.id) return;
    this.projectService.update(this.id, this.model).subscribe({
      next: () => this.router.navigate(['/projects', this.id]),
      error: () => this.error = 'Failed to update project'
    });
  }
}