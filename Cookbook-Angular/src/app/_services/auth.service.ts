import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { UserRegister } from '../_models/user-register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl.concat('auth/');
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  get username(): string {
    if (this.loggedIn()) {
      const token: string = localStorage.getItem('token');
      const decodedToken = this.jwtHelper.decodeToken(token);
      return decodedToken.unique_name;
    }

    return null;
  }

  get userId(): number {
    if (this.loggedIn()) {
      const token: string = localStorage.getItem('token');
      const decodedToken = this.jwtHelper.decodeToken(token);
      return parseInt(decodedToken.nameid, 10);
    }

    return null;
  }

  constructor(private http: HttpClient) {
  }

  login(model: any): Observable<any> {
    return this.http.post(this.baseUrl.concat('login'), model).pipe(
      map((response: any) => {
        if (response && response.token) {
          localStorage.setItem('token', response.token);
        }
      })
    );
  }

  logout(fnCallback: (() => void) = null): void {
    localStorage.removeItem('token');

    if (fnCallback) {
      fnCallback();
    }
  }

  register(user: UserRegister): Observable<any> {
    return this.http.post(this.baseUrl.concat('register'), user);
  }

  loggedIn(): boolean {
    const token: string = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
