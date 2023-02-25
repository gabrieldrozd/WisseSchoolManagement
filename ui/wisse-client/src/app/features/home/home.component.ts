import {Component, OnInit, Type} from '@angular/core';
import {ToastrService} from "../../_shared/services/toastr.service";
import {ConfirmService} from "../../_shared/services/confirm.service";
import {HomeNavlinkComponent} from "./components/home-navlink.component";

@Component({
    selector: 'w-home',
    template: `
        <w-container gap="gap-0" direction="column" padding="p-0" maxWidth="100vw">
            <w-container
                gap="gap-0"
                padding="p-0"
                bgcColor="w-indigo-500"
                maxWidth="100vw"
                width="100vw"
            >
                <w-navbar width="80rem" [rightElement]="homeNavitem">
                    <w-navlink
                        text="Start"
                        icon="pi pi-home"
                        link="/" />
                    <w-navlink
                        text="About"
                        icon="pi pi-info-circle"
                        link="/about" />
                    <w-navlink
                        text="Contact"
                        icon="pi pi-phone"
                        link="/contact" />
                    <w-navlink
                        text="Enroll"
                        icon="pi pi-user-plus"
                        link="/enroll" />
                </w-navbar>
            </w-container>
            <w-container
                gap="gap-0"
                padding="p-0"
                maxWidth="80rem"
                width="80rem"
                bgcColor="w-red-400"
            >
                Page content here. <br>
                Automitically will get higher
            </w-container>
        </w-container>
    `,
    styles: [``]
})
export class HomeComponent {
    homeNavitem: Type<HomeNavlinkComponent> = HomeNavlinkComponent;

    constructor(
        private toastr: ToastrService,
        private confirm: ConfirmService,
    ) {
    }
}
