<<<<<<< HEAD
import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
=======
import { Component, ElementRef, ViewChild } from '@angular/core';
>>>>>>> 7bb22b79212529c0a216a76c7129d5dd9c3574b1

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
