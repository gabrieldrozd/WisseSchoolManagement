import {Component, Input} from '@angular/core';
import {Color} from "../../../utilities/color";

@Component({
    selector: 'w-navbar',
    template: `
        <nav class="flex justify-content-center align-items-center relative"
             [ngStyle]="{backgroundColor: getBgcColor, width: width, height: height}"
        >
            <a class="flex flex-grow-0 align-items-center align-content-center" [routerLink]="'/'">
                <img src="assets/wisse.svg" alt="Wisse" height="50rem" class="absolute" />
            </a>
            <ul class="flex flex-grow-1 justify-content-center align-items-center list-none">
                <ng-content></ng-content>
            </ul>
        </nav>
    `,
    styles: [`
        nav {
            width: 100vw;
            margin: 0;
            padding: 0;
        }
    `]
})
export class NavbarComponent {
    @Input() bgcColor?: Color;
    @Input() width: string = '100vw';
    @Input() height: string = '5rem';
    @Input() logo?: string;

    // Sign In will show OverlayPanel to login user
    // There won't be different page for that

    // I'm not sure, but maybe one of @Input() variables should accept html elememnt which will be shown in OverlayPanel
    // If element will be placed in some generic container inside navbar, then it will be easy to show it in OverlayPanel
    // and place button on the right side of navbar

    get getBgcColor(): string {
        return this.bgcColor ? `var(--${this.bgcColor})` : '';
    }
}
