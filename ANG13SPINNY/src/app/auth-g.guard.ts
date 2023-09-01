import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthservService } from './authserv.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGGuard implements CanActivate {
  constructor(private serv:AuthservService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.serv.isuserloggedin();
  }
  
}
