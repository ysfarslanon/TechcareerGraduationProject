import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
  ValidatorFn,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RegisterUserDto } from 'src/app/models/auth/register-User-Dto';
import { AuthService } from 'src/app/services/auth/auth.service';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router:Router,
    private toastr:ToastrService
  ) {}

  ngOnInit(): void {
    this.createRegisterForm()
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          this.passwordStrengthValidator(),
        ],
      ],
      passwordRepeat: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          this.passwordStrengthValidator(),
          this.passwordMatch('password','passwordRepeat')
        ],
      ],
    });
  }



  register(registerUserDto: RegisterUserDto) {    
    this.authService.register(registerUserDto).subscribe(
      (response) => {
        this.toastr.success("Kayıt oldunuz. listelerinize yönlendiriliyorsunuz", "Başarılı")
        localStorage.removeItem('token');
        localStorage.setItem('token', response.token);
        this.router.navigate(['/shoppinglist'])
      },
      (errorResponse) => {
        this.toastr.warning("Mevcut kullanıcı","UYARI")
      }
    );
  }




  submit(){
    if (this.registerForm.valid) {
      let registerModel = Object.assign({}, this.registerForm.value);
      this.register(registerModel);
      
    } else {
      this.toastr.warning(environment.formNotValid, "UYARI")
    }
  }

  // CUSTOM VALIDATORS 
  passwordStrengthValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      if (!value) return null;

      const hasUpperCase = /[A-Z]+/.test(value);
      const hasLowerCase = /[a-z]+/.test(value);
      const hasNumeric = /[0-9]+/.test(value);

      const passwordValid = hasUpperCase && hasLowerCase && hasNumeric;

      return !passwordValid ? { passwordStrength: true } : null;
    };
  }

  // CUSTOM VALIDATORS 
  passwordMatch(password: string, passwordRepeat: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const formGroup = control as FormGroup;
      const valuePassword = formGroup.get(password)?.value
      const valuePasswordRepeat = formGroup.get(passwordRepeat)?.value

      return valuePassword === valuePasswordRepeat ? null : { passwordRepeatMatch: true };
    };
  }
}
