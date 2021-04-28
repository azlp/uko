/// <reference path="components/specificationsedit/specificationeidit.component.ts" />
/// <reference path="components/specificationsedit/specificationeidit.component.ts" />
/// <reference path="components/specifications/specification.component.ts" />

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material.module';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { SpecificationComponent } from './components/specifications/specification.component';
import { SpecificationEditComponent } from './components/specificationsedit/specificationeidit.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { MatConsumptionResourseComponent } from './components/matconsumptionresouse/matconsumptionresourse.component';
import { MatResourseComponent } from './components/matresourse/matresourse.component';
import { InfoResourseComponent } from './components/information/inforesourse.component';
import { OrgResourseComponent } from './components/orgres/orgresourse.component';
import { SkillResourseComponent } from './components/skill/skill.component';
import { BrainResourseComponent } from './components/brainresourse/brain.component';
import { SocialResourseComponent } from './components/sociallinq/social.component';
import { InstituteResourseComponent } from './components/institute/institute.component';
import { AdvertisingResourseComponent } from './components/advertising/advertising.component';
import { FeedbackResourseComponent } from './components/feedback/feedback.component';
import { ResoursesService } from './services/resourse.service';
import { UKOService } from './services/uko.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Cookie } from 'ng2-cookies/ng2-cookies';
import { ColorPickerModule } from 'ngx-color-picker';
import { MatDialog, MatDatepicker, MatDatepickerModule, MatNativeDateModule} from '@angular/material';
import { FilterComponent } from '../app/components/fetchdata/fetchdata.component';
import { OrgsComponent } from '../app/components/org/orgs.component';
import { PersonComponent } from '../app/components/person/person.component';
import { DocsComponent } from '../app/components/docs/docs.component';
import { DocsFullsizeComponent } from '../app/components/docs/docs.component';
import { AdressComponent } from '../app/components/adresses/adress.component';
import { AddadressComponent } from '../app/components/adresses/adress.component';
import { AddDocsComponent } from '../app/components/docs/docs.component';
import { PersonEditComponent } from '../app/components/personedit/personedit.component';
import { OrgsEditComponent } from '../app/components/orgsedit/orgsedit.component';
import { AddResourseComponent } from '../app/components/counter/counter.component';
import { DeleteResourseComponent  } from '../app/components/counter/counter.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        SpecificationComponent,
        SpecificationEditComponent,
        HomeComponent,
        MatConsumptionResourseComponent,
        MatResourseComponent,
        InfoResourseComponent,
        OrgResourseComponent,
        SkillResourseComponent,
        BrainResourseComponent,
        SocialResourseComponent,
        InstituteResourseComponent,
        AdvertisingResourseComponent,
        FeedbackResourseComponent,
        FilterComponent,
        OrgsComponent,
        PersonComponent,
        DocsComponent,
        AdressComponent,
        AddadressComponent,
        AddDocsComponent,
        PersonEditComponent,
        OrgsEditComponent,
        AddResourseComponent,
        DeleteResourseComponent,
        DocsFullsizeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        HttpClientModule,
        ColorPickerModule,
        
        RouterModule.forRoot([
            { path: '', redirectTo: 'fetch-data', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'specification', component: SpecificationComponent },
            { path: 'specificationedit', component: SpecificationEditComponent },
            { path: 'matconsumption', component: MatConsumptionResourseComponent },
            { path: 'matresourse', component: MatResourseComponent },
            { path: 'orgresourse', component: OrgResourseComponent },
            { path: 'skill', component: SkillResourseComponent },
            { path: 'brain', component: BrainResourseComponent },
            { path: 'social', component: SocialResourseComponent },
            { path: 'institute', component: InstituteResourseComponent },
            { path: 'advertising', component: AdvertisingResourseComponent },
            { path: 'feedback', component: FeedbackResourseComponent },
            { path: 'orgs', component: OrgsComponent },
            { path: 'person', component: PersonComponent },
            { path: 'docs', component: DocsComponent },
            { path: 'adress', component: AdressComponent },
            { path: 'personedit', component: PersonEditComponent },
            { path: 'orgsedit', component: OrgsEditComponent },
            { path: 'addresourse', component: AddResourseComponent },
            { path: 'docsfullsize', component: DocsFullsizeComponent },
            { path: 'deleteresourseconfirm', component: DeleteResourseComponent },
            { path: '**', redirectTo: 'fetch-data' }
        ]),
        MaterialModule,
        MatDatepickerModule,
        MatNativeDateModule
    ],
    providers: [ResoursesService, UKOService, HttpClient, Cookie, MatDialog, MatDatepicker, MatDatepickerModule, MatNativeDateModule],
    entryComponents: [FilterComponent, AddadressComponent, AddDocsComponent]
})
export class AppModuleShared {
}
