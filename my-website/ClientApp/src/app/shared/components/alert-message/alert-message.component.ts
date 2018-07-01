import { Component, Input, Output, EventEmitter, ViewChildren, QueryList } from '@angular/core';

@Component({
    selector: 'app-alert-message',
    templateUrl: './alert-message.component.html',
    styleUrls: ['./alert-message.component.scss']
})
/** AlertMessage component*/
export class AlertMessageComponent {
    /** AlertMessage ctor */
  @Input() isVisible: boolean;
  @Input() type: string;
  @Output() isVisibleChange = new EventEmitter<boolean>();

  constructor() { }

  hide() {
    this.isVisibleChange.emit(!this.isVisible);
  }
}
