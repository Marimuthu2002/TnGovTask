import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SuperAdminRoutingModule } from './super-admin-routing.module';
import { SuperAdminComponent } from './super-admin.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { PrimengModule } from 'src/app/helper/primeng/primeng.module';


@NgModule({
  declarations: [
    SuperAdminComponent,
    DashbordComponent
  ],
  imports: [
    CommonModule,
    SuperAdminRoutingModule,
    PrimengModule
  ]
})
export class SuperAdminModule { }
