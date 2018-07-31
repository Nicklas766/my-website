import { BrowserModule }    from '@angular/platform-browser';
import { NgModule }         from '@angular/core';
import { FormsModule }      from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, CanActivate }     from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



// NPM
import { MarkdownModule } from 'angular2-markdown';

// Components, ALPHABETICAL ORDER
import { AppComponent } from './app.component';
import { AlertMessageComponent } from './shared/components/alert-message/alert-message.component';
import { LoginFormComponent } from './modules/admin/components/login-form/login-form.component';
import { SubmitFormComponent } from './modules/admin/components/submit-form/submit-form.component';
import { SwipeContainerComponent } from './shared/components/swipe-component/swipe.component';
import { SwipeChildComponent } from './shared/components/swipe-component/swipeChild.component';

// Page Components, ALPHABETICAL ORDER
import { AboutComponent } from './modules/about/pages/about.component';
import { AdminComponent } from './modules/admin/pages/admin.component';
import { AdminDashboardComponent } from './modules/admin/pages/dashboard.component';
import { ArticlesComponent } from './modules/articles/pages/articles.component';
import { ArticleComponent } from './modules/articles/pages/article.component';
import { HomeComponent }  from './modules/home/home.component';
import { LinksComponent }  from './modules/links/links.component';
import { ProjectsComponent }  from './modules/projects/projects.component';

// Services, ALPHABETICAL
import { AdminService }   from './modules/admin/admin.service';
import { AdminAuthGuard }   from './shared/AdminAuthGuard.service';
import { SharedService }   from './shared/shared.service';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    AdminComponent,
    AdminDashboardComponent,
    AlertMessageComponent,
    ArticlesComponent,
    ArticleComponent,
    HomeComponent,
    LinksComponent,
    LoginFormComponent,
    ProjectsComponent,
    SubmitFormComponent,
    SwipeContainerComponent,
    SwipeChildComponent
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MarkdownModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent },
      { path: 'admin', component: AdminComponent },
      { canActivate: [AdminAuthGuard], path: 'admin/dashboard', component: AdminDashboardComponent },
      { path: 'articles', component: ArticlesComponent },
      { path: 'article/:slug', component: ArticleComponent },
      { path: 'projects', component: ProjectsComponent },
      { path: 'links', component: LinksComponent },
    ])
  ],
    providers: [
        AdminService,
        AdminAuthGuard,
        SharedService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
