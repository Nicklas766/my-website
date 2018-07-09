import { Component, OnInit, Input } from '@angular/core';
import { Router } from "@angular/router";
import { AdminService } from '..//admin.service'
import { HttpClient } from '@angular/common/http';
import { AdminAuthGuard }   from '../../../shared/AdminAuthGuard.service';

@Component({
    selector: 'app-admin',
    template: '<app-login-form></app-login-form>'
})

export class AdminComponent {
 
    constructor(
        private adminService: AdminService, 
        private adminAuthGuard: AdminAuthGuard,
    ) {
        this.adminAuthGuard.redirectIfLogged();  
    }
}
