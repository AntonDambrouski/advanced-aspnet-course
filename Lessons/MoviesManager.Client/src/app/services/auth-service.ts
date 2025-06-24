import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { LoginResponse } from '../models/login-response';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl = 'https://localhost:7079/api/auth';
  private readonly TokenKey = 'AppToken';
  private readonly router = inject(Router);
  private readonly httpClient = inject(HttpClient);

  login(email: string) {
    return this.httpClient
      .post<LoginResponse>(`${this.baseUrl}/login`, {
        username: email,
        password: 'password',
      })
      .subscribe((res) => {
        localStorage.setItem(this.TokenKey, res.token);
        this.router.navigate(['/']);
      });
  }

  logout() {
    localStorage.removeItem(this.TokenKey);
    this.router.navigate(['/login']);
  }

  getAccessToken(): string | null {
    return localStorage.getItem(this.TokenKey);
  }

  isAuthenticated(): boolean {
    const token = this.getAccessToken();
    return !!token; // Returns true if token exists, false otherwise
  }
}
