import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  private accountService = inject(AccountService);

  loggedIn = false;

  model: any = {};

  constructor() { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe({
      next: user => this.loggedIn = !!user, //Esto convierte nuestro objeto user en un booleano
      error: error => console.log(error)
    })
  }

  login() {
    console.log(this.model);

    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.loggedIn = true;
      },
      error: error => {
        console.log(error);
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
  }

}
