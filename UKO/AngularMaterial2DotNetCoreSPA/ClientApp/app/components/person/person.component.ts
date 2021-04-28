import { Component } from '@angular/core';
import { Resourse } from '../../models/resourse';
import { UKO } from '../../models/uko';
import { UKOService } from '../../services/uko.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Cookie } from "ng2-cookies/ng2-cookies";
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { NativeDateAdapter } from '@angular/material';


@Component({
    selector: 'person',
    templateUrl: './person.component.html',
    styleUrls: ['./person.component.css']
})
export class PersonComponent {

    //public newresourse = new Resourse();


    public newuko = new UKO();

    url = '';

    constructor(private _ukoService: UKOService, private _router: Router) {

        
    } 

    //set(flag:string) {



    //    this.newresourse.code = flag;


    //}

    add(newuco:any)
    {
        this.newuko.type = 0;

        this.newuko.photo = this.url;

        this._ukoService.addNewUko(newuco).subscribe(

            result => {

                //тут получаем из body ответа json, чтобы вытянуть ид уко
                let resSTR = JSON.stringify(result);
                let resJSON = JSON.parse(resSTR);

              
                Cookie.set("ukoid", resJSON._body);

                
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
