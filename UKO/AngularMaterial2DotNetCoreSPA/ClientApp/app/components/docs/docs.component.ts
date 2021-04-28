import { Component, Inject, OnInit, ViewChild, NgModule, Optional } from '@angular/core';
import { Http } from '@angular/http';
import { MatPaginator, MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MatSort } from '@angular/material/sort';
import { MatDividerModule, MatDivider } from '@angular/material/divider';
import { Router, ActivatedRoute } from '@angular/router';
import { ResoursesService } from '../../services/resourse.service';
import { UKOService } from '../../services/uko.service';
import { Resourse } from '../../models/resourse';
import { Documents } from '../../models/documents';
import { Adress } from '../../models/adress';
import { Cookie } from "ng2-cookies/ng2-cookies";
import { ComponentPortal } from '@angular/cdk/portal';







@Component({
    selector: 'docs',
    templateUrl: './docs.component.html',
    styleUrls: ['../css/style.css']
})
export class DocsComponent implements OnInit {

    public displayedColumns: string[] = ['ukoName', 'name', 'id', 'file'];

    dataSource;

    data;
   
    public fio: string;

    public resourses: Resourse[];

    

    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    }

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

   

    constructor(private _resourseService: ResoursesService, public _ukoService: UKOService, private _router: Router, public dialog: MatDialog)
    {}

    ngOnInit() {

        //получаем весь список уко. Ещё раз в словаре. УКо -участник корпоративных отношений. Если есть вопросы в словарь.;
        this._ukoService.getListOffDocsUko(Cookie.get("ukoid")).subscribe(result => {

            this.data = result.json() as Documents[];
            //receiving and binding data from controller to table 
            this.dataSource = new MatTableDataSource(this.data);
          
            this.dataSource.paginator = this.paginator;

            this.dataSource.sort = this.sort;
            
        }
        );

        //чтобы видеть на форме имя уко
        this.fio = Cookie.get("ukoname");

    }

    showfullsize($event,imageurl)    
    {
       
        const dialogRef = this.dialog.open(DocsFullsizeComponent, {
            //passing image to popup form DocsFullsizeComponent
            data:imageurl
        });
    }
    

   

    openDialog(flag:any) {

        const dialogRef = this.dialog.open(AddDocsComponent, {

            data: flag
           
        });


        dialogRef.afterClosed().subscribe(
            result => {

                

                if (result.docname)
                    {
                this.addRowData(result);

                }
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
    selector: 'adddoc',
    templateUrl: 'adddoc.html',
    styleUrls: ['../css/style.css']
})



export class AddDocsComponent {

    url = '';
   
    public newdocs = new Documents();

    typeoffdoc: number;

   
    constructor(public _ukoService: UKOService, public dialogRef: MatDialogRef<Documents>,
        @Optional() @Inject(MAT_DIALOG_DATA) public flag: any) {

      
        this.typeoffdoc = flag; 

        this.newdocs.docname = this.flag;
        
     
    }

    fileChange(event: any) {

        const fileList: FileList = event.target.files;

        if (event.target.files && event.target.files[0]) {

            var reader = new FileReader();

            reader.readAsDataURL(event.target.files[0]);

            reader.onload = (event: any) => {

                this.url = event.target.result;

                this.newdocs.docbody = this.url;
                
            }

           
            
        }


    }

    addDoc(newdocs)
    {
       
        this.newdocs.ucoid = Cookie.get("ukoid");

     

        this._ukoService.addNewDocsUko(newdocs).subscribe(result => {

         

        }
        );


        this.dialogRef.close(this.newdocs);
        
    }

    
}

@Component({
    selector: 'docsfullsize',
    templateUrl: 'docsfullsize.html',
    styleUrls: ['../css/style.css']
})



export class DocsFullsizeComponent implements OnInit {

    url = '';

    

    public newdocs = new Documents();

    constructor(
        public dialogRef: MatDialogRef<DocsFullsizeComponent>,
        //@Optional() is used to prevent error if no data is passed
        @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {
      
        this.url = this.data;

       
       
      
    }
    


}




