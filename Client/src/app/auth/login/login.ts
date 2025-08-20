import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
  imports: [CommonModule, FormsModule]
})
export class Login {
  error: string | null = null;
  email: string = '';
  password: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  login() {
    this.error = null;
    if (!this.email || !this.password) {
      this.error = 'Email and password are required.';
      return;
    }
    const payload = {
      Email: this.email,
      Password: this.password
    };
    this.http.post('/api/users/login', payload).subscribe({
      next: (res: any) => {
        if (typeof window !== 'undefined') {
          // localStorage usage
          localStorage.setItem('auth_token', res.token);
        }
        this.router.navigate(['/']);
      },
      error: err => {
        this.error = err?.error?.message || 'Login failed.';
      }
    });
  }
}
