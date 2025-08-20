import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-project-members',
  standalone: true,
  templateUrl: './project-members.html',
  styleUrls: ['./project-members.css'],
  imports: [CommonModule]
})
export class ProjectMembers implements OnInit {
  members: any[] = [];
  error: string | null = null;
  projectId: string | null = null;
  currentUserId: string = ''; // Set this from your auth service
  isOwner: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.projectId = this.route.snapshot.paramMap.get('id');
    // Set currentUserId from your auth service/session
    if (typeof window !== 'undefined') {
      this.currentUserId = localStorage.getItem('userId') || '';
    }
    if (this.projectId) {
      this.http.get<any[]>(`/api/projectmembers/${this.projectId}`).subscribe({
        next: (members) => {
          this.members = members;
          const owner = members.find(m => m.role === 'Owner');
          this.isOwner = owner && owner.userId === this.currentUserId;
        },
        error: () => this.error = 'Failed to load members'
      });
    }
  }

  kickMember(memberId: string) {
    if (!this.projectId) return;
    this.http.delete(`/api/projectmembers/${this.projectId}/kick/${memberId}`).subscribe({
      next: () => this.members = this.members.filter(m => m.userId !== memberId),
      error: () => this.error = 'Failed to kick member'
    });
  }

  leaveProject(memberId: string) {
    if (!this.projectId) return;
    this.http.delete(`/api/projectmembers/${this.projectId}/leave/${memberId}`).subscribe({
      next: () => this.members = this.members.filter(m => m.userId !== memberId),
      error: () => this.error = 'Failed to leave project'
    });
  }
}