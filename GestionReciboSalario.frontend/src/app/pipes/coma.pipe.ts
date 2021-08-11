import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'coma'
})
export class ComaPipe implements PipeTransform {
  transform(value: any) {
    if (value) {

      value = value.toString();
      const separador = '.';
      const sepDecimal = ',';
      value += '';
      const splitStr = value.split('.');
      let splitLeft = splitStr[0];
      const splitRight = splitStr.length > 1 ? sepDecimal + splitStr[1] : '';
      const regx = /(\d+)(\d{3})/;
      while (regx.test(splitLeft)) {
        splitLeft = splitLeft.replace(regx, '$1' + separador + '$2');
      }
      return splitLeft + splitRight.slice(0, 3);

    } else {
      return '0';
    }

  }
}
