import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PerfilService } from './perfil.service';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  url = environment.url;

  constructor(
    private readonly http: HttpClient,
    private readonly perfil: PerfilService,
  ) { }

  getAll() {    
    return this.http.get<any[]>(`${this.url}/empleados`)
  }

  // async getJSON() {    
  //   return await this.http.get<any[]>(`${this.url}/empleados/json`).toPromise();
  // }

  async getById() {    
    return await this.http.get(`${this.url}/empleados`)
  }
}
