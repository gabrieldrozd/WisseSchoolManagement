import {Component, ComponentFactoryResolver, Input, OnInit, Type, ViewChild, ViewContainerRef} from '@angular/core';
import {Color} from "../../../utilities/color";
import {DomSanitizer, SafeHtml} from "@angular/platform-browser";
import { NavSideItemDirective } from './nav-side-item.directive';

@Component({
    selector: 'w-navbar',
    template: `
        <nav class="flex justify-content-center align-items-center relative px-3"
             [ngStyle]="{backgroundColor: getBgcColor, width: width, height: height}"
        >
            <a class="flex flex-grow-0 align-items-center align-content-center" [routerLink]="'/'">
                <img src="assets/wisse.svg" alt="Wisse" height="50rem" />
            </a>
            <div class="flex flex-grow-1 justify-content-center align-items-center">
                <ng-content></ng-content>
            </div>
            <div class="flex flex-grow-0 align-items-center align-content-center">
                <ng-template wNavSideItem></ng-template>
            </div>
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
export class NavbarComponent implements OnInit {
    @Input() bgcColor?: Color;
    @Input() width: string = '100vw';
    @Input() height: string = '5rem';
    @Input() logo?: string;
    @Input() rightElement!: Type<any>;

    @ViewChild(NavSideItemDirective, {static: true}) navSideItem!: NavSideItemDirective;

    ngOnInit(): void {
        this.loadComponent();
    }

    get getBgcColor(): string {
        return this.bgcColor ? `var(--${this.bgcColor})` : '';
    }

    private loadComponent() {
        const viewContainerRef = this.navSideItem.viewContainerRef;
        viewContainerRef.clear();

        const componentRef = viewContainerRef.createComponent(this.rightElement);
    }
}
