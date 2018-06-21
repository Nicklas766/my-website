import { Component } from '@angular/core';

import { AdminService } from '../services/my.service';

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
    public loading: true;

    ngOnInit(): void {

        this.adminService.getAllBlogPosts().then(res => {

            this.blogPosts = res;
            this.loading = false;
        });
        this.adminService.getBlogPost("slug").then(res => console.log(res));
      
  }
}
