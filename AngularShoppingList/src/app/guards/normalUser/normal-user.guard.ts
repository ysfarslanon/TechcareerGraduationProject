import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/services/auth/auth.service';

@Injectable({
  providedIn: 'root',
})
export class NormalUserGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  jwtHelper = new JwtHelperService();
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const localStorageToken: string | undefined | any =
      localStorage.getItem('token');
    const decodeToken: any = this.jwtHelper.decodeToken(localStorageToken);

    if (this.authService.isLoggedIn() && decodeToken.role == 'Normal') {
      return true;
    } else {
      this.toastr.warning('Özel Alan', 'UYARI');
      if (decodeToken.role == "Admin") {
        this.router.navigate(['/']);
        return false
        
      } else {
      this.router.navigate(['login']);
      console.log(decodeToken);
      console.log("bb");
      console.log(decodeToken.role)
    }
      return false;
    }
  }
}
