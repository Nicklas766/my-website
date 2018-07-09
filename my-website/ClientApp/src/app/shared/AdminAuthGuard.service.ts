import { Injectable } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { RouterModule, CanActivate, Router } from '@angular/router';



@Injectable()
export class AdminAuthGuard implements CanActivate {
    constructor(
        private http: HttpClient,
        private router: Router,
    ) {}

    private isLoggedIn: boolean = false;

    redirectIfLogged() {
        this.http.get('/api/admin/isLoggedAsAdmin').toPromise()
        .then(res => {
            this.login();
            this.router.navigate(['/admin/dashboard']);
        })
        .catch(err => console.log("Admin is not logged!"));
    }

    
     login(): void {
         this.isLoggedIn = true;
     }

     logout(): void {
        this.http.get('/api/admin/logout').toPromise()
        .then(res => {
            this.isLoggedIn = false;
            this.router.navigate(['/admin']);
        })
        .catch(err => console.log(err));  
    }

     canActivate() {
        return this.isLoggedIn;
    }
}
