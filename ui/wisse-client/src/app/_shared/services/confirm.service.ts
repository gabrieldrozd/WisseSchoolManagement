import {Injectable} from '@angular/core';
import {ConfirmationService} from "primeng/api";

export type ConfirmDialogProps = {
    title: string;
    message: string;
    accept: () => void;
    reject?: () => void;
};

export type ConfirmPopupProps = {
    target: any;
    message: string;
    accept: () => void;
    reject?: () => void;
}

@Injectable({
    providedIn: 'root'
})
export class ConfirmService {
    constructor(private confirmationService: ConfirmationService) {
    }

    dialog = (props: ConfirmDialogProps) => {
        this.confirmationService.confirm({
            key: 'confirmDialog',
            header: props.title,
            message: props.message,
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                props.accept();
            },
            reject: () => {
                if (props.reject) {
                    props.reject();
                }
            },
        });
    }

    popup = (props: ConfirmPopupProps) => {
        this.confirmationService.confirm({
            key: 'confirmPopup',
            target: props.target,
            message: props.message,
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                props.accept();
            },
            reject: () => {
                if (props.reject) {
                    props.reject();
                }
            },
        });
    }
}
