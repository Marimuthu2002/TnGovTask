import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class HelperService {
  constructor(private authService: AuthService, private api: HttpClient) {}

  registerData(body: any) {
    return this.authService.post('User/Register', body);
  }

  loginData(body: any) {
    return this.authService.post('User/Login', body);
  }

  genaratePdf(body: any): Observable<Blob> {
    return this.authService.post('User/GenaratePdf', body);
  }
  userData() {
    return this.authService.get('Admin/get');
  }

  userFileUploadData(body: any): Observable<any> {
    return this.api.post('https://localhost:7101/api/Admin/Uploadfile', body);
  }
}
