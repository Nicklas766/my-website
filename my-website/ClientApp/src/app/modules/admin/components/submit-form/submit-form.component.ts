import { Component, OnInit, Input } from '@angular/core';

import { AdminService } from '../../admin.service'
import {AcceptableBody} from "../../AcceptableBody.model";
@Component({
    selector: 'app-submit-form',
    templateUrl: './submit-form.component.html',
    styleUrls: ['./submit-form.component.scss']
})
/** SubmitForm component*/
export class SubmitFormComponent {
    /** SubmitForm ctor */
    @Input() article: AcceptableBody;
    newArticle: boolean = false;

    constructor(private adminService: AdminService) {}

    updateArticle() {
        this.adminService.putUpdateArticle(this.article).then(res => {
            this.article = res;
        });  
    }
    createArticle() {
        this.adminService.postCreateArticle(this.article).then(res => {
            this.article = res;
        });  
    }
    deleteArticle() {
        this.adminService.putDeleteArticle(this.article.id).then(res => console.log(res));  
    }
}