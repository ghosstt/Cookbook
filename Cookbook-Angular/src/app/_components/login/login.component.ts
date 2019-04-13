import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../_services/auth.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted: boolean;

  get form() {
    return this.loginForm.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private alertifyService: AlertifyService,
    private router: Router) { }

  ngOnInit() {
    this.submitted = false;

    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  login() {
    this.submitted = true;

    if (!this.loginForm.valid) {
      return;
    }

    const formData = {
      UserName: this.loginForm.get('username').value,
      Password: this.loginForm.get('password').value
    };

    this.authService.login(formData).subscribe(() => {
      this.alertifyService.success('Logged in');
    }, error => {
      this.alertifyService.error(error);
    }, () => {
      this.router.navigate(['/home']);
    });
  }
}
