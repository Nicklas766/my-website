import { Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SharedService } from '../../../shared/shared.service';
import { Article } from '../../../shared/models/article.model';

@Component({
    selector: 'app-articles',
    templateUrl: './articles.component.html',
    styleUrls: ['./articles.component.scss']
})
/** articles component*/
export class ArticlesComponent {

    public articles: Article[];
    public loading: boolean = true;
    public currentArticle: Article;
    /** articles ctor */
    constructor(private sharedService: SharedService) {

    }

    ngOnInit(): void {
        this.sharedService.getAllArticles().then(res => {
            this.articles = res;
            this.loading = false;
        });   
  }


}