import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {HomeRouting} from './home.routing';
import { HomeComponent } from './home.component';
import {SharedModule} from "../../_shared/shared.module";
import {MenuModule} from "primeng/menu";
import {StyleClassModule} from "primeng/styleclass";
import {RippleModule} from "primeng/ripple";
import { HomeNavlinkComponent } from './components/home-navlink.component';
import {OverlayPanelModule} from "primeng/overlaypanel";


@NgModule({
    declarations: [
        HomeComponent,
        HomeNavlinkComponent,
    ],
    exports: [
    ],
    imports: [
        CommonModule,
        HomeRouting,
        SharedModule,
        MenuModule,
        StyleClassModule,
        RippleModule,
        OverlayPanelModule
    ]
})
export class HomeModule {
}
