import { Component } from '@angular/core';

import { AdminService } from '../admin.service';
import { SharedService } from '../../../shared/shared.service';
import { Article } from '../../../shared/models/article.model';
import { AdminAuthGuard }   from '../../../shared/AdminAuthGuard.service';

@Component({
    selector: 'app-admin-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
/** admin component*/
export class AdminDashboardComponent {
    /** admin ctor */
  constructor(
      private sharedService: SharedService,
      private adminAuthGuard: AdminAuthGuard
    ) { }

    public articles: Article[];
    public loading: boolean = true;
    public currentArticle: Article;
    public newArticle: Article;


    ngOnInit(): void {
        this.sharedService.getAllArticles().then(res => {
            this.articles = res;
            this.loading = false;
        });
      this.newArticle = new Article;
  }

  logout() {
    this.adminAuthGuard.logout();
  }

  setCurrentArticle(currentArticle: Article) {
        console.log(currentArticle)
        this.currentArticle = currentArticle;
  }
}
