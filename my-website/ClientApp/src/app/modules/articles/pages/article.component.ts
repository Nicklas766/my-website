import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SharedService } from '../../../shared/shared.service';
import { Article } from '../../../shared/models/article.model';

@Component({
    selector: 'app-article',
    templateUrl: './article.component.html',
    styleUrls: ['./articles.component.scss']
})
/** articles component*/
export class ArticleComponent {

    public loading: boolean = true;
    public article: Article;
    public error: boolean = false;
    public publishDateString: string;
    /** articles ctor */
    constructor(
        private route: ActivatedRoute,
        private sharedService: SharedService
    ) { }

    ngOnInit(): void {
        this.getArticle();
  }

  public async getArticle() {
    const slug: string = this.route.snapshot.paramMap.get('slug');
    const article = await this.sharedService.getArticleBySlug(slug);
    
    this.article = article;
    const date: Date = new Date(this.article.publishDate);
    this.publishDateString = date.getFullYear() + "-" + date.getMonth() + "-" + date.getDay(); 
    this.loading = false;
}
}