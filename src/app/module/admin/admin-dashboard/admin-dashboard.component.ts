import { Component, Input } from '@angular/core';
import { HelperService } from 'src/app/helper/helper.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss'],
})
export class AdminDashboardComponent {
  getAllData: any = ([] = []);
  item: any = {};
  visible: boolean = false;
  selectedSize: any;
  reItem: any;
  optionData = [
    { name: 'Agent', code: '1' },
    { name: 'User', code: '2' },
  ];
  constructor(public getSerice: HelperService) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.getSerice.userData().subscribe({
      next: (data: any) => {
        this.getAllData = data;
      },
    });
  }

  filterData(lookup: any): void {
    debugger;
    this.getAllData.forEach((res: any) => {
      if (res.role == lookup.value.name) {
        this.getAllData = res;
      }
    });
    return this.reItem;
  }

  getUserData(data: any) {
    this.item = data;
    this.visible = true;
  }
}
