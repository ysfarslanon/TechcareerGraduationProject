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
export class AdminUserGuard implements CanActivate {
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

    if (this.authService.isLoggedIn() && decodeToken.role == 'Admin') {
      return true;
    } else {
      this.toastr.error('Yetkisiz alan',"UYARI");
      this.router.navigate(['/']);
      return false;
    }
  }
}
