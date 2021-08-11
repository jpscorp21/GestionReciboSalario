import { Component } from '@angular/core';
import { PerfilService } from '../services/perfil.service';
@Component({
  selector: 'app-pages',
  templateUrl: 'pages.component.html',
  styleUrls: ['pages.component.scss'],
})
export class PagesComponent {
  public appPages = [
    { title: 'Recibo de salarios', url: '/pages/recibo-salarios', icon: 'document', rol: [1, 2] },
    { title: 'Empleados', url: '/pages/empleados', icon: 'person', rol: [1] },    
    { title: 'Salir', url: '/login', icon: 'exit', rol: [1, 2] },    
  ];  
  constructor(
      public perfil: PerfilService
  ) {}  
}
