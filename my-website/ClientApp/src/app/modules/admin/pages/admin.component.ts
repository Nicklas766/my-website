import { Component } from '@angular/core';

import { AdminService } from '../admin.service';

@Component({
    selector: 'app-admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.scss']
})
/** admin component*/
export class AdminComponent {
    /** admin ctor */
  constructor(private adminService: AdminService) {

  }
    public blogPosts: any;
    public loading: boolean = false;

    ngOnInit(): void {

        this.adminService.getAllBlogPosts().then(res => {

            this.blogPosts = res;
            this.loading = false;
        });
        this.adminService.getBlogPostBySlug("slug").then(res => console.log(res));
      
  }
}
