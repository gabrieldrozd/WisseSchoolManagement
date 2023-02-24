import {Component, OnInit} from '@angular/core';
import {ToastrService} from "../../_shared/services/toastr.service";
import {ConfirmService} from "../../_shared/services/confirm.service";

@Component({
    selector: 'w-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent {
    constructor(
        private toastr: ToastrService,
        private confirm: ConfirmService,
    ) {
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
