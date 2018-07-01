/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { AlertMessageComponent } from './alert-message.component';

let component: AlertMessageComponent;
let fixture: ComponentFixture<AlertMessageComponent>;

describe('AlertMessage component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ AlertMessageComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(AlertMessageComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});