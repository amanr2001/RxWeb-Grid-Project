import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthservService } from 'src/services/authserv.service';

@Injectable({
  providedIn: 'root'
})
export class VerifiedGuardGuard implements CanActivate {
  constructor(private authserv:AuthservService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.authserv.isverified;
  }
  
}
