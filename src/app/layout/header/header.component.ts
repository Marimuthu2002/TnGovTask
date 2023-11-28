import { Component, EventEmitter, Output } from '@angular/core';
import { AuthService } from 'src/app/helper/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  anglehide: boolean = false;
  angleshow: boolean = true;
  @Output() showSidebar = new EventEmitter<void>();
  @Output() hideSidebar = new EventEmitter<void>();

  constructor(private login: AuthService) {}

  ngOnInit(): void {
    let bool: any = String(localStorage.getItem('sidebar'));
    if (bool === 'true') {
      this.angleshow = false;
      this.anglehide = true;
      this.showSidebar.emit();
    } else {
      localStorage.setItem('sidebar', 'false');
      this.angleshow = true;
      this.anglehide = false;
      this.hideSidebar.emit();
    }
  }

  angleright() {
    localStorage.setItem('sidebar', 'true');
    this.angleshow = false;
    this.anglehide = true;
    this.showSidebar.emit();
  }

  angleleft() {
    localStorage.setItem('sidebar', 'false');
    this.angleshow = true;
    this.anglehide = false;
    this.hideSidebar.emit();
  }

  logOut() {
    this.login.LogoutUser();
  }
}
