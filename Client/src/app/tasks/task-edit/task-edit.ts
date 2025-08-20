import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../task.service';
import { Task } from '../task';

@Component({
  selector: 'app-task-edit',
  standalone: true,
  templateUrl: './task-edit.html',
  styleUrls: ['./task-edit.css'],
  imports: [CommonModule, FormsModule]
})
export class TaskEdit implements OnInit {
  model: Partial<Task> = {};
  error: string | null = null;
  id: string | null = null;

  constructor(private route: ActivatedRoute, private taskService: TaskService, private router: Router) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id) {
      this.taskService.getById(this.id).subscribe({
        next: (task) => this.model = task,
        error: () => this.error = 'Task not found'
      });
    }
  }

  updateTask() {
    if (this.id) {
      this.taskService.update(this.id, this.model).subscribe({
        next: () => this.router.navigate(['/tasks', this.id]),
        error: () => this.error = 'Failed to update task'
      });
    }
  }

}
