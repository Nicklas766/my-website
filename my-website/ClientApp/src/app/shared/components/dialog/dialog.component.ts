import { Component, Input, Output, EventEmitter, ViewChildren, QueryList } from '@angular/core';

@Component({
    selector: 'app-dialog',
    templateUrl: './dialog.component.html',
    styleUrls: ['./dialog.component.scss']
})
/** AlertMessage component*/
export class DialogComponent {

    public visible: boolean = false;

  constructor() { }

  show() {
      this.visible = true;
  }

  hide() {
      this.visible = false;
  }


}
