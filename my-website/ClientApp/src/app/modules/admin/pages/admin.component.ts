import { Component } from '@angular/core';

import { AdminService } from '../admin.service';
import { SharedService } from '../../../shared/shared.service';

@Component({
    selector: 'app-admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.scss']
})
/** admin component*/
export class AdminComponent {
    /** admin ctor */
  constructor(
      private adminService: AdminService,
      private sharedService: SharedService
    ) {

  }
    public blogPosts: any;
    public loading: boolean = true;
    public currentBlogPost: object;

    ngOnInit(): void {
        this.sharedService.getAllArticles().then(res => {
            this.blogPosts = res;
            this.loading = false;
        });   
  }

  setCurrentBlogPost(currentBlogPost: object) {
        console.log(currentBlogPost)
        this.currentBlogPost = currentBlogPost;
  }
}
