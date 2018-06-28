import { Injectable } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

import {AcceptableBody} from "./AcceptableBody.model";

@Injectable()
export class AdminService {
     constructor(private http: HttpClient) {}

    postCreateArticle(body: AcceptableBody): Promise<AcceptableBody> {
        return this.http.post('/api/blog/create', body).toPromise() as Promise<AcceptableBody>;
    }

    putUpdateArticle(body: AcceptableBody): Promise<AcceptableBody> {
        return this.http.put('/api/blog/update', body).toPromise() as Promise<AcceptableBody>;
    }

    putDeleteArticle(id: number) {
        return this.http.delete('/api/blog/delete?id=' + id).toPromise();
    }
}
