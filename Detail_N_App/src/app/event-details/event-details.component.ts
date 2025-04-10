import { Component, OnInit } from '@angular/core';
import { EventDetailFormComponent } from "./event-detail-form/event-detail-form.component";
import { EventDetailService } from '../shared/event-detail.service';
import { CommonModule } from '@angular/common';
import { EventDetail } from '../shared/event-detail.model';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-event-details',
  standalone: true,
  imports: [CommonModule, EventDetailFormComponent], 
  templateUrl: './event-details.component.html',
  styles: []
})
export class EventDetailsComponent implements OnInit{

  tipoEventoLabels: String[] = [
    'Conferencia',
    'Taller',
    'Seminario',
    'Webinario',
    'Otro'
  ];

  constructor(public service: EventDetailService){

  }
  ngOnInit(): void {
   this.service.refreshList();
  }

  populateForm(selectedRecord:EventDetail){
    this.service.formData = Object.assign({},selectedRecord);
  }
  deleteRecord(id: number) {
    Swal.fire({
      title: '¿Estás seguro?',
      text: '¡No podrás revertir esto!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sí, eliminarlo'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deleteEventDetail(id).subscribe({
          next: () => {
            this.service.refreshList();
            Swal.fire('¡Eliminado!', 'El evento ha sido eliminado.', 'success');
          },
          error: () => {
            Swal.fire('Error', 'No se pudo eliminar el evento.', 'error');
          },
        });
      }
    });
  }
  

}
