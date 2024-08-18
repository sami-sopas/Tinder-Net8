import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { User } from '../_models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Aqui se reciben los users desde el componente padre (HomeComponent)
  @Input() usersFromHomeComponent: any; //parent to child

  //Se emite el evento al componente padre para cambiar el registerMode flag (HomeComponent)
  @Output() cancelRegister = new EventEmitter(); //child to parent

  model: any = {
    username: '',
    password: '',
  };

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
    //console.log(this.usersFromHomeComponent);
  }

  register(){
    console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: response =>{
        console.log(response);
        this.cancel();
      },
      error: error => {
        console.log(this.model);
        console.log(error); //TODO: no muestra el campo que tiene el error, solo registerDTO
        this.toastr.error(error.error) //se muestra el error en un toast
      }
    })
  }

  cancel(){
    this.cancelRegister.emit(false); //se emite el evento al componente padre (HomeComponent)
  }

}
