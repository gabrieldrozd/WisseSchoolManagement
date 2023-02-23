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
import {ContainerComponent} from './components/layout/container.component';


@NgModule({
    declarations: [
        ToastComponent,
        ConfirmComponent,
        ButtonComponent,
        ContainerComponent
    ],
    imports: [
        CommonModule,
        ToastModule,
        ConfirmDialogModule,
        ConfirmPopupModule,
        RippleModule,
        AnimateModule,
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
        ContainerComponent
    ]
})
export class SharedModule {
}
