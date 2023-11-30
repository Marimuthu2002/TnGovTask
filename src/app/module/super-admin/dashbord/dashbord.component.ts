import { Component } from '@angular/core';
import { HelperService } from 'src/app/helper/helper.service';

@Component({
  selector: 'app-dashbord',
  templateUrl: './dashbord.component.html',
  styleUrls: ['./dashbord.component.scss']
})
export class DashbordComponent {
  getAllData: any = ([] = []);
  selectedSize: any;
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
}
