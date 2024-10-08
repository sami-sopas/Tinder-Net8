import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, FormsModule, BsDropdownModule, RouterModule],
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  public accountService = inject(AccountService);
  private router = inject(Router);
  private toastr = inject(ToastrService);

  //currentUser$: Observable<User | null> = of(null); //el of es para inicializar el observable en nulo

  model: any = {};

  constructor() { }

  ngOnInit(): void {
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    console.log(this.model);

    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.router.navigateByUrl('/members');
        //console.log(this.currentUser$);
      },
      error: error => {
        console.log(error);
        //this.toastr.error(error.error);
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
