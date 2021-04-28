import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { map } from "rxjs/operators";


@Injectable()
export class UKOService {

    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;

    }

    addNewUko(newuko) {

       
        let body = JSON.stringify({

            "Name": newuko.name,
            "SecondName": newuko.secondname,
            "FathersName": newuko.familiname,
            "Date": newuko.dateoffbirth,
            "Photo": newuko.photo,
            "Type": newuko.type,
            //для отладки дефолт 
            "Comment": "физлицо"


        });

       

        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/AddNewUko', body, options)

            .catch(this.errorHandler);
    }

    updateUkoName(newuko) {

       

        let body = JSON.stringify({

            "Name": newuko.name,
            "SecondName": newuko.secondname,
            "FathersName": newuko.familiname,
            "Date": newuko.dateoffbirth,
            "Photo": newuko.photo,
            "Type": newuko.type,
            "NickName": newuko.nickname,
            "ID": newuko.id,
            "Comment": "физлицо"


        });



        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/UpdateUkoName', body, options)

            .catch(this.errorHandler);
    }


    addNewUkoJur(newuko: any) {

        let body = JSON.stringify({

            "Name": newuko.name,
            "SecondName": newuko.jurname,
            "INN": newuko.inn,
            "Type": newuko.type,
            "Comment": "юрлицо"


        });

        


        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/AddNewUkoJur', body, options)

            .catch(this.errorHandler);
    }

    updateNewUkoJur(newuko: any) {

       

        let body = JSON.stringify({

            "Name": newuko.name,
            "JurName": newuko.jurname,
            "INN": newuko.inn,
            "Type": newuko.type,
            "Comment": newuko.comment,
            "ID": newuko.id,


        });




        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/UpdateUkoJur', body, options)

            .catch(this.errorHandler);
    }

    addAdressUko(newadress: any) {

        

        let body = JSON.stringify({

            "Type": newadress.adresstype,
            "Id": newadress.ukoid,
            "Index": newadress.index,
            "City": newadress.city,
            "Street": newadress.street,
            "HouseNumber": newadress.housenumber,
            "BuildingCode": newadress.blockcode,
            "Block": newadress.block,
            "Flat": newadress.flat,
            "Floor": newadress.floor,
            "Entrance": newadress.entrance,
            "Comment": newadress.comment,
            

        });

     
        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/AddNewUkoAdress', body, options)

            .catch(this.errorHandler);
    }

    getAdressesList(ukoid: any) {

        let body = JSON.stringify({

            "Id": ukoid

        });




        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/GetListOffAdress', body, options)

            .catch(this.errorHandler);
    }

    addNewDocsUko(newdocs) {

       
        let body = JSON.stringify({

            "Id": newdocs.ucoid,
            "Name": newdocs.docname,
            "File": newdocs.docbody,
           
           

        });

        


        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/AddNewDocsOffUko', body, options)

            .catch(this.errorHandler);
    }

    getlistOffAllUko()
    {
        return this._http.get(this.myAppUrl + 'api/UKO/GetListOfAllUKO')
           

            .catch(this.errorHandler);
    }

    getListOffDocsUko(ukoid: any) {

        let body = JSON.stringify({

            "Id": ukoid
          

        });




        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/GetListOffDocs', body, options)

            .catch(this.errorHandler);
    }

    getPersonalUkoInfo(ukoid: any) {

        let body = JSON.stringify({

            "Id": ukoid


        });




        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/GetPersonalUkoInfo', body, options)

            .catch(this.errorHandler);
    }

    getBuisinessEntityUkoInfo(ukoid: any) {

        let body = JSON.stringify({

            "Id": ukoid


        });




        const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        const options = new RequestOptions({ headers: headers });

        return this._http.post(this.myAppUrl + 'api/UKO/GetBuisinessEntityUkoInfo', body, options)

            .catch(this.errorHandler);
    }

    

    //errors handlers 
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}