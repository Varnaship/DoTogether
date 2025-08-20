import { HttpInterceptorFn } from '@angular/common/http';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  // Do not add Authorization header for login or register requests
  const isAuthRequest = req.url.includes('/api/users/login') || req.url.includes('/api/users/register');
  if (isAuthRequest) {
    return next(req);
  }
  let token: string | null = null;
  if (typeof window !== 'undefined') {
    token = localStorage.getItem('token') || localStorage.getItem('auth_token');
  }
  if (token) {
    const cloned = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
    return next(cloned);
  }
  return next(req);
};
