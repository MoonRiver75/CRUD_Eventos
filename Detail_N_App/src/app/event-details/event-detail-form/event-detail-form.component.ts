import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { EventDetailService } from '../../shared/event-detail.service';
import { NgForm} from '@angular/forms';
import { NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

import { EventDetail } from '../../shared/event-detail.model';

@Component({
  selector: 'app-event-detail-form',
  standalone: true,
  imports: [FormsModule, NgIf,CommonModule],
  templateUrl: './event-detail-form.component.html',
  styles: [``],
})
export class EventDetailFormComponent implements OnInit {
  constructor(
    public service: EventDetailService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    if (this.service.formData.id) {
      this.service.refreshList(); 
    }
  }

  

  
  request() {
    if (this.service.formData.id) {
      return this.service.updateEventDetail(this.service.formData);
    } else {
      return this.service.postEventDetail(this.service.formData);
    }
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.request().subscribe({
        next: (res) => {
          const mensaje = this.service.formData.id
            ? 'Evento actualizado correctamente'
            : `Evento creado. ID asignado: ${res.id}`;
          this.toastr.success(mensaje);
          this.service.refreshList();
          form.resetForm(); 
        },
        error: (err) => {
          this.toastr.error('Error al enviar los datos del evento');
          console.error('Error details:', err); 
        },
      });
    } else {
      this.toastr.warning('Por favor, completa todos los campos requeridos.');
    }
  }
}  
