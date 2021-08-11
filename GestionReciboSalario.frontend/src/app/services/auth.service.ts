import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
  url = environment.url;

  constructor(
    private readonly http: HttpClient
  ) { }

  async login(body: any) {    
    return await this.http.post(`${this.url}/empleados/login`, body).toPromise();
  }
}
