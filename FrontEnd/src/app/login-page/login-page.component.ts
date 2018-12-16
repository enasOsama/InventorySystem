import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthService } from '../auth/services/auth.service';



@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  form: FormGroup;
  returnUrl: any;
  error: any;
  submitted = false;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private authenticationService: AuthService) {

  }

  ngOnInit() {
    this.form = this.fb.group(
      {
        "userName": ['', [Validators.required, Validators.email]],
        "password": ['', Validators.required]
      }
    );
    // reset login status
    this.authenticationService.logout();
    this.error = null;
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }


  onSubmit() {

    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.authenticationService.login(this.form.value.userName, this.form.value.password)
      .pipe(first())
      .subscribe(result => {
        debugger;
        this.router.navigate([this.returnUrl]);
      }, () => {
        this.error = "Incorrect Username or Password";
      });
  }
}
