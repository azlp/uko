import { Component } from '@angular/core';
import { Resourse } from '../../models/resourse';
import { UKO } from '../../models/uko';
import { UKOService } from '../../services/uko.service';
import { ResoursesService } from '../../services/resourse.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Cookie } from "ng2-cookies/ng2-cookies";

@Component({
    selector: 'orgs',
    templateUrl: './orgs.component.html',
    styleUrls: ['./orgs.component.css']
})
export class OrgsComponent {

    public newuko = new UKO();

    constructor(private _ukoService: UKOService, private _router: Router) {

        
    } 

 
    add(newuco: any) {

        this.newuko.type = 1;

       

        this._ukoService.addNewUkoJur(newuco).subscribe(

            result => {

                //тут получаем из body ответа json, чтобы вытянуть ид уко
                let resSTR = JSON.stringify(result);
                let resJSON = JSON.parse(resSTR);


                Cookie.set("ukoid", resJSON._body);


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


        }

    }
}
