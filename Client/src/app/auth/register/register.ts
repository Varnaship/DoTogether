import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
  import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.html',
  styleUrls: ['./register.css'],
  imports: [CommonModule, FormsModule]
})
export class Register {
  error: string | null = null;
  username: string = '';
  password: string = '';
  email: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  register() {
    this.error = null;
    if (!this.username || !this.password || !this.email) {
      this.error = 'All fields are required.';
      return;
    }
    const payload = {
      UserName: this.username,
      Email: this.email,
      Password: this.password
    };
    this.http.post('/api/users/register', payload).subscribe({
      next: () => this.router.navigate(['/login']),
      error: err => {
        this.error = err?.error?.message || 'Registration failed.';
      }
    });
  }
}
