import {Component} from '@angular/core';

@Component({
    selector: 'w-toast',
    template: `
        <p-toast position="bottom-right" [showTransformOptions]="'translateX(100%)'"/>
    `,
    styles: []
})
export class ToastComponent {

}
