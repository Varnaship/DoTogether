import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ProjectService } from '../project.service';
import { Project } from '../project';
import { FormsModule } from '@angular/forms';
import { TaskService } from '../../tasks/task.service';

@Component({
  selector: 'app-project-details',
  standalone: true,
  templateUrl: './project-details.html',
  styleUrls: ['./project-details.css'],
  imports: [CommonModule, RouterModule, DatePipe, FormsModule]
})
export class ProjectDetails implements OnInit {
  project: Project | null = null;
  error: string | null = null;
  taskError: string | null = null;
  taskModel = { title: '', description: '' };

  constructor(
    private route: ActivatedRoute,
    private projectService: ProjectService,
    private taskService: TaskService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.projectService.getById(id).subscribe({
        next: (project) => this.project = project,
        error: () => this.error = 'Project not found'
      });
    } else {
      this.error = 'Invalid project ID';
    }
  }

  createTask() {
    this.taskError = null;
    if (!this.taskModel.title) {
      this.taskError = 'Title is required.';
      return;
    }
    if (!this.project) {
      this.taskError = 'Project not loaded.';
      return;
    }
    // Send projectId (or listId if needed) with the task
    const payload = {
      ...this.taskModel,
      projectId: this.project.id
    };
    this.taskService.create(payload).subscribe({
      next: () => {
        this.taskModel = { title: '', description: '' };
        // Optionally reload tasks or show success
      },
      error: () => this.taskError = 'Failed to create task'
    });
  }
}