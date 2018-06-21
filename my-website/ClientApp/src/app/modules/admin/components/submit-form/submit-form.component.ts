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
    @Input() blogPost: AcceptableBody;
    newPost: boolean = false;

    constructor(private adminService: AdminService) {

    }

    updatePost() {
        this.adminService.putUpdateBlogPost(this.blogPost).then(res => {
            this.blogPost = res;
        });  
    }
    createPost() {
        this.adminService.postCreateBlogPost(this.blogPost).then(res => {
            this.blogPost = res;
        });  
    }
    deletePost() {
        this.adminService.putDeleteBlogPost(this.blogPost.id).then(res => console.log(res));  
    }
}