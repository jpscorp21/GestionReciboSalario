import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ReciboSalariosPage } from './recibo-salarios.page';

const routes: Routes = [
  {
    path: '',
    component: ReciboSalariosPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ReciboSalariosPageRoutingModule {}
