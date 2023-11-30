import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { DocumentComponent } from './document/document.component';
import { PrimengModule } from 'src/app/helper/primeng/primeng.module';
import { TimeLineComponent } from './time-line/time-line.component';
import { SchemesComponent } from './schemes/schemes.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UserComponent,
    DocumentComponent,
    TimeLineComponent,
    SchemesComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    PrimengModule,
    FormsModule
  ]
})
export class UserModule { }
