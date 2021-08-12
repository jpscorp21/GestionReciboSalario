import { Component, OnInit } from '@angular/core';
import { PerfilService } from 'src/app/services/perfil.service';
import { ReciboSalariosService } from 'src/app/services/recibo-salarios.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recibo-salarios',
  templateUrl: './recibo-salarios.page.html',
  styleUrls: ['./recibo-salarios.page.scss'],
})
export class ReciboSalariosPage implements OnInit {

  url = environment.url;

  constructor(
    public reciboSalarios: ReciboSalariosService,
    public perfil: PerfilService
  ) { }

  recibos$ = this.reciboSalarios.getByEmpleadoId(this.perfil.perfil?.id);

  ngOnInit() {
  }

  imprimir(recibo) { 
    
    

    if (recibo.firmaEmpleado && recibo.firmaGerente) {
      const elem = document.createElement("a");
      elem.href = `${this.url}/empleados/firmaempleado/` + recibo.empleadoId + '/' + recibo.id;
      elem.target = "_blank";
      elem.click();
    }

    if (recibo.firmaEmpleado || recibo.firmaGerente) {
      this.firmaEmpleado(recibo);
    }

    const elem = document.createElement("a");
    elem.href = `${this.url}/recibosalarios/reporte/` + recibo.id;
    elem.target = "_blank";
    elem.click();
  }

  firmaEmpleado(recibo: any) {
    console.log(recibo);
    if (this.perfil.perfil.rol == 1) {
      const elem = document.createElement("a");
      elem.href = `${this.url}/empleados/firmagerente/` + recibo.gerenteId + '/' + recibo.id;
      elem.target = "_blank";
      elem.click();
    } else {
      const elem = document.createElement("a");
      elem.href = `${this.url}/empleados/firmaempleado/` + recibo.empleadoId + '/' + recibo.id;
      elem.target = "_blank";
      elem.click();
    }
  }

}
