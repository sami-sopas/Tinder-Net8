import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
  encapsulation: ViewEncapsulation.Emulated //Valor por defecto, Encapculacion del css
})
export class MemberCardComponent implements OnInit {

  //Input para recibir al miembro del componente padre (Members list)
  @Input() member: Member | undefined;
  //Otra manera de resolver el error: member: Member = {} as Member; //Castear un objeto vacio como Member para "inicializarlo vacio"

  constructor() { }

  ngOnInit(): void {
  }

}
