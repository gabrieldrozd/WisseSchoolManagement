import {Directive, ViewContainerRef} from '@angular/core';

@Directive({
    selector: '[wNavSideItem]',
})
export class NavSideItemDirective {
    constructor(public viewContainerRef: ViewContainerRef) {
    }
}
