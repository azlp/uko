import { Component, OnInit } from '@angular/core';
import { Resourse } from '../../models/resourse';
import { UKO } from '../../models/uko';
import { UKOService } from '../../services/uko.service';
import { ResoursesService } from '../../services/resourse.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Cookie } from "ng2-cookies/ng2-cookies";

@Component({
    selector: 'orgsedit',
    templateUrl: './orgsedit.component.html',
    styleUrls: ['./orgsedit.component.css']
})
export class OrgsEditComponent implements OnInit {

    public newuko = new UKO();

    constructor(private _ukoService: UKOService, private _router: Router) {

        
    } 

    ngOnInit()
    {
        //Cookie.set("ukoid", resourceId);
        this._ukoService.getBuisinessEntityUkoInfo(Cookie.get("ukoid")).subscribe(result => {

          

            this.newuko.comment = result.json()["comment"];

            this.newuko.name = result.json()["name"];

            this.newuko.jurname = result.json()["jurName"];

            this.newuko.inn = result.json()["inn"];

        });
        
    }

 
    add(newuco: any) {

        this.newuko.type = 1;

        this.newuko.id = Cookie.get("ukoid");


       

        this._ukoService.updateNewUkoJur(newuco).subscribe(

            result => {
                
            });
    }

    goToPage(flag: any) {



        switch (flag) {

            case '0':
                {



                    this._router.navigateByUrl('/adress');

                    break;
                }

            case '1':
                {
                    this._router.navigateByUrl('/docs');

                    break;
                }

            case '2':
                {
                    this._router.navigateByUrl('/counter');

                    break;
                }


        }

    }
}
