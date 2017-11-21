import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';

import { User } from '../classes/user';

@Injectable()
export class ServerService {
  constructor(private http: HttpClient) { }

  getTableValues(tableName: string) {
    return this.doHttpGetReq(tableName);
  }

  addObject(tableName: string, obj: any) {
    return this.doHttpPutReq(tableName, obj);
  }

  removeObject(tableName: string, obj: any) {
    return this.doHttpDeleteReq(tableName, obj);
  }
  updateObject(tableName: string, obj: any, newObj: any) {
    return this.doHttpPostReq(tableName, obj, newObj);
  }

  private doHttpPostReq(tableName: string, obj: any, newObj: any) {
    return this.http.post(environment.serverURL, {
      table: tableName,
      oldObj: obj,
      newObj: newObj
    }).toPromise();
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
  private doHttpDeleteReq(tableName: string, obj) {
    let params = new HttpParams();
    params = params.append('table', tableName);
    params = params.append('searchEl', JSON.stringify(obj));

    return this.http.delete(environment.serverURL, {params: params})
      .toPromise();
  }
}
