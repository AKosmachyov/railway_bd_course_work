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

  addObject(tableName: string, obj: any) {
    return this.doHttpPutReq(tableName, obj);
  }

  private doHttpGetReq(tableName: string) {
    let params = new HttpParams();
    params = params.append('table', tableName);

    return this.http.get(environment.serverURL, {params: params})
      .toPromise();
  }
  private doHttpPutReq(tableName: string, obj: any) {
    const body = {
      tableName: tableName,
      obj: obj
    };
    return this.http.put(environment.serverURL, body)
      .toPromise();
  }
}
