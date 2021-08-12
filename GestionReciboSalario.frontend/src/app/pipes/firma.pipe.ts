import { Pipe, PipeTransform } from '@angular/core';
import { PerfilService } from '../services/perfil.service';

@Pipe({
  name: 'firma'
})
export class FirmaPipe implements PipeTransform {

    constructor(public perfil: PerfilService) {        
    }

    transform(value: any[]) {    
        if (!value) {
            return [];
        }

        if (this.perfil.perfil && this.perfil.perfil.rol === 1) {
            return value;
        }

        return value.filter(x => x.firmaGerente);
    }
}
