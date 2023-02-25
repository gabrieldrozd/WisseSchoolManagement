import {Component} from '@angular/core';

@Component({
    selector: 'w-home-navitem',
    template: `
        <w-navlink
                text="Sign In"
                icon="pi pi-sign-in"
                color="w-indigo-50"
                bgcColor="w-indigo-400"
                link="/sign-in"
                (click)="op.toggle($event)"
        >
        </w-navlink>

        <!-- TODO: p-overlayPanel should have button and form to submit -->
        <!-- Action should be send here from HomeComponent => @Output and EventEmitter to login -->
        <!-- Login handled in AuthService but from HomeComponent as it will be action designed for 'Start side' of Application -->

        <!-- TODO: p-overlayPanel should have button and form to submit -->
        <!-- Action should be send here from HomeComponent => @Output and EventEmitter to login -->
        <!-- Login handled in AuthService but from HomeComponent as it will be action designed for 'Start side' of Application -->

        <!-- TODO: p-overlayPanel should have button and form to submit -->
        <!-- Action should be send here from HomeComponent => @Output and EventEmitter to login -->
        <!-- Login handled in AuthService but from HomeComponent as it will be action designed for 'Start side' of Application -->
        <p-overlayPanel #op [showCloseIcon]="true" [style]="{width: '400px'}">
            <ng-template pTemplate="">
                dupa
            </ng-template>
        </p-overlayPanel>
    `,
    styles: []
})
export class HomeNavlinkComponent {
}
