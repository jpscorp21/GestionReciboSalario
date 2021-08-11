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

  imprimir(id: number) {
    const elem = document.createElement("a");
    elem.href = `${this.url}/recibosalarios/reporte/` + id;
    elem.target = "_blank";
    elem.click();
  }

}
