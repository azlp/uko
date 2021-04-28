import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Resourse } from '../../models/resourse';
import { ResoursesService } from '../../services/resourse.service';
import { HttpClient, HttpParams, HttpRequest, HttpEvent, HttpHandler } from '@angular/common/http';
import { Cookie } from "ng2-cookies/ng2-cookies";
import { ColorEvent } from 'ngx-color';



@Component({
    selector: 'specificationedit',
    templateUrl: './specificationedit.component.html',
    styleUrls: ['./specificationedit.component.css']
})
export class SpecificationEditComponent {

    public newresourse = new Resourse();

    public im: HTMLImageElement;

    public colors: string[] = [];

    public color: any;

    public cmykColor: any;

    typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];
    data;
    public url = '';

    constructor(private _resourseService: ResoursesService, private http: HttpClient, public domSanitizer: DomSanitizer) {

        
    } 

    set(flag: string) {



        this.newresourse.code = flag;


    }

    specification(newresourse)
    {

        this.im = <HTMLImageElement>document.getElementById("sourseimg");

        this.newresourse.resourceId = Cookie.get("resourseeditid");

        this.newresourse.photo_sourse = this.im.src;

        this.newresourse.colorlistoffresourse = this.returColorsAsSting();

       
        
        this._resourseService.addResourseSpecification(this.newresourse).subscribe(result => { console.log(result) });

        
    }

    ngOnInit() {


        

        var resourseId = Cookie.get("resourseeditid")

      
       
        this._resourseService.getResourseInfo(resourseId).subscribe(result => {

            this.data = result.json() as Resourse;

            

            this.newresourse.photo_sourse = result.json()["image"];

            this.newresourse.name = result.json()["name"];

            this.newresourse.number = result.json()["number"];

            this.newresourse.argo = result.json()["argo"];

            this.newresourse.developer = result.json()["developer"];

            this.newresourse.units = result.json()["units"];

            this.newresourse.with = result.json()["with"];


            this.newresourse.lenght = result.json()["lenght"];

            this.newresourse.height = result.json()["height"];

            this.newresourse.colorlistoffresourse = result.json()["color"];

          

            this.convertColorsToArryay(result.json()["color"]);


            this.newresourse.deffects = result.json()["deffects"];



            this.url = '';

            //show image on form
            this.url = this.newresourse.photo_sourse;


            this.newresourse.comment = result.json()["comment"];

            this.newresourse.weight = result.json()["wieight"];
            
            
        }
        );

    }

   

    fileChange(event:any){

        const fileList: FileList = event.target.files;

        if (event.target.files && event.target.files[0]) {

            var reader = new FileReader();



            reader.onload = (event: any) => {

                this.url = event.target.result;

                this._resourseService.uploadImage(event.target.result, Cookie.get("resourseeditid")).subscribe(result => { console.log(result) });

            }

            reader.readAsDataURL(event.target.files[0]);



        }
        
    }


    //удаление цвета из цветовой гаммы описания ресурса
    removeColor(color:any)
    {
       
        /*получаем значение цвета из списка (color)
        и его индекс в массиве элементов colors*/
        const index: number = this.colors.indexOf(color);
        //если индекс не меньше нуля. Нумерация во всех массивах от нуля
        if (index !== -1)
        {
           //вызываем функцию удаления элемента из массива 
            this.colors.splice(index,1);
        }

        
    }

    onChangeColor($event) {


        this.colors.push($event);

        
    }

    // выводим на форму все цвета ресурса
    convertColorsToArryay(_colorstring: string)
    {
     
        this.colors = _colorstring.split(",");

     
    }

    returColorsAsSting() : string
    {
        var str = '';

        if (this.colors.length != 0)
        {
            //for (let color in this.colors)
            //for (let i = 0; i < this.colors.length; i++) 
            for (var color of this.colors)
            {
                //console.log(this.colors[i]);
                //str += "" + this.colors[i] + ", ";
                str += "" + color + " ,";

            }
        }

      

        return str;
    }

}
