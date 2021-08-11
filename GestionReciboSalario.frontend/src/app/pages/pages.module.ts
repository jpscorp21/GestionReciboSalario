import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicModule } from '@ionic/angular';
import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [PagesComponent],  
  imports: [
      CommonModule,      
      IonicModule, 
      PagesRoutingModule
    ],  
})
export class PagesModule {}
