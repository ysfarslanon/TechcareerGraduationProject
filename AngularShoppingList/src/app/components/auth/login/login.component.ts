import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginUserDto } from 'src/app/models/auth/login-User-Dto';
import { AuthService } from 'src/app/services/auth/auth.service';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router:Router,
    private toastr:ToastrService
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  login(loginUserDto: LoginUserDto) {
    this.authService.login(loginUserDto).subscribe(
      (response) => {
        localStorage.removeItem('token');
        localStorage.setItem('token', response.token);
        this.toastr.success("Alışveriş listelerinize yönlendiriliyorsunuz","Başarılı")
        this.router.navigate(['/shoppinglist'])
      },
      (errorResponse) => {
      }
    );
  }

  submit(){
    if (this.loginForm.valid) {
      let loginModel = Object.assign({}, this.loginForm.value);
      this.login(loginModel)  
    } else {
      this.toastr.warning(environment.formNotValid, "UYARI")
    }
  }
 
  
}
