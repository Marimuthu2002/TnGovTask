import { NgModule } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
@NgModule({
  declarations: [],
  imports: [
    InputTextModule,
    ButtonModule,
    CalendarModule,
    DialogModule,
    ToastModule
  ],
  exports:[
    InputTextModule,
    ButtonModule,
    CalendarModule,
    DialogModule,
    ToastModule
  ]
})
export class PrimengModule { }
