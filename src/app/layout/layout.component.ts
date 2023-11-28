import { Component } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent {
  showSidebar: boolean = false;
  constructor() {}

  ngOnInit(): void {
    this.onHideSidebar();
    this.onShowSidebar();
  }
  onShowSidebar() {
    this.showSidebar = true;
  }

  onHideSidebar() {
    this.showSidebar = false;
  }
}
