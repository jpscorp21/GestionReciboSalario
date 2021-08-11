import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  private perfilSubject = new BehaviorSubject<any>(null);
  public perfil$ = this.perfilSubject.asObservable();

  get perfil() {
    return this.perfilSubject.getValue();
  }

  initPerfil() {
    if (localStorage.getItem('salario-perfil')) {
      const perfilJson = localStorage.getItem('salario-perfil');
      this.perfilSubject.next(JSON.parse(perfilJson));      

      return JSON.parse(perfilJson);
    } else {
      this.perfilSubject.next(JSON.parse(null));

      return null;
    }
  }

  constructor() { }
}
