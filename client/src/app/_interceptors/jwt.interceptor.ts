import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private accountService: AccountService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {


    //Se verifica que exista un usuario loggeado, en caso de ser asi,
    // se añade el token de autenticacion a la peticion que se realize

    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user =>{
        if(user){
          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${user.token}`
            }
          })
        }
      }
    })

    return next.handle(request);
  }
}
