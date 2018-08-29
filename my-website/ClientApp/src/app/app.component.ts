import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild('header') elementView2: ElementRef;

  navbarHeight: number;
  title = 'app';

  constructor() {}

  ngOnInit(): void {
    this.navbarHeight = this.elementView2.nativeElement.clientHeight;
  }
}
