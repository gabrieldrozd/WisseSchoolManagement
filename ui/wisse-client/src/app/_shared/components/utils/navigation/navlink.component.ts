import {Component, ElementRef, Input, ViewChild} from '@angular/core';
import {Color} from "../../../utilities/color";
import {Padding} from "../../../utilities/padding";

@Component({
    selector: 'w-navlink',
    template: `
        <a id="linkAnchor" pRipple
           [routerLink]="link"
           [routerLinkActive]="'active'"
           [ngClass]="[size, padding]"
           [ngStyle]="{backgroundColor: getBgcColor, color: getColor}"
           class="lg:px-3 lg:py-2 transition-colors transition-duration-200"
        >
            <i *ngIf="icon" [ngClass]="[icon ? icon : null, 'mr-3']"></i>
            <span>{{text}}</span>
        </a>
    `,
    styles: [`
        #linkAnchor {
            display: flex;
            align-items: center;
            position: relative;
            margin: 0 0.25rem;
            padding: 1rem 2rem !important;
            text-decoration: none;
            overflow: hidden;
            border-radius: 0.5rem;
            cursor: pointer;

            &.active {
                color: var(--w-indigo-50) !important;
                background-color: var(--w-indigo-700) !important;
                border-bottom: 0.2rem solid var(--w-indigo-800) !important;
            }
            &:hover {
                color: var(--w-indigo-50) !important;
                background-color: var(--w-indigo-800) !important;
            }

            span {
                font-size: 1rem;
                font-weight: bold;
            }
        }

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
export class NavlinkComponent {
    @ViewChild('container') container!: ElementRef;

    @Input() text!: string;
    @Input() link: string | any[] = '/';  // TODO: make it not required
    // Sign In for example will show OverlayPanel to login user
    // There won't be different page for that

    // I'm not sure, but maybe one of @Input() variables should accept html elememnt which will be shown in OverlayPanel
    // If element will be placed in some generic container inside navlink, then it will be easy to show it in OverlayPanel

    @Input() size: Size | null = 'medium';
    @Input() height: string = '4rem';
    @Input() padding?: Padding = 'p-3';

    @Input() color: Color = 'w-indigo-100';
    @Input() bgcColor?: Color = 'w-indigo-500';

    @Input() icon?: string;

    get getColor(): string {
        return this.color ? `var(--${this.color})` : '';
    }

    get getBgcColor(): string {
        return this.bgcColor ? `var(--${this.bgcColor})` : '';
    }
}

export declare type Size =
    'small'
    | 'medium'
    | 'large';
