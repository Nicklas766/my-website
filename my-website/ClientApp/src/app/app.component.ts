import { Router, NavigationEnd } from '@angular/router';
import { Component, ElementRef, ViewChild } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild('header') headerElement: ElementRef;

  navbarHeight: number;
  title = 'app';

  constructor() {}

  ngOnInit(): void {
    this.navbarHeight = this.headerElement.nativeElement.clientHeight;
  }
}
