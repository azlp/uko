import { NgModule } from '@angular/core';

import {
    MatSidenavModule,
    MatFormFieldModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatTableModule,
    MatSortModule,
    MatInputModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatDividerModule,
    MatListModule,
    MatDialogModule
   
  
} from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    imports: [
        MatSidenavModule,
        MatFormFieldModule,
        MatButtonModule,
        MatMenuModule,
        MatToolbarModule,
        MatIconModule,
        MatCardModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatPaginatorModule,
        MatCheckboxModule,
        MatDividerModule,
        MatListModule,
        MatDialogModule
        
    ],
    exports: [
        MatSidenavModule,
        MatFormFieldModule,
        MatButtonModule,
        MatMenuModule,
        MatToolbarModule,
        MatIconModule,
        MatCardModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatPaginatorModule,
        MatCheckboxModule,
        MatListModule,
        MatDialogModule
       
    ]
})
export class MaterialModule { }