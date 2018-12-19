import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})

export class TeamService {
  http: HttpClient;
  baseUrl: string;  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  getTeams(): Observable<Team[]> {    
    return this.http.get<Team[]>(this.baseUrl + 'api/Team/GetTeams');    
  }
}

