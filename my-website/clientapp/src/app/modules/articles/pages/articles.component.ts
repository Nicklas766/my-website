import { Component } from '@angular/core';

import { SharedService } from '../../../shared/shared.service';
import { Article } from '../../../shared/models/article.model';

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

    public blogPosts: Article;
    public loading: boolean = false;
    public currentBlogPost: object;
}