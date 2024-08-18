import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Aqui se reciben los users desde el componente padre (HomeComponent)
  @Input() usersFromHomeComponent: any; //parent to child
  @Output() cancelRegister = new EventEmitter(); //child to parent

  model: any = {};

  constructor() { }

  ngOnInit(): void {
    console.log(this.usersFromHomeComponent);
  }

  register(){
    console.log(this.model);
  }

  cancel(){
    this.cancelRegister.emit(false); //se emite el evento al componente padre (HomeComponent)
  }

}
