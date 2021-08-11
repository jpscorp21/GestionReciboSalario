import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ReciboSalariosPageRoutingModule } from './recibo-salarios-routing.module';

import { ReciboSalariosPage } from './recibo-salarios.page';
import { PipesModule } from 'src/app/pipes/pipes.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ReciboSalariosPageRoutingModule,
    PipesModule
  ],
  declarations: [ReciboSalariosPage]
})
export class ReciboSalariosPageModule {}
