import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../task.service';
import { CommentService } from '../comment.service';
import { Task } from '../task';
import { Comment } from '../comment';
import { map, catchError } from 'rxjs/operators';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-details',
  standalone: true,
  templateUrl: './task-details.html',
  styleUrls: ['./task-details.css'],
  imports: [CommonModule, FormsModule, DatePipe]
})
export class TaskDetails implements OnInit {
  task: Task | null = null;
  comments: Comment[] = [];
  newComment = '';
  error: string | null = null;
  id: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private taskService: TaskService,
    private commentService: CommentService
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    if (this.id) {
      this.taskService.getById(this.id).pipe(
        catchError(() => {
          this.error = 'Task not found';
          return [];
        })
      ).subscribe(task => this.task = task);

      this.loadComments();
    }
  }

  loadComments() {
    if (this.id) {
      this.commentService.getByTaskId(this.id).pipe(
        map(comments => comments.sort((a, b) => b.createdAt.localeCompare(a.createdAt))),
        catchError(() => {
          this.error = 'Failed to load comments';
          return [];
        })
      ).subscribe(comments => this.comments = comments);
    }
  }

  addComment() {
    if (this.id && this.newComment.trim()) {
      this.commentService.create({ taskId: this.id, content: this.newComment }).subscribe({
        next: () => {
          this.newComment = '';
          this.loadComments();
        },
        error: () => this.error = 'Failed to add comment'
      });
    }
  }

  deleteComment(commentId: string) {
    this.commentService.delete(commentId).subscribe({
      next: () => this.loadComments(),
      error: () => this.error = 'Failed to delete comment' 
    });
  }

  likeTask() {
    if (this.id) {
      this.taskService.like(this.id).subscribe({
        next: () => {
          if (this.task) this.task.likes = (this.task.likes ?? 0) + 1;
        },
        error: () => this.error = 'Failed to like task'
      });
    }
  }

  dislikeTask() {
    if (this.id) {
      this.taskService.dislike(this.id).subscribe({
        next: () => {
          if (this.task) this.task.dislikes = (this.task.dislikes ?? 0) + 1;
        },
        error: () => this.error = 'Failed to dislike task'
      });
    }
  }
}