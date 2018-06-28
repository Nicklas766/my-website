import { Injectable } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

import { Article } from '../shared/models/article.model';


@Injectable()
export class SharedService {
     constructor(private http: HttpClient) {}

     getAllArticles() {
        return this.http.get('/api/blog/all').toPromise() as Promise<Article[]>;
    }
    
    getArticleBySlug(slug: string) {
        return this.http.get('/api/blog/article/' + slug).toPromise() as Promise<Article>;
    }
}
