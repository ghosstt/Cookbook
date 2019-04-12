import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  get username() {
    return this.authService.username;
  }

  constructor(
    private router: Router,
    private authService: AuthService,
    private alertifyService: AlertifyService) {

  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    this.authService.logout(() => {
      this.alertifyService.success('Logged out');
      this.router.navigate(['/login']);
    });
  }
}
