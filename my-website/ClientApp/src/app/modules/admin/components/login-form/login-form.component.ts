import { Component, OnInit, Input } from '@angular/core';

import { AdminService } from '../../admin.service'

@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.scss']
})
/** Login-Form component*/
export class LoginFormComponent {
    /** Login-Form ctor */

    public username: string;
    public password: string;
    
    constructor(private adminService: AdminService) {}

    loginAsAdmin() {
        this.adminService.postLoginAsAdmin({
            username: this.username,
            password: this.password
        }).then(res => {

            console.log("logged")

        }).catch(err => {

            if (err.status == 404) {
                console.log("failed login");
            }
            console.log(err)
        });  
    }
}
