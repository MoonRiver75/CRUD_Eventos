import { Component } from '@angular/core';
import { EventDetailsComponent } from "./event-details/event-details.component";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EventDetailsComponent],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'Detail_N_App';

  constructor(private toastr: ToastrService) {}


}
