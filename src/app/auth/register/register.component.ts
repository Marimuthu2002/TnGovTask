import { AuthService } from 'src/app/helper/auth.service';
import { HelperService } from '../../helper/helper.service';
import { Component } from '@angular/core';
import { HttpResponse } from '@angular/common/http';

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
  constructor(public getData: HelperService, public Data: AuthService) {}
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
  }
  downloadPdf(data: any) {
    debugger;
    var body = {
      userName: data.userName,
      password: data.password,
    };
    // this.getData.genaratePdf(body).subscribe({
    //   next: (res: Blob) => {
    //     const blobUrl = URL.createObjectURL(res);
    //     const a = document.createElement('a');
    //     a.href = blobUrl;
    //     a.download = 'filename.pdf';
    //     a.click();
    //     URL.revokeObjectURL(blobUrl);
    //   },
    // });

    this.Data.genaratePdf(body).subscribe({
      next: (res: HttpResponse<Blob>) => {
        const blob = new Blob([res.body as BlobPart], {
          type: 'application/pdf',
        });
  
        const downloadLink = document.createElement('a');
        downloadLink.href = URL.createObjectURL(blob);
        downloadLink.download = 'EncryptedDocument.pdf';
  
        // Trigger click to start download
        downloadLink.click();
        document.body.removeChild(downloadLink);
      },
      error: (error) => {
        console.error('Error downloading Blob:', error);
        // Handle the error as needed
      },
    });
  }
}
