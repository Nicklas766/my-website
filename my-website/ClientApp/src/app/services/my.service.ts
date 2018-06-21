import { Injectable } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class AdminService {
     constructor(private http: HttpClient) {}

    getAllBlogPosts() {
        return this.http.get('/api/blog/all').toPromise();
    }
     getBlogPost(slug: string) {
         return this.http.get('/api/blog/article/' + slug).toPromise();
        }
}
