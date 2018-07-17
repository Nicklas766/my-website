import { Component, OnInit, AfterContentInit, Input, QueryList, ContentChildren, ElementRef  } from '@angular/core';
import { trigger, state, style, transition, animate, keyframes } from '@angular/animations';
import { SwipeChildComponent } from './swipeChild.component';

@Component({
    selector: 'shop-swipe-container',
    templateUrl: './swipe.component.html',
    styleUrls: [ './swipe.component.scss' ]
})

/*
* Swipe component 
* uses child components key to keep track of elements
*/
export class SwipeContainerComponent {
    @ContentChildren(SwipeChildComponent)
    children: QueryList<SwipeChildComponent>|SwipeChildComponent[];


    public instance: SwipeContainerComponent;
    public currIndex: number = 0;
    public currPosition: number;

    touchDown(event:any) {
        this.currPosition = event.changedTouches[0].clientX;
    }

    touchMove(event:any) {
        const direction = event.changedTouches[0].clientX;

        for (var child of this.children) {
            child.moveStyle(direction - this.currPosition);
        }
    }

    touchEnd(event:any) {
        const direction = event.changedTouches[0].clientX;

        if (direction < this.currPosition) {
            this.moveRight();
        }
        
        if (direction > this.currPosition) {
            this.moveLeft();
        } 
    
        event.preventDefault();
        event.stopPropagation();
    }
    // Decreases index by 1 if not lower than 1
    public moveLeft() {
        if ((this.currIndex - 1) >= 0) {
            this.currIndex = this.currIndex - 1;
        }

        for (var child of this.children) {
            child.newKey(this.currIndex);
        }
    }
    // Increases index by 1 if not higher than lastIndex
    public moveRight() {
        if (this.currIndex + 1 <= (this.children.length - 1)) {
            this.currIndex = this.currIndex + 1;
        }

        for (var child of this.children) {
            child.newKey(this.currIndex);
        }
    }
}
