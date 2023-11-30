import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { MessageService } from 'primeng/api';
import { HelperService } from 'src/app/helper/helper.service';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss'],
})
export class DocumentComponent {
  constructor(private getSerice: HelperService, public router: Router) {}
  selectedFile: File | null = null;
  uploadedFiles: File[] = [];
  decodeData: any = {};
  datagerge: any;
  onUpload(event: any) {
    debugger;
    for (const file of event.files) {
      this.uploadedFiles.push(file);
    }
  }
  uploadFile() {
    debugger;
    this.datagerge = localStorage.getItem('token');
    this.decodeData = jwtDecode(this.datagerge);

    const formData = new FormData();
    this.uploadedFiles.forEach(
      (f) => formData.append('files', f, this.decodeData.UserName),
      formData.append('UserName', this.decodeData.UserName)
    );
    this.getSerice.userFileUploadData(formData).subscribe({
      next: (data: any) => {
        debugger;
      },
    });
    this.router.navigate(['dashboard/user/timeline']);
  }

  // uploadFile() {
  //   if (!this.selectedFile) {
  //     console.error('No file selected');
  //     return;
  //   }
  //   const formData = new FormData();
  //   formData.append('file', this.selectedFile, this.selectedFile.name);
  //   formData.append('username', 'john_doe');
  //   const apiUrl = 'your-api-endpoint';

  //   console.log(formData);
  // }
}
