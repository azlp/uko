import { Component, ViewChild, OnInit, Inject,NgModule, Optional } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { HttpClient, HttpParams, HttpRequest, HttpEvent, HttpHandler } from '@angular/common/http';
import { Resourse } from '../../models/resourse';
import { MatSort } from '@angular/material/sort';
import { ResoursesService } from '../../services/resourse.service';
import { Cookie } from "ng2-cookies/ng2-cookies";

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html',
    styleUrls: ['./counter.component.css']
})
export class CounterComponent implements OnInit {


    data;

    public fio: string;

    public resourses: Resourse[];

    

    public displayedColumns: string[] = ['name', 'resourceId'];

    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    }

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    dataSource;


    constructor(private _resourseService: ResoursesService, private http: HttpClient, public dialog: MatDialog) {


    } 


    ngOnInit() {

        //чтобы видеть на форме имя уко
        this.fio = Cookie.get("ukoname");

        this.getListOffUkoResourses();

    }

    getListOffUkoResourses()
    {
        this._resourseService.GetListResoursesOfUko(Cookie.get("ukoid")).subscribe(result => {

            this.data = result.json() as Resourse[];
            //receiving and bunding data from controller to table 
            this.dataSource = new MatTableDataSource(this.data);
            
            this.dataSource.paginator = this.paginator;

            this.dataSource.sort = this.sort;




        }
        );
    }

    addresourse() {


        const dialogRef = this.dialog.open(AddResourseComponent, {

        });

      

        dialogRef.afterClosed().subscribe(
            result => {

                

                this.getListOffUkoResourses();

             

            }
        );
    }

    delete(resourceId,name)
    {
        var resoursestodelete = new Resourse();

        resoursestodelete.name = name;

        resoursestodelete.ownername = Cookie.get("ukoname");

        resoursestodelete.resourceId = resourceId;

        resoursestodelete.ownerId = Cookie.get("ukoid");

        const dialogRef = this.dialog.open(DeleteResourseComponent, {

            data: resoursestodelete
        });



        dialogRef.afterClosed().subscribe(
            result => {


                this.getListOffUkoResourses();



            }
        );

    }

    addRowData(result) {
        // Добавляем новую строку в таблицу. 
        const oldData = this.dataSource.data;



        oldData.push({

            ukoName: Cookie.get("ukoname"),
            id: result.ucoid,
            name: result.docname,
            file: result.docbody,


        });

        this.dataSource.data = oldData;

    }
}

@Component({
    selector: 'addresourse',
    templateUrl: 'addresourse.html',
    styleUrls: ['./counter.component.css']
})
export class AddResourseComponent implements OnInit {

    public resoursecomplimentary = new Resourse();

    //data;

    dataSource;


    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    

    public doFilterResourses = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    }

    public displayedColumns: string[] = ['name', 'resourceId'];

    constructor(private _resourseService: ResoursesService, public dialogRef: MatDialogRef<AddResourseComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {

       

    }

    //

    ngOnInit() {


        //this.getAllResourses(); doFilterResourses($event.target.value)"
        this._resourseService.getResoursesListForAddToUko().subscribe(result => {

           
            this.data = result.json() as Resourse[];
            //receiving and bunding data from controller to table 
            this.dataSource = new MatTableDataSource(this.data);

            this.dataSource.paginator = this.paginator;

            this.dataSource.sort = this.sort;


        }
        );

    }

    setowner(resoursename,resourceId) {

        
        this.resoursecomplimentary.name = resoursename;

        this.resoursecomplimentary.resourceId = resourceId;
       
        this._resourseService.addResourseToUko(resourceId, Cookie.get("ukoid")).subscribe(result => { });

        // передаём ресурс из выпадающего меню на основную форму, чтобы добавить его в таблицу
      

    }

    ///////////booking operations  addResourseConditionAndOwner(resourserule: any) {

}

@Component({
    selector: 'deleteresourseconfirm',
    templateUrl: 'deleteresourseconfirm.html',
    styleUrls: ['./counter.component.css']
})
export class DeleteResourseComponent{

    public resoursedelete = new Resourse();


    constructor(private _resourseService: ResoursesService, 
        public dialogRef: MatDialogRef<DeleteResourseComponent>,
        //@Optional() is used to prevent error if no data is passed
        @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {

       
        this.resoursedelete.name = data["name"];

        this.resoursedelete.resourceId = data["resourceId"];

        this.resoursedelete.ownerId = data["ownerId"];

        this.resoursedelete.ownername = data["ownername"];


    }
    

    deleteResourse($event) {


         this._resourseService.deleteResourseFromUko(this.resoursedelete.resourceId, this.resoursedelete.ownerId).subscribe(result => {});
       
        //delete resourse from uko


    }


}



