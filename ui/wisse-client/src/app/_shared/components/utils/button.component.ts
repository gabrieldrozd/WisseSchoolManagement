import {Component, Input} from '@angular/core';

@Component({
    selector: 'w-button',
    template: `
        <button
            pButton
            pRipple
            [label]="label"
            [type]="type"
            [ngClass]="[size, color, variant, elevation]"
            [icon]="icon ? icon : ''"
        >
            <ng-content />
        </button>
    `,
    styles: [`
        .small {
            font-size: 0.75rem;
            transform: scale(0.75);
        }

        .medium {
            font-size: 1rem;
            transform: scale(1);
        }

        .large {
            font-size: 1.25rem;
            transform: scale(1.25);
        }
    `]
})
export class ButtonComponent {
    @Input() label: string = '';
    @Input() type: Type | null = 'button';
    @Input() size: Size | null = 'medium';
    @Input() color: Color | null = 'p-button-primary';
    @Input() variant: Variant | null = 'p-button-raised';
    @Input() elevation: Elevation | null = 'shadow-4';
    @Input() icon?: string;


}

export declare type Type =
    'button'
    | 'submit'
    | 'reset';

export declare type Size =
    'small'
    | 'medium'
    | 'large';

export declare type Color =
    'p-button-primary'
    | 'p-button-secondary'
    | 'p-button-success'
    | 'p-button-info'
    | 'p-button-warning'
    | 'p-button-help'
    | 'p-button-danger';

export declare type Variant =
    'p-button-raised'
    | 'p-button-rounded'
    | 'p-button-text'
    | 'p-button-raised p-button-text'
    | 'p-button-outlined'
    | 'p-button-outlined p-button-rounded';

export declare type Elevation =
    'shadow-none'
    | 'shadow-0'
    | 'shadow-1'
    | 'shadow-2'
    | 'shadow-3'
    | 'shadow-4'
    | 'shadow-5'
    | 'shadow-6'
    | 'shadow-7'
    | 'shadow-8';

