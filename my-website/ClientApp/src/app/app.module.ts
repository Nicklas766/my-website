import { BrowserModule }    from '@angular/platform-browser';
import { NgModule }         from '@angular/core';
import { FormsModule }      from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule }     from '@angular/router';

// Components, ALPHABETICAL ORDER
import { AppComponent }   from './app.component';
import { SubmitFormComponent } from './modules/admin/components/submit-form/submit-form.component';

// Page Components, ALPHABETICAL ORDER
import { AboutComponent } from './modules/about/pages/about.component';
import { AdminComponent } from './modules/admin/pages/admin.component';
import { HomeComponent }  from './modules/home/home.component';

// Services, ALPHABETICAL
import { AdminService }   from './modules/admin/admin.service';

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,
    AdminComponent,
    HomeComponent,
    SubmitFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent },
      { path: 'admin', component: AdminComponent },
    ])
  ],
    providers: [
        AdminService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
