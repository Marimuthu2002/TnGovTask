import { HelperService } from '../../helper/helper.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  tempData: any = {};
  userDetails: any;
  visible: boolean = false;
  userDetailsVisible: boolean = false;
  editVisible: boolean = false;
  constructor(public getData: HelperService) {}
  showDialog() {
    this.visible = true;
  }
  editData() {
    this.editVisible = true;
  }
  submitData(tempData: any) {
    debugger;
    var data = {
      candidate_Id: 0,
      firstname: tempData.firstname,
      lastname: tempData.lastname,
      email: tempData.gmail,
      mobilenumber: tempData.phoneNumber,
      dateOfBirth: tempData.dateOfBirth,
      aadhar: tempData.adharNumber,
      role: 'User',
      userName: 'string',
      passWord: 'string',
    };
    this.getData.registerData(data).subscribe({
      next: (res: any) => {
        console.log(res);
        this.userDetails = res;
        this.userDetailsVisible = true;
      },
    });
    this.visible = false;
    this.tempData.resetForm();
  }
  downloadPdf() {
    debugger
  }
  downloadPadf() {
    this.userDetailsVisible = true;
  }
}
