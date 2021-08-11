import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PerfilService } from '../../services/perfil.service';
import { AuthService } from '../../services/auth.service';
import { ToastService } from 'src/app/services/shared/toast.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  public ngForm: FormGroup;

  constructor(
    public formBuilder: FormBuilder,
    public router: Router,
    public perfil: PerfilService,
    private readonly toast: ToastService,
    private readonly auth: AuthService,    
  ) {
    this.createForm();
  }

  ngOnInit() {
    localStorage.removeItem('salario-perfil');
  }

  createForm() {
    this.ngForm = this.formBuilder.group({
      usuario: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  async iniciarSesion() {
    if (!this.ngForm.valid) {
      return;
    }
    try {
         
    
      const data: any = await this.auth.login({...this.ngForm.value});      
      console.log(data);
      if (data) {        
        localStorage.setItem('salario-perfil', JSON.stringify(data));
        // localStorage.setItem('perfil', JSON.stringify(data[0]));
        this.perfil.initPerfil();
        this.ngForm.reset();
                
        await this.router.navigateByUrl('/pages/recibo-salarios');
      } else {
        await this.toast.create('Dirección de correo electrónico o contraseña no válidos');
      }
    }
    catch (e) {
      await this.toast.create('Dirección de correo electrónico o contraseña no válidos');      
      console.log(e);
    }
  }

}
