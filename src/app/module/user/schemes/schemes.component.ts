import { Component } from '@angular/core';

@Component({
  selector: 'app-schemes',
  templateUrl: './schemes.component.html',
  styleUrls: ['./schemes.component.scss'],
})
export class SchemesComponent {
  visible: boolean = false;
  submitData(arg0: any) {
    throw new Error('Method not implemented.');
  }
  editData() {
    throw new Error('Method not implemented.');
  }
  applyScheme() {
    this.visible = true;
  }
  tempData: any = {};
}
