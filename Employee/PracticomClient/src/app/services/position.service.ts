import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  constructor(private _http: HttpClient) {

  }
  getAllPositions() {
    return this._http.get('http://localhost:7048/api/Position')

  }
}
