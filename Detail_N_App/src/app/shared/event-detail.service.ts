import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { EventDetail } from './event-detail.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventDetailService {
  url: string = `${environment.apiBaseUrl}/EventDetail`;
  list: EventDetail[] = [];
  formData: EventDetail = new EventDetail();

  constructor(private http: HttpClient) {}

  refreshList(): void {
    this.http.get<EventDetail[]>(this.url).subscribe({
      next: (res) => {
        this.list = res;
      },
      error: (err) => {
        console.error('Error fetching event details', err);
      },
    });
  }

 
  postEventDetail(eventDetail: EventDetail): Observable<EventDetail> {
    return this.http.post<EventDetail>(this.url, eventDetail);
  }

 
  updateEventDetail(eventDetail: EventDetail): Observable<EventDetail> {
    return this.http.put<EventDetail>(`${this.url}/${eventDetail.id}`, eventDetail);
  }

  deleteEventDetail(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
  
}
