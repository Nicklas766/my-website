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
    public showAlertMessage: boolean = true;
    public alertType: string = "info"
    public alertText: string = "Hi! This is the admin page, just so you know.";
    
    constructor(private adminService: AdminService) {}

    setAndShowAlertMessage(type, text) {
        this.showAlertMessage = true;
        this.alertType = type;
        this.alertText = text;
    }
    
    loginAsAdmin() {
        this.adminService.postLoginAsAdmin({
            username: this.username,
            password: this.password
        })
        .then(res => this.setAndShowAlertMessage("success", "You have logged in!"))
        .catch(err => this.setAndShowAlertMessage("error", "Login failed, you probably shouldn't be here..."));  
    }
}
