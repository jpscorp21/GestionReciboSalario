import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PerfilService } from './perfil.service';

@Injectable({
  providedIn: 'root'
})
export class ReciboSalariosService {

  url = environment.url;

  constructor(
    private readonly http: HttpClient,
    private readonly perfil: PerfilService,
  ) { }

  getAll() {    
    return this.http.get<any[]>(`${this.url}/recibosalarios`)
  }
 
  getByEmpleadoId(id: number) {  
    
    if (!id) {
      return of([] as any[]);
    }

    if (this.perfil.perfil.rol === 1) {      
      return this.http.get<any[]>(`${this.url}/recibosalarios/bygerente/` + id)    
    }

    return this.http.get<any[]>(`${this.url}/recibosalarios/byempleado/` + id)
  }
}
