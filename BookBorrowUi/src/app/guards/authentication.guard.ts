import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiService } from '../services/api.service';

export const authenticationGuard: CanActivateFn = (route:ActivatedRouteSnapshot, state:RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean |UrlTree => {
  const api: ApiService = inject(ApiService);
  const router: Router = inject(Router);
  if(api.isLoggedIn()==true){
    return api.isLoggedIn();
  }
  else{
    router.navigateByUrl("/login");
    return false;
  }
};
