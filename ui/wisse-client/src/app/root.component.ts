import {Component, OnInit} from '@angular/core';
import {PrimeNGConfig} from "primeng/api";
import {ToastrService} from "./_shared/services/toastr.service";
import {ConfirmService} from "./_shared/services/confirm.service";

@Component({
    selector: 'w-root',
    template: `
        <w-toast />
        <w-confirm />
        <w-container direction="column" maxWidth="100vw" padding="p-0">
            <router-outlet></router-outlet>
        </w-container>
    `,
    styles: [`
        .root-container {
            width: 100%;
            height: 100%;
            margin: 0 auto;
            padding: 0;
        }
    `]
})
export class RootComponent implements OnInit {
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
