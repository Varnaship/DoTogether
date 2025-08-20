import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProjectService } from '../project.service';
import { Project } from '../project';

@Component({
  selector: 'app-project-list',
  standalone: true,
  templateUrl: './project-list.html',
  styleUrls: ['./project-list.css'],
  imports: [CommonModule, RouterModule]
})
export class ProjectList implements OnInit {
  projects: Project[] = [];
  error: string | null = null;

  constructor(private projectService: ProjectService) {}

  ngOnInit() {
    this.projectService.getAll().subscribe({
      next: (projects) => this.projects = projects,
      error: () => this.error = 'Failed to load projects'
    });
  }
}