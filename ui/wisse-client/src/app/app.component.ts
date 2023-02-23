import {Component, OnInit} from '@angular/core';
import {PrimeNGConfig} from "primeng/api";
import {ToastrService} from "./shared/services/toastr.service";
import {ConfirmService} from "./shared/services/confirm.service";

@Component({
    selector: 'w-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    title = 'wisse-client';

    constructor(
        private toastr: ToastrService,
        private confirm: ConfirmService,
        private primeNGConfig: PrimeNGConfig
    ) {
        this.primeNGConfig.ripple = true;
    }

    ngOnInit(): void {
    }

    showSuccess() {
        this.toastr.success({
            title: 'Dupa',
            message: 'Cycki'
        });
    }

    showConfirmDialog() {
        this.confirm.dialog({
            title: 'Czy na pewno?',
            message: 'Jesteś pewien, że chcesz usunąć użytkownika?',
            accept: () => {
                this.toastr.success({
                    title: 'Success',
                    message: 'Udało się!'
                })
            },
            reject: () => {
                this.toastr.error({
                    title: 'Błąd',
                    message: 'Nie udało się!'
                })
            }
        })
    }

    showConfirmPopup(event: Event) {
        this.confirm.popup({
            target: event.target,
            message: "asdadas",
            accept: () => {
                this.toastr.success({
                    title: 'Success',
                    message: 'Udało się!'
                })
            },
            reject: () => {
                this.toastr.error({
                    title: 'Błąd',
                    message: 'Nie udało się!'
                })
            }
        })
    }
}
