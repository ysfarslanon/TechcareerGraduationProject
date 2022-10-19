import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLogged:boolean = false
  userFullName:string = ''
  constructor(private authService:AuthService) { }
  

  ngOnInit(): void {
    this.isLogged = this.authService.isLoggedIn()
    this.userFullName = this.getFullName()
  } 

  logOut(){
    this.authService.logOut()
    this.ngOnInit()
  }

  getFullName(){
    const jwtHelper = new JwtHelperService()
    const rawToken:any = localStorage.getItem('token')
    const token = jwtHelper.decodeToken(rawToken)
    return token.fullName
    
  }

}
