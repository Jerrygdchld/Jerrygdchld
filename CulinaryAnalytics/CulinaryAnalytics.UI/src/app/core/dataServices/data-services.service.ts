import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StandardReply } from '../../../models/standard-reply';
import { LeftMenuOption } from '../../../models/left-menu-option';
import { environment } from '../../../environments/environment';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataServicesService {

  constructor(private http: HttpClient) { }

  public getLeftMenu() : Observable<LeftMenuOption[]> {
    let url = `${environment.target}/user/menu`
    return this.http.get<StandardReply<LeftMenuOption[]>>(url)
    .pipe(map((res: StandardReply<LeftMenuOption[]>) => {
      return res.response;
    }));
  }
}
