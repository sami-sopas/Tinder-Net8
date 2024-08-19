import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.http.get(this.baseUrl + 'buggy/not-found').subscribe({
      error: response => console.log(response),
    })
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/bad-request').subscribe({
      error: response => console.log(response),
    })
  }


  get500Error() {
    this.http.get(this.baseUrl + 'buggy/server-error').subscribe({
      error: response => console.log(response),
    })
  }


  get401Error() {
    this.http.get(this.baseUrl + 'buggy/auth').subscribe({
      error: response => console.log(response),
    })
  }

  get400ValidationError() {
    this.http.post(this.baseUrl + 'account/register', {username: '', password: ''}).subscribe({
      next: response => console.log(response),
      error: response => console.log(response),
    })
  }


}
