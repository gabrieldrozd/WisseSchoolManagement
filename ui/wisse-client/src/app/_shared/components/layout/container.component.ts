import {AfterViewInit, Component, ElementRef, Input, ViewChild} from '@angular/core';
import {Color} from "../../utilities/color";
import { Padding } from '../../utilities/padding';

/**
 * Flex container. Component that centers its children horizontally and vertically.
 */
@Component({
    selector: 'w-container',
    template: `
        <div #container class="flex m-auto justify-content-center align-items-center"
             [ngClass]="[direction === 'row' ? '' : 'flex-column']"
             [ngStyle]="{backgroundColor: getBgcColor, color: getColor}"
        >
            <ng-content />
        </div>
    `,
    styles: [``]
})

export class ContainerComponent implements AfterViewInit {
    @ViewChild('container') container!: ElementRef;

    /**
     * The direction in which the child components are laid out.
     * @default 'row'
     */
    @Input() direction: 'row' | 'column' = 'row';

    /**
     * The maximum width of the container.
     * @default '100%'
     */
    @Input() maxWidth: string = '100%';

    /**
     * The width of the container.
     * @default '100%'
     */
    @Input() width: string = '100%';

    /**
     * The maximum height of the container.
     * @default '100%'
     */
    @Input() maxHeight: string = '100%';

    /**
     * The height of the container.
     * @default '100%'
     */
    @Input() height: string = '100%';

    /**
     * The PrimeFlex padding class to be applied to the container.
     */
    @Input() padding?: Padding;

    /**
     * The PrimeFlex gap class to be applied to the container.
     */
    @Input() gap?: Gap;

    @Input() radius?: number;

    /**
     * The PrimeFlex color class to be applied to the container.
     */
    @Input() color?: Color;

    /**
     * The PrimeFlex background color class to be applied to the container.
     */
    @Input() bgcColor?: Color;

    ngAfterViewInit(): void {
        const container = this.container.nativeElement as HTMLElement;

        this.applyWidth(container);
        this.applyHeight(container);
        this.applyPadding(container);
        this.applyGap(container);
        this.applyRadius(container);
    }

    get getColor(): string {
        return this.color ? `var(--${this.color})` : '';
    }

    get getBgcColor(): string {
        return this.bgcColor ? `var(--${this.bgcColor})` : '';
    }

    private applyWidth(container: HTMLElement): void {
        container.style.maxWidth = this.maxWidth;
        container.style.width = this.width;
    }

    private applyHeight(container: HTMLElement): void {
        container.style.maxHeight = this.maxHeight;
        container.style.height = this.height;
    }

    private applyPadding(container: HTMLElement): void {
        if (this.padding) {
            container.classList.add(`${this.padding}`);
            return;
        }
        container.classList.add('p-3');
    }

    private applyGap(container: HTMLElement): void {
        if (this.gap) {
            container.classList.add(`${this.gap}`);
            return;
        }
        container.classList.add('gap-0');
    }

    private applyRadius(container: HTMLElement): void {
        if (this.radius) {
            container.style.borderRadius = `${this.radius}px`;
            return;
        }
        container.style.borderRadius = '0px';
    }
}

export declare type Gap = 'gap-0' | 'gap-1' | 'gap-2' | 'gap-3' | 'gap-4' | 'gap-5' | 'gap-6' | 'gap-7' | 'gap-8';



