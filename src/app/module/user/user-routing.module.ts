import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user.component';
import { DocumentComponent } from './document/document.component';
import { TimeLineComponent } from './time-line/time-line.component';
import { SchemesComponent } from './schemes/schemes.component';

const routes: Routes = [
  {
    path: '',
    component: DocumentComponent,
  },
  {
    path: 'timeline',
    component: TimeLineComponent,
  },
  {
    path: 'schemes',
    component: SchemesComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
