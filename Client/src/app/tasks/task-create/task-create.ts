import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../task.service';

@Component({
  selector: 'app-task-create',
  standalone: true,
  templateUrl: './task-create.html',
  styleUrls: ['./task-create.css'],
  imports: [CommonModule, FormsModule]
})
export class TaskCreate {
  error: string | null = null;
  model = { title: '', description: '', dueDate: null };
  projectId: string | null = null;

  constructor(
    private taskService: TaskService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    // Try to get projectId from query params or route params
    this.projectId = this.route.snapshot.queryParamMap.get('projectId') || this.route.snapshot.paramMap.get('projectId');
  }

  createTask() {
    this.error = null;
    if (!this.model.title) {
      this.error = 'Title is required.';
      return;
    }
    if (!this.projectId) {
      this.error = 'No project selected.';
      return;
    }
    const payload = {
      ...this.model,
      dueDate: this.model.dueDate ?? undefined,
      projectId: this.projectId
    };
    this.taskService.create(payload).subscribe({
      next: (task) => this.router.navigate(['/tasks', task.id]),
      error: () => this.error = 'Failed to create task'
    });
  }
}
