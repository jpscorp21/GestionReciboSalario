import { Component } from '@angular/core';
import { PerfilService } from '../services/perfil.service';
@Component({
  selector: 'app-pages',
  templateUrl: 'pages.component.html',
  styleUrls: ['pages.component.scss'],
})
export class PagesComponent {
  public appPages = [
    { title: 'Recibo salarios', url: '/pages/recibo-salarios', icon: 'document' },
    { title: 'Empleados', url: '/pages/empleados', icon: 'person' },    
    { title: 'Salir', url: '/login', icon: 'exit' },    
  ];  
  constructor(
      public perfil: PerfilService
  ) {}  
}
