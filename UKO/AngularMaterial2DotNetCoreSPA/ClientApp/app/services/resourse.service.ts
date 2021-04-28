import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
//import { map } from "rxjs/operator/map";
import { map } from "rxjs/operators";


@Injectable()
export class ResoursesService {


    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;

    } 

    addNewResourse(newresourse:any) {

        let body = JSON.stringify({

            "Name": newresourse.name,
            "Code": newresourse.code,
            "Count": newresourse.count,
   
        });

        

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/AddNewResourse', body, options)

            .catch(this.errorHandler);
    }

    uploadImage(file:any, resourseId:string) {

        
        let body = JSON.stringify({

            "Image": file,
            "ResourceId": resourseId,
           

        });

       

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

       return this._http.post(this.myAppUrl + 'api/Data/UploadImage',body , options)

            .catch(this.errorHandler);
    }


    coountResrouse(newresourse: any) {

        let body = JSON.stringify({

            "ResourceId": newresourse.resourceId,
            "Total": newresourse.total

        });

        

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/CountOffResourse', body, options)

            .catch(this.errorHandler);
    }


    addResourseSpecification(newresourse: any) {

        
        let body = JSON.stringify({

            "Name": newresourse.name,
            "ResourceId": newresourse.resourceId,
            "Image": newresourse.photo_sourse,
            "Code": newresourse.number,
            "Argo": newresourse.argo,
            "Developer": newresourse.developer,
            "Units": newresourse.units,
            "Wieight": newresourse.weight,
            "Lenght": newresourse.lenght,
            "With": newresourse.with,
            "Height": newresourse.height,
            "Color": newresourse.colorlistoffresourse,
            "Deffects": newresourse.deffects,
            "Comment": newresourse.comment,
  
        });


        
       

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });

        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/AddResourseSpecification', body, options)

            .catch(this.errorHandler);
    }

    getResoursesListForAddToUko()
    {

       
        
        return this._http.get(this.myAppUrl + 'api/Data/GetResoursesList')
          

                .catch(this.errorHandler);
        
    }

    getResourseInfo(resourseId: any) {


       

        let body = JSON.stringify({

         
            "ResourceId": resourseId,
           

        });

       
       
        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });

        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/GetResourseInfo', body, options)

            .catch(this.errorHandler);

    }


    //resourse owner set delete get list of resourses which have uko
    addResourseToUko(resourseId: any, ukoId: any) {

        

        let body = JSON.stringify({


            "ResourceId": resourseId,
            "Argo": ukoId,


        });

       

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });

        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/AddResoursesToUko', body, options)

            .catch(this.errorHandler);

    }

    //get list of uko resourses
    GetListResoursesOfUko(ukoId: any) {

        let body = JSON.stringify({

            "Id": ukoId,

        });

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });

        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/GetListResoursesOfUko', body, options)

            .catch(this.errorHandler);

    }

    deleteResourseFromUko(resourseId: any, ukoId: any) {



        let body = JSON.stringify({


            "ResourceId": resourseId,
            "Argo": ukoId,


        });



        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });

        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/Data/DeleteResoursesFromUko', body, options)

            .catch(this.errorHandler);

    }


    //resourse owner set delete get list of resourses which have uko


    //errors handlers 
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}