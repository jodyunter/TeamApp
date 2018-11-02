import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-standings',
  templateUrl: './standings.component.html'
})
export class StandingsComponent {
  public standingsData: Standings;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Standings>(baseUrl + 'api/SampleData/Standings').subscribe(result => {
      this.standingsData = result;
    }, error => console.error(error));
  }
  

}

interface StandingsTeam {
  teamName: string,
  rank: number,
  division: string,
  wins: number,
  loses: number,
  ties: number,
  gamesPlayed: number,
  goalsFor: number,
  goalsAgainst: number,
  goalDifference: number,
  points: number
}

interface Standings {
  standingsName: string,
  teams: StandingsTeam[]
}

