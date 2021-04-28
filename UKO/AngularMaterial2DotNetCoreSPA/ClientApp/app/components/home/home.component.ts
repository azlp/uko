import { Component } from '@angular/core';
import { Resourse } from '../../models/resourse';
import { UKO } from '../../models/uko';
import { ResoursesService } from '../../services/resourse.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Cookie } from "ng2-cookies/ng2-cookies";

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {

    public newresourse = new Resourse();

    public newuko = new UKO();

    constructor(private _resourseService: ResoursesService, private _router: Router) {

        
    } 

    set(flag:string) {


        this.newuko.entitytype = flag;

        


    }

    add()
    {
       

        
               
        switch (this.newuko.entitytype)
                {

                    case '0':
                        {
                            
                           

                            this._router.navigateByUrl('/person');

                            break;
                        }

                    case '1':
                        {
                            this._router.navigateByUrl('/orgs');

                            break;
                        }
                

                 }

          
    }

  

}
