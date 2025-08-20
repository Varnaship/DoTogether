import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';

export interface User {
  id: string;
  username: string;
  email?: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = '/api/auth';
  private tokenKey = 'auth_token';
  private userSubject = new BehaviorSubject<User | null>(null);
  user$ = this.userSubject.asObservable();

  constructor(private http: HttpClient) {
    if (typeof window !== 'undefined' && window.localStorage) {
      const token = localStorage.getItem(this.tokenKey);
      if (token) {
        // Optionally fetch user info from backend
        // this.getProfile().subscribe(user => this.userSubject.next(user));
      }
    }
  }

  login(username: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { username, password }).pipe(
      tap(res => {
        if (typeof window !== 'undefined') {
          localStorage.setItem(this.tokenKey, res.token);
        }
        // Optionally fetch user info
        // this.getProfile().subscribe(user => this.userSubject.next(user));
      })
    );
  }

  register(username: string, password: string, email?: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/register`, { username, password, email }).pipe(
      tap(res => {
        if (typeof window !== 'undefined') {
          localStorage.setItem(this.tokenKey, res.token);
        }
        // Optionally fetch user info
        // this.getProfile().subscribe(user => this.userSubject.next(user));
      })
    );
  }

  logout() {
    if (typeof window !== 'undefined') {
      localStorage.removeItem(this.tokenKey);
    }
    this.userSubject.next(null);
  }

  get token(): string | null {
    return typeof window !== 'undefined' ? localStorage.getItem(this.tokenKey) : null;
  }

  get isLoggedIn(): boolean {
    return !!this.token;
  }
}