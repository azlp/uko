import { Component, Inject, OnInit, ViewChild, NgModule} from '@angular/core';
import { Http } from '@angular/http';
//import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator, MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MatSort } from '@angular/material/sort';
import { MatDividerModule, MatDivider } from '@angular/material/divider';
import { Router, ActivatedRoute } from '@angular/router';
import { ResoursesService } from '../../services/resourse.service';
import { UKOService } from '../../services/uko.service';
import { Resourse } from '../../models/resourse';
import { Cookie } from "ng2-cookies/ng2-cookies";


export interface DialogData {
    filters: 'rezerv' | 'free' | 'problem';
}





@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    styleUrls: ['./fetchdata.component.css']
})
export class FetchDataComponent implements OnInit {

    public displayedColumns: string[] = ['name', 'id', 'comment'];
    dataSource;
    data;
   
    public resourses: Resourse[];

    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    }

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

   

    constructor(private _ukoService: UKOService, private _router: Router, public dialog: MatDialog)
    {}

    ngOnInit() {

        //чтобы выводить весь список адресов или документов когда переход был по меню, а не черз опцию редактирования Уко
        Cookie.set("ukoid", '0');

        // get all uko ();
        this._ukoService.getlistOffAllUko().subscribe(result => {

            this.data = result.json() as Resourse[];
            //receiving and bunding data from controller to table 
            this.dataSource = new MatTableDataSource(this.data);
            
            this.dataSource.paginator = this.paginator;

            this.dataSource.sort = this.sort;

            
        }
        );

    }

    
    add()
    {
        this._router.navigateByUrl('/home');
    }

    redirectToDetails(resourceId,type,name)
    {
        //в зависимости от типа уко переходим к редактированию его свойств в специальной форме
       
        var tmp = type;

        Cookie.set("ukoname",name);

        switch (tmp)
        {
            case 'физ.лицо':
                {
                    Cookie.set("ukoid", resourceId);

                    
                    this._router.navigateByUrl('/personedit');

                    break;

                }

            case 'юр.лицо':
                {
                    Cookie.set("ukoid", resourceId);

                    this._router.navigateByUrl('/orgsedit');

                    break;
                }

            default: {

                Cookie.set("ukoid", resourceId);

               

                break;
            }
        }

        

       
    }

    redirectToRezerv(resourceId)
    {
        

        Cookie.set("resourseeditid", resourceId);

        this._router.navigateByUrl('/booking');



        //booking
    }

    openDialog() {
        this.dialog.open(FilterComponent, {
            data: {
                filters: 'rezerv'
            }
        });
    }
   
}

@Component({
    selector: 'filter',
    templateUrl: 'filter.html',
})



export class FilterComponent {
    constructor( @Inject(MAT_DIALOG_DATA)  public data: DialogData) { }
}




