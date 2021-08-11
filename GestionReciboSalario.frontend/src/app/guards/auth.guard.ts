import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, CanActivateChild } from '@angular/router';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivateChild {
  constructor(private router: Router) { }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!localStorage.getItem('salario-perfil')) {
      this.router.navigateByUrl('/login');
      return false;
    }
    return true;
  }
}
