import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
@Injectable({
  providedIn: 'root',
})
export class HelperService {
  constructor(private authService: AuthService) { }
  registerData(body: any) {
    return this.authService.post('User/Register', body);
  }
  loginData(body: any) {
    return this.authService.post('User/Login', body);
  }
}
