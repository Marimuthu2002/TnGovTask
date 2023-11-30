import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';

enum Role {
  Admin = 1,
  User = 2,
  SuperAdmin = 3,
  Agent = 4,
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url: string = environment.apiAuthUrl;
  private isRole: any = new BehaviorSubject<number>(Role.User);
  isRoleStore = this.isRole.asObservable();
  constructor(private http: HttpClient, private router: Router) {}

  getBase() {
    return environment.apiAuthUrl;
  }

  post(apiurl: string, body: any) {
    debugger;
    return this.http
      .post<any>(this.getBase() + apiurl, body)
      .pipe(map((data) => data));
  }
  get(apiurl: string) {
    debugger;
    return this.http
      .get<any>(this.getBase() + apiurl)
      .pipe(map((data) => data));
  }
  getConfig(apiurl: string) {
    debugger;
    return this.http.get<any>(apiurl).pipe(map((data) => data));
  }
  mediaPost(apiurl: string, body: any) {
    debugger;
    return this.http
      .post<any>(this.getBase() + apiurl, body, { headers: {} })
      .pipe(map((data) => data));
  }
  missingmediaPost(apiurl: string, body: any) {
    debugger;
    return this.http
      .post<any>(this.getBase() + apiurl, body, { headers: {} })
      .pipe(map((data) => data));
  }

  loginData(user: any): Observable<any> {
    debugger;
    return this.http.post('https://localhost:7101/api/User/Login', user).pipe(
      map((res: any) => {
        if (res) {
          localStorage.setItem('token', res.message);
        }
        return res;
      })
    );
  }

  genaratePdf(user: any): Observable<any> {
    debugger;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      return this.http.post('https://localhost:7101/api/User/GenaratePdf',user, {
        observe: 'response',
        responseType: 'blob' as 'json',
      });
  }

  isLoggerIn(): boolean {
    debugger;
    let IsToken = localStorage.getItem('token');
    return IsToken ? true : false;
  }

  LogoutUser(): void {
    debugger;
    this.router.navigate(['/login']);
    localStorage.clear();
  }

  getMenu(): Observable<any> {
    debugger;
    let filter: any[];
    let jwt: any = localStorage.getItem('token');
    // if (jwt) {
    //   let jwtData = jwt.split('.')[1];
    //   let decodedJwtJsonData = window.atob(jwtData);
    //   let decodedJwtData = JSON.parse(decodedJwtJsonData);
    //   for (const key in decodedJwtData) {
    //     if (Object.prototype.hasOwnProperty.call(decodedJwtData, key)) {
    //       let element: any = decodedJwtData[key];
    //       switch (key) {
    //         case 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role':
    //           element == 'Admin'
    //             ? this.isRole.next(Role.Admin)
    //             : this.isRole.next(Role.User);
    //           break;
    //       }
    //     }
    //   }
    // }

    return this.http.get('./../../assets/menuitem/menuData.json').pipe(
      map((res: any) => {
        if (Array.isArray(res.item)) {
          if (this.isRole._value == Role.Admin) {
            filter = res.item.filter(
              (res: any) => res.role == this.isRole._value
            );
          } else {
            filter = res.item.filter(
              (res: any) => res.role == this.isRole._value
            );
          }
        }
        return filter;
      })
    );
  }
}
