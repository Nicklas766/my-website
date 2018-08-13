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
    public searchString: string = "";
    /** articles ctor */
    constructor(private sharedService: SharedService) {

    }

    ngOnInit(): void {
        this.getArticles();
    }

    getArticles() {
        return this.sharedService.getAllArticles().then(res => {
            this.articles = res;
            this.loading = false;
        });   
    }

    async searchForArticles() {
        await this.getArticles();
        const lowerCaseSearch = this.searchString.toLowerCase();
        this.articles = this.articles.filter(article => article.title.toLowerCase().includes(lowerCaseSearch));
    }


}