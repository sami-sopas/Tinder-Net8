import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment.development';

//Un servicio es un singleton, es decir, una sola instancia de la clase se crea y se comparte en toda la aplicación.
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl;

  private currentUserSource = new BehaviorSubject<User | null>(null); //User | null -> User o null
  currentUser$ = this.currentUserSource.asObservable(); //El signo $ es una convencion para indicar que es un observable

  //Son lo mismo este y el controctor -> private http = inject(HttpClient);
  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      //Pipe toma el Observador que retorna la peticion http para realizar operaciones con el
      map((response: User) => {
        const user = response;
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  register(model: any){
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user; //Si se necesita usar el valor que retorna la API, este debe hacerse dentro del map
      } )
    )
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
