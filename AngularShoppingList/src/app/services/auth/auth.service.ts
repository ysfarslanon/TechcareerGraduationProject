import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AccessToken } from 'src/app/models/auth/access-Token';
import { LoginUserDto } from 'src/app/models/auth/login-User-Dto';
import { RegisterUserDto } from 'src/app/models/auth/register-User-Dto';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  login(loginUserDto: LoginUserDto): Observable<AccessToken> {
    let newApiUrl: string = environment.authApiUrl + 'Login'
    return this.httpClient.post<AccessToken>(newApiUrl, loginUserDto)
  }

  register(registerUserDto: RegisterUserDto): Observable<AccessToken> {
    let newApiUrl: string = environment.authApiUrl + 'Register'
    return this.httpClient.post<AccessToken>(newApiUrl, registerUserDto)
  }

  isLoggedIn() {
    let token = localStorage.getItem('token')
    if (token) return true

    return false
  }

  logOut() {
    localStorage.removeItem('token')
  }

 
  
}
