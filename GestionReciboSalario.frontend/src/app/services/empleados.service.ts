import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  url = environment.url;

  constructor(
    private readonly http: HttpClient
  ) { }

  getAll() {    
    return this.http.get<any[]>(`${this.url}/empleados`)
  }

  async getById() {    
    return await this.http.get(`${this.url}/empleados`)
  }
}
