import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-competition',
  templateUrl: './competition.component.html'
})
export class CompetitionComponent {
  public standingsData: Standings;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Standings>(baseUrl + 'api/Standings/Standings').subscribe(result => {
      this.standingsData = result;
    }, error => console.error(error));

  }
  

}



