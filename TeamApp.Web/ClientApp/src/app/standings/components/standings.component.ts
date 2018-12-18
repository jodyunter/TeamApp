import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-standings',
  templateUrl: './standings.component.html'
})
export class StandingsComponent {
  public standingsData: Standings;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Standings>(baseUrl + 'api/Standings/Standings').subscribe(result => {
      this.standingsData = result;
    }, error => console.error(error));

  }
  

}


