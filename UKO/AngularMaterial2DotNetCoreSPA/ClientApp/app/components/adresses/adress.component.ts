import { Component, Inject, OnInit, ViewChild, NgModule} from '@angular/core';
import { Http } from '@angular/http';
//import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator, MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MatSort } from '@angular/material/sort';
import { MatDividerModule, MatDivider } from '@angular/material/divider';
import { Router, ActivatedRoute } from '@angular/router';
import { ResoursesService } from '../../services/resourse.service';
import { Resourse } from '../../models/resourse';
import { Cookie } from "ng2-cookies/ng2-cookies";
import { Adress } from '../../models/adress';
import { UKOService } from '../../services/uko.service';
import { DatePipe } from '@angular/common';






@Component({
    selector: 'adress',
    templateUrl: './adress.component.html',
    styleUrls: ['./adress.component.css']
    
})
export class AdressComponent implements OnInit {

    public displayedColumns: string[] = ['ukoName', 'city', 'id', 'adressTotal','adressType'];
    dataSource;
    data;
   
    public fio: string;

    myDate = new Date();

    public doFilter = (value: string) => {
        this.dataSource.filter = value.trim().toLocaleLowerCase();
    }

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

   

    constructor(private _ukoService: UKOService, private _router: Router, public dialog: MatDialog)
    {}

    ngOnInit() {

       
        this._ukoService.getAdressesList(Cookie.get("ukoid")).subscribe(result => {

            this.data = result.json() as Adress[];
            //receiving and bunding data from controller to table 
            this.dataSource = new MatTableDataSource(this.data);

            console.log(result.json());

            this.dataSource.paginator = this.paginator;

            this.dataSource.sort = this.sort;

            
        }
        );

        //чтобы видеть на форме имя уко
        this.fio = Cookie.get("ukoname");

    }

    
    add()
    {
        this._router.navigateByUrl('/home');
    }

    redirectToDetails(resourceId)
    {
       

        Cookie.set("resourseeditid", resourceId);

        this._router.navigateByUrl('/specificationedit');
    }

    redirectToRezerv(resourceId)
    {
        

        Cookie.set("resourseeditid", resourceId);

        this._router.navigateByUrl('/booking');

    }

    openDialog() {

        const dialogRef = this.dialog.open(AddadressComponent, {
            data: {
               
            }
        });


        dialogRef.afterClosed().subscribe(
            result => {

                
               
                this.addRowData(result);
            }
        );
    }

    addRowData(result) {
        // Добавляем новую строку в таблицу. 
        const oldData = this.dataSource.data;

        console.log(result);
        
        oldData.push({

          

            ukoName: Cookie.get("ukoname"),
            city: result.city,
            id: result.ukoid,
            adressTotal: result.index + "  " + result.city + "  " + result.street + "  " + result.housenumber + " " + result.block + " " + result.floor + " "
            + result.flat + " " + result.entrance,
            adressType: result.adresstype,


        });

        this.dataSource.data = oldData;

    }

    setAdressType()
    {

    }
}

@Component({
    selector: 'addadress',
    templateUrl: 'addadress.html',
    styleUrls: ['./adress.component.css'],
    providers: [DatePipe]
})



export class AddadressComponent {
    constructor(private _ukoService: UKOService, @Inject(MAT_DIALOG_DATA) public newadress: Adress, public dialogRef: MatDialogRef<Adress>, private datePipe: DatePipe) { }


    //myDate = new Date();

    addAdress(newadress)
    {
        this.newadress.ukoid = Cookie.get("ukoid");

    
        this.newadress.comment = "comment null";

            //this.datePipe.transform(this.myDate, 'yyyy-MM-dd').toDateString();

        this._ukoService.addAdressUko(this.newadress).subscribe(

            result => {

                //тут получаем из body ответа json, чтобы вытянуть ид уко
                //let resSTR = JSON.stringify(result);
                //let resJSON = JSON.parse(resSTR);
                

                //Cookie.set("ukoid", resJSON._body);


            });



        this.dialogRef.close(this.newadress);
        
    }

    set(flag: string) {


        this.newadress.adresstype = flag;




    }
}




