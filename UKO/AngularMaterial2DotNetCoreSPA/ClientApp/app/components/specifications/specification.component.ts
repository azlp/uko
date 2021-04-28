import { Component } from '@angular/core';
import { Resourse } from '../../models/resourse';
import { ResoursesService } from '../../services/resourse.service';
import { HttpClient, HttpParams, HttpRequest, HttpEvent, HttpHandler } from '@angular/common/http';
import { Cookie } from "ng2-cookies/ng2-cookies";
import { ColorEvent } from 'ngx-color';



@Component({
    selector: 'specification',
    templateUrl: './specification.component.html',
    styleUrls: ['./specification.component.css']
})
export class SpecificationComponent {

    public newresourse = new Resourse();

    public color: any;

    public cmykColor: any;

    public im: HTMLImageElement;

    public colors: string[] = [];

    typesOfShoes: string[] = ['Boots', 'Clogs', 'Loafers', 'Moccasins', 'Sneakers'];

    url = '';

    constructor(private _resourseService: ResoursesService, private http: HttpClient) {

        
    } 

    set(flag: string) {



        this.newresourse.code = flag;


    }

    specification(newresourse)
    {

      
        this.im = <HTMLImageElement>document.getElementById("sourseimg");

        this.newresourse.resourceId = Cookie.get("resourseid");

        this.newresourse.photo_sourse = this.im.src;

        this.newresourse.colorlistoffresourse = this.returColorsAsSting();

      

        this._resourseService.addResourseSpecification(this.newresourse).subscribe(result => { console.log(result) });

        
    }

    fileChange(event:any){

        const fileList: FileList = event.target.files;

        if (event.target.files && event.target.files[0]) {

            var reader = new FileReader();

           

            reader.onload = (event: any) => {

                this.url = event.target.result;

                this._resourseService.uploadImage(event.target.result, Cookie.get("resourseid")).subscribe(result => { console.log(result) });
               
            }

            reader.readAsDataURL(event.target.files[0]); 

          

        }
        
    }

    //удаление цвета из цветовой гаммы описания ресурса
    removeColor(color: any) {

        /*получаем значение цвета из списка (color)
        и его индекс в массиве элементов colors*/
        const index: number = this.colors.indexOf(color);
        //если индекс не меньше нуля. Нумерация во всех массивах от нуля
        if (index !== -1) {
            //вызываем функцию удаления элемента из массива 
            this.colors.splice(index, 1);
        }

    }

    onChangeColor($event) {


        this.colors.push($event);

        
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
