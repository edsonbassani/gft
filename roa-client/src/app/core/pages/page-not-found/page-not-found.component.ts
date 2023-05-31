import { Component, Input } from '@angular/core';

@Component({
  selector: 'roa-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.scss']
})
export class PageNotFoundComponent {
  @Input() mainMessage:string = "Oops! Page Not Found";
}
