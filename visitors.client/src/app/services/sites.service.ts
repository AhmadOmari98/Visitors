import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ControllerNames } from '../models/controller-names';

@Injectable({
  providedIn: 'root'
})
export class SitesService {
  URL_API: string = `${environment.server_URL}${ControllerNames.Sites}`;
  constructor(private http: HttpClient) { }
  //-----------------------------------------------**
  create(name: string | undefined = undefined): Observable<string> {
    let url: string;
    if (name && name?.length > 0)
      url = `${this.URL_API}/create/${name}`;
    else
      url = `${this.URL_API}/create`;

    return this.http.post<string>(url, null)
  }
}
