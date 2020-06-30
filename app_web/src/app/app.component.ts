import { Component, OnInit } from '@angular/core';
import { ApiService } from './shared/services/api-service';
import { Comando } from './shared/models/command.model';
import { CustomFormatters } from './shared/formatters/custom-formatters';
import { Machine } from './shared/models/machine.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  outputLines = [''];
  input: string = '';
  selectedMachine: Machine;
  machineList: Machine[] = [];
  isLoading: boolean = false;

  constructor(private service: ApiService) { }

  ngOnInit(): void {
    this.service.GetMachinesList().subscribe(
      r=>{
        console.log(r.data);
        this.machineList = r.data;
        this.selectedMachine = this.machineList[0];
      },
      error => {
        console.log('não funcionou');
      }
    );
  }

  ExecutaComando() {
    if (this.input.length > 0) {
      this.isLoading = true;

      let comando = new Comando();
      comando.Instrucao = this.input;
      comando.EnderecoIP = this.selectedMachine.localAddress;

      this.service.ExecutaComando(comando).subscribe(
        resp => {
          this.outputLines = CustomFormatters.removeLineBreakeCharaters(resp.data);
          this.isLoading = false;
        },
        error => {
          console.log(error);
          this.isLoading = false;
        },
        () => {
          this.isLoading = false;
        }
      );
    }
  }

  onMachineSelect(machine: Machine) {
    this.selectedMachine = machine;
  }
}
