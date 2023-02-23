import {Component} from '@angular/core';

@Component({
    selector: 'w-confirm',
    template: `
        <p-confirmPopup key="confirmPopup"></p-confirmPopup>
        <p-confirmDialog key="confirmDialog"></p-confirmDialog>
    `,
    styles: []
})
export class ConfirmComponent {
}
