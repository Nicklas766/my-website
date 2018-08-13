import { Injectable } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

import { Article } from '../shared/models/article.model';


@Injectable()
export class SharedService {
     constructor(private http: HttpClient) {}

     getAllArticles() {
        var promise = this.http.get('/api/blog/all').toPromise() as Promise<Article[]>;
        return promise.then(res => this.getArticlesWithDateStrings(res));
    }
    
    getArticleBySlug(slug: string) {
        var promise = this.http.get('/api/blog/article/' + slug).toPromise() as Promise<Article>;
        return promise.then(res => res = this.getArticleWithDateString(res));
    }

    getArticleWithDateString(article: Article) {
        return Object.assign(article, {publishDateString: this.getDateStringWithoutTimeStamp(article.publishDate)})   
    }

    getArticlesWithDateStrings(articles: Article[]) {
        return articles.map(obj => this.getArticleWithDateString(obj));
    }
    getDateStringWithoutTimeStamp(argDate: Date) {
        const date: Date = new Date(argDate);
        var month = ('0' + (date.getMonth() + 1)).slice(-2);
        var day = ('0' + (date.getDate() + 1)).slice(-2);
        var year = date.getUTCFullYear();
    
        return year + "-" + month + "-" + day; 
    }
}
