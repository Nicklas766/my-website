import { Injectable } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

import { AcceptableBody, LoginBody } from "./admin.models";

@Injectable()
export class AdminService {
     constructor(private http: HttpClient) {}

    postLoginAsAdmin(body: LoginBody) {
        return this.http.post('/api/admin/login', body).toPromise()
    }

    postCreateArticle(body: AcceptableBody): Promise<AcceptableBody> {
        return this.http.post('/api/admin/create', body).toPromise() as Promise<AcceptableBody>;
    }

    putUpdateArticle(body: AcceptableBody): Promise<AcceptableBody> {
        return this.http.put('/api/admin/update', body).toPromise() as Promise<AcceptableBody>;
    }

    putDeleteArticle(id: number) {
        return this.http.delete('/api/admin/delete?id=' + id).toPromise();
    }
}
