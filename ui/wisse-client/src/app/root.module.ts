import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {RootRouting} from './root.routing';
import {RootComponent} from './root.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {SharedModule} from "./_shared/shared.module";
import {CoreModule} from "./_core/core.module";
import {HomeModule} from "./features/home/home.module";
import {ButtonModule} from "primeng/button";

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        RootRouting,
        CoreModule,
        SharedModule,
        HomeModule,
        ButtonModule
    ],
    declarations: [
        RootComponent
    ],
    bootstrap: [RootComponent],
    providers: []
})
export class RootModule {
}
