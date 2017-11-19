import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';

import { User } from '../classes/user';

@Injectable()
export class ServerService {
  constructor(private http: HttpClient) { }

  getUsers() {
    return this.doHttpGetReq('user');
  }

  private doHttpGetReq(tableName: string) {
    let params = new HttpParams();
    params = params.append('table', tableName);

    return this.http.get(environment.serverURL, {params: params})
      .toPromise();
  }
}
