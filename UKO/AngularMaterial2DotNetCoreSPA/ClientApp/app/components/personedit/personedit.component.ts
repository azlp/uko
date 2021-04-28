import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Resourse } from '../../models/resourse';
import { UKO } from '../../models/uko';
import { UKOService } from '../../services/uko.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Cookie } from "ng2-cookies/ng2-cookies";
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { NativeDateAdapter } from '@angular/material';


@Component({
    selector: 'personedit',
    templateUrl: './personedit.component.html',
    styleUrls: ['./personedit.component.css']
})
export class PersonEditComponent implements OnInit {

    //public newresourse = new Resourse();


    public newuko = new UKO();

    url = '';

    constructor(private _ukoService: UKOService, private _router: Router) {

        
    } 

    ngOnInit() {
        //Cookie.set("ukoid", resourceId);
        this._ukoService.getPersonalUkoInfo(Cookie.get("ukoid")).subscribe(result => {

            this.newuko.photo = result.json()["photo"];

            this.newuko.name = result.json()["name"];

            this.newuko.secondname = result.json()["secondName"];

            this.newuko.familiname = result.json()["fathersName"];

            this.newuko.nickname = result.json()["nickName"];

            this.newuko.dateoffbirth = result.json()["dateoffbirth"];

                //result.json()["date"];

            this.url = '';

            //show image on form this.newresourse.photo_sourse;
            this.url = this.newuko.photo;

           console.log(result.json());

        });

    }

    add(newuco:any)
    {
        this.newuko.type = 0;

        this.newuko.photo = this.url;

        this.newuko.id = Cookie.get("ukoid");

        this._ukoService.updateUkoName(newuco).subscribe(

            result => {

                ////тут получаем из body ответа json, чтобы вытянуть ид уко
                //let resSTR = JSON.stringify(result);
                //let resJSON = JSON.parse(resSTR);

              
                //Cookie.set("ukoid", resJSON._body);

                
            });
    }


    fileChange(event: any) {

        const fileList: FileList = event.target.files;

        if (event.target.files && event.target.files[0]) {

            var reader = new FileReader();



            reader.onload = (event: any) => {

                this.url = event.target.result;



            }

            reader.readAsDataURL(event.target.files[0]);



        }

    
    }

    setDate(event): void {

        this.newuko.dateoffbirth = event.toLocaleString()

       // console.log(event.toLocaleString());

        console.log(this.newuko.dateoffbirth);
    }

    goToPage(flag:any) {



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
