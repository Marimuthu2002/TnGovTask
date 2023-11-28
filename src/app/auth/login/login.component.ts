import { Component } from '@angular/core';
import { HelperService } from '../../helper/helper.service';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AuthService } from '../../helper/auth.service';
import { jwtDecode } from 'jwt-decode';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [MessageService],
})
export class LoginComponent {
  tempData: any = {};
  decodeData: any = {};
  constructor(
    public getData: HelperService,
    public router: Router,
    private messageService: MessageService,
    private login: AuthService
  ) {}
  submitData(tempData: any) {
    debugger;
    var data = {
      userName: tempData.userName,
      password: tempData.Password,
    };
    this.login.loginData(data).subscribe({
      next: (data: any) => {
        if (data.code == 200) {
          var token = data.message;
          this.decodeData = jwtDecode(token);
          switch (this.decodeData.Role) {
            case 'User':
              this.router.navigateByUrl("/dashboard/user");
              break;
            case 'Admin':
              this.router.navigateByUrl("/dashboard/admin");
              break;
            case 'SuperAdmin':
              this.router.navigateByUrl("/dashboard/superAdmin");
              break;
            case 'Agent':
              this.router.navigateByUrl("/dashboard/agent");
              break;
            default:
              this.messageService.add({
                    severity: 'success',
                    summary: 'Success Message',
                    detail: 'User Not Found',
                  });
              break;
          }
        } else {
        }
      },
    });
  }
}
// setTimeout(() => {
//   this.messageService.add({
//     severity: 'success',
//     summary: 'Success Message',
//     detail: 'Login Success',
//   });
// }, 1000);
