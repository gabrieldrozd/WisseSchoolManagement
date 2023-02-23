import {AfterViewInit, Component, ElementRef, Input, ViewChild} from '@angular/core';

/**
 * Flex container. Component that centers its children horizontally and vertically.
 */
@Component({
    selector: 'w-container',
    template: `
        <div #container class="flex m-auto justify-content-center align-items-center"
             [ngClass]="direction === 'row' ? '' : 'flex-column'"
        >
            <ng-content />
        </div>
    `,
    styles: [`
    `]
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

    ngAfterViewInit(): void {
        const container = this.container.nativeElement as HTMLElement;

        this.applyWidth(container);
        this.applyHeight(container);
        this.applyPadding(container);
        this.applyGap(container);
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
        container.classList.add('gap-2');
    }
}

export type Padding =
    'p-0' | 'p-1' | 'p-2' | 'p-3' | 'p-4' | 'p-5' | 'p-6' | 'p-7' | 'p-8'
    | 'pt-0' | 'pt-1' | 'pt-2' | 'pt-3' | 'pt-4' | 'pt-5' | 'pt-6' | 'pt-7' | 'pt-8'
    | 'pr-0' | 'pr-1' | 'pr-2' | 'pr-3' | 'pr-4' | 'pr-5' | 'pr-6' | 'pr-7' | 'pr-8'
    | 'pl-0' | 'pl-1' | 'pl-2' | 'pl-3' | 'pl-4' | 'pl-5' | 'pl-6' | 'pl-7' | 'pl-8'
    | 'pb-0' | 'pb-1' | 'pb-2' | 'pb-3' | 'pb-4' | 'pb-5' | 'pb-6' | 'pb-7' | 'pb-8'
    | 'px-0' | 'px-1' | 'px-2' | 'px-3' | 'px-4' | 'px-5' | 'px-6' | 'px-7' | 'px-8'
    | 'py-0' | 'py-1' | 'py-2' | 'py-3' | 'py-4' | 'py-5' | 'py-6' | 'py-7' | 'py-8';

export type Gap = 'gap-0' | 'gap-1' | 'gap-2' | 'gap-3' | 'gap-4' | 'gap-5' | 'gap-6' | 'gap-7' | 'gap-8';
