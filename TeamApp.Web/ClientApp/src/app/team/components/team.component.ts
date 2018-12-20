import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-team',
  templateUrl: '../pages/team.component.html',
  styleUrls: ['../css/team.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class TeamComponent implements OnInit {
  teams: Team[];
  selectedTeam: Team;

  constructor(private teamService: TeamService, private ref: ChangeDetectorRef) {    
    setInterval(() => {
      this.getTeams();
      this.ref.markForCheck();
    }, 1000);
  }
  createNewTeam(): void {
    this.selectedTeam = {
      id: 0,
      name: "",
      nickName: "",
      shortName: "",
      owner:"",
      skill: 5,
      firstYear: 1,
      lastYear: null,
      active: true
    } as Team;
  }
  saveTeam(): void {
    this.teamService.saveTeam(this.selectedTeam).subscribe(team => this.selectedTeam = team);    
  }

  getTeams(): void {
    this.teamService.getTeams().subscribe(teams => this.teams = teams);
  }
  onSelect(team: Team): void {
    this.selectedTeam = team;    
  }

  setSelectedTeam(): void {    
    this.selectedTeam = this.teams[0];
    
  }

  ngOnInit() {
    this.getTeams();
  }

}
