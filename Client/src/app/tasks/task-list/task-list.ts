import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TaskService } from '../task.service';
import { Task } from '../task';

@Component({
  selector: 'app-task-list',
  standalone: true,
  templateUrl: './task-list.html',
  styleUrls: ['./task-list.css'],
  imports: [CommonModule, RouterModule]
})
export class TaskList implements OnInit {
  tasks: Task[] = [];
  error: string | null = null;

  constructor(private taskService: TaskService) {}

  ngOnInit() {
    this.taskService.getAll().subscribe({
      next: (tasks) => this.tasks = tasks,
      error: () => this.error = 'Failed to load tasks'
    });
  }
}