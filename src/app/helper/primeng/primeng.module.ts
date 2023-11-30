import { NgModule } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { FileUploadModule } from 'primeng/fileupload';
import { TimelineModule } from 'primeng/timeline';
import { TooltipModule } from 'primeng/tooltip';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
@NgModule({
  declarations: [],
  imports: [
    InputTextModule,
    ButtonModule,
    CalendarModule,
    DialogModule,
    ToastModule,
    FileUploadModule,
    TimelineModule,
    TooltipModule,
    TableModule,
    DropdownModule
  ],
  exports:[
    InputTextModule,
    ButtonModule,
    CalendarModule,
    DialogModule,
    ToastModule,
    FileUploadModule,
    TimelineModule,
    TooltipModule,
    TableModule,
    DropdownModule
  ]
})
export class PrimengModule { }
