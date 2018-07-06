import { Component } from '@angular/core';

import { AdminService } from '../admin.service';
import { SharedService } from '../../../shared/shared.service';
import { Article } from '../../../shared/models/article.model';

@Component({
    selector: 'app-login',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.scss']
})
/** admin component*/
export class LoginComponent {
    /** admin ctor */
  constructor(private sharedService: SharedService) { }


}
