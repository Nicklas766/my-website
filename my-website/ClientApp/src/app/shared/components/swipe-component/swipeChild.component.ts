import { Component, OnInit, Input, ViewChildren, QueryList, ContentChildren } from '@angular/core';
import { trigger, state, style, transition, animate, keyframes } from '@angular/animations';

@Component({
    selector: 'shop-swipe-child',
    template: `
        <div [@openClose]="{value: (on), params: { prevPos: prevPos, newPos: currPosition}}" [ngStyle]="position" >
        <ng-content></ng-content>
        </div>
    `,
    styleUrls: [ './swipeChild.component.scss' ],
    animations: [
        trigger('openClose', [
            transition('false <=> true', [
                animate('350ms', keyframes([
                    style({transform: "translate3d({{prevPos}}%, 0, 0)"}),
                    style({transform: "translate3d({{newPos}}%, 0, 0)"}),
                ]))
              ], {params : { prevPos: "0", newPos: "0" }}),
        ])
    ]
     
  })
  export class SwipeChildComponent {
    public position: object;
    public on: boolean = false;
    public prevPos: number;
    public currPosition: number = 0;

    @Input() key: number;

    public ngOnInit(): void {
        this.currPosition = this.updateCurrPosition((this.key * 100));
    }

    public updateCurrPosition(newPosition: number): number {
        this.position = {
            transform: "translate3d(" + newPosition + "%, 0, 0)"
        }
        this.on = !this.on;
        return newPosition;
    }

    public moveStyle(newPosition: number) {
        this.currPosition = ((this.currPosition + (newPosition/100)))
        this.position = {
            transform: "translate3d(" + this.currPosition + "%, 0, 0)"
        }
    }

    public newKey(newIndex: number) {
        this.prevPos = this.currPosition;
        
        if (this.key < newIndex) {
            this.currPosition = this.updateCurrPosition((newIndex - this.key) * -100);
        }

        if (this.key > newIndex) {
            this.currPosition = this.updateCurrPosition((this.key - newIndex) * 100);
        }

        if (this.key === newIndex) {
            this.currPosition = this.updateCurrPosition(0);
        }
    }
}