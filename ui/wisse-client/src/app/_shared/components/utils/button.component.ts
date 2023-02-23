import {Component, Input} from '@angular/core';

export type Type = 'button' | 'submit' | 'reset';
export type Color =
    'p-button-primary'
    | 'p-button-secondary'
    | 'p-button-success'
    | 'p-button-info'
    | 'p-button-warning'
    | 'p-button-help'
    | 'p-button-danger';

@Component({
    selector: 'w-button',
    template: `
        <button
            pButton
            pRipple
            [label]="label"
            [type]="type"
            [ngClass]="color"
            class="shadow-4"
        >
            <ng-content />
        </button>
    `,
    styles: []
})
export class ButtonComponent {
    @Input() label: string = '';
    @Input() type: Type | null = 'button';
    @Input() color: Color | null = 'p-button-primary';
}
