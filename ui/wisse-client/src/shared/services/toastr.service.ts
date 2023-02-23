import {Injectable} from '@angular/core';
import {MessageService, PrimeIcons} from "primeng/api";

export type ToastrProps = {
    title: string;
    message: string;
}

@Injectable({
    providedIn: 'root',
})
export class ToastrService {
    constructor(private messageService: MessageService) {
    }

    success = (props: ToastrProps) => {
        this.messageService.add({
            severity: 'success',
            summary: props.title,
            // detail: props.message,
            icon: PrimeIcons.CHECK_CIRCLE,
        });
    }

    error = (props: ToastrProps) => {
        this.messageService.add({
            severity: 'error',
            summary: props.title,
            detail: props.message,
            icon: PrimeIcons.CHECK_CIRCLE,
        });
    }
}
