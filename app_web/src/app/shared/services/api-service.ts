import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Machine } from '../models/machine.model';
import { Comando } from '../models/command.model';
import { CustomResponse } from '../models/response/custom-response.model';

const API_URL: string = environment.API_URL;

@Injectable({
    providedIn: 'root'
})
export class ApiService{
    constructor(private http: HttpClient) { }

    ExecutaComando(comando: Comando){
        return this.http.post<CustomResponse<string>>(`${API_URL}commands/executar`, comando);
    }

    GetMachinesList(){
        return this.http.get<CustomResponse<Machine[]>>(`${API_URL}services/v1/listar`);
    }
}