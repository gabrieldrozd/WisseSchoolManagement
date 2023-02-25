import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {ConfirmationService, MessageService} from "primeng/api";
import {ToastModule} from "primeng/toast";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {ConfirmPopupModule} from "primeng/confirmpopup";
import {RippleModule} from "primeng/ripple";
import {AnimateModule} from "primeng/animate";

import {ConfirmComponent} from './components/utils/confirm.component';
import {ButtonComponent} from './components/utils/button.component';
import {ToastComponent} from './components/utils/toast.component';
import {ContainerComponent} from "./components/layout/container.component";
import {NavlinkComponent} from './components/utils/navigation/navlink.component';
import {RouterLink, RouterLinkActive} from "@angular/router";
import {NavbarComponent} from './components/utils/navigation/navbar.component';
import {NavSideItemDirective} from "./components/utils/navigation/nav-side-item.directive";


@NgModule({
    declarations: [
        ToastComponent,
        ConfirmComponent,
        ButtonComponent,
        ContainerComponent,
        NavlinkComponent,
        NavbarComponent,
        NavSideItemDirective
    ],
    imports: [
        CommonModule,
        ToastModule,
        ConfirmDialogModule,
        ConfirmPopupModule,
        RippleModule,
        AnimateModule,
        RouterLink,
        RouterLinkActive,
    ],
    providers: [
        MessageService,
        ConfirmationService
    ],
    exports: [
        ToastComponent,
        ConfirmComponent,
        ButtonComponent,
        ContainerComponent,
        NavlinkComponent,
        NavbarComponent,
        NavSideItemDirective
    ]
})
export class SharedModule {
}
