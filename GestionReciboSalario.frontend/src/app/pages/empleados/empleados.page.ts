import { Component, OnInit } from '@angular/core';
import { EmpleadosService } from 'src/app/services/empleados.service';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.page.html',
  styleUrls: ['./empleados.page.scss'],
})
export class EmpleadosPage implements OnInit {

  constructor(
    public readonly empleados: EmpleadosService
  ) { }

  empleados$ = this.empleados.getAll();

  ngOnInit() {
    // this.empleados.getJSON();
  }

}
