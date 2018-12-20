import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

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

  saveTeam(team: Team): Observable<Team> {
    return this.http.post<Team>(this.baseUrl + 'api/Team/SaveTeam', team, httpOptions);
  }
}

