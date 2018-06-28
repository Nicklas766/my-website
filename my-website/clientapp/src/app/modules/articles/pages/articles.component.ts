import { Component } from '@angular/core';

import { SharedService } from '../../../shared/shared.service';

@Component({
    selector: 'app-articles',
    templateUrl: './articles.component.html',
    styleUrls: ['./articles.component.scss']
})
/** articles component*/
export class ArticlesComponent {
    /** articles ctor */
    constructor(private sharedService: SharedService) {

    }

    public blogPosts: any;
    public loading: boolean = false;
    public currentBlogPost: object;
}