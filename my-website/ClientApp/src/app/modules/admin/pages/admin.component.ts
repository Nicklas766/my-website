import { Component } from '@angular/core';

import { AdminService } from '../admin.service';
import { SharedService } from '../../../shared/shared.service';
import { Article } from '../../../shared/models/article.model';

@Component({
    selector: 'app-admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.scss']
})
/** admin component*/
export class AdminComponent {
    /** admin ctor */
  constructor(private sharedService: SharedService) { }

    public articles: Article[];
    public loading: boolean = true;
    public currentArticle: Article;

    ngOnInit(): void {
        this.sharedService.getAllArticles().then(res => {
            this.articles = res;
            this.loading = false;
        });   
  }

  setCurrentArticle(currentArticle: Article) {
        console.log(currentArticle)
        this.currentArticle = currentArticle;
  }
}
