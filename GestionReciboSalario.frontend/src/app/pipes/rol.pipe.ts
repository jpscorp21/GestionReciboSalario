import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'rol'
})
export class RolPipe implements PipeTransform {
  transform(value: any[], id: number) {
    return value.filter((item: any) => {
        return item.rol.find((rolItem: any) => rolItem === id);   
    });
  }
}
