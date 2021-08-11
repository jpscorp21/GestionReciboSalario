import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './pages.component';

const routes: Routes = [
  {
    path: '',        
    component: PagesComponent,
    children: [
        {
          path: '',
          redirectTo: 'recibo-salarios',
          pathMatch: 'full'
        },
        {
            path: 'recibo-salarios',
            loadChildren: () => import('./recibo-salarios/recibo-salarios.module').then( m => m.ReciboSalariosPageModule)
        },
        {
            path: 'empleados',
            loadChildren: () => import('./empleados/empleados.module').then( m => m.EmpleadosPageModule)
        },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
