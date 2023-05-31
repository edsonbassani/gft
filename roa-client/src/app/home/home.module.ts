import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HomeRoutingModule } from './home-routing.module';
import { LandingComponent } from './pages/landing/landing.component';
import { AppMaterialsModule } from '../app-materials.module'

@NgModule({
  declarations: [
    LandingComponent,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    AppMaterialsModule
  ]
})
export class HomeModule { }
