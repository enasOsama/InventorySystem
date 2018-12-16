import { Injectable } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { HttpHeaders } from "@angular/common/http";
import { map } from 'rxjs/operators';
import { apiUrl } from 'src/config/api.config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private repositoryService: RepositoryService) { }

  login(userName: string, password: string) {

    var userData = `username=${userName}&password=${password}&grant_type=password`;
    return this.repositoryService.create<any>(apiUrl.userAccount.login, userData, { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) }).pipe(map(result => {
        
        if (result) {
          // store user details and  token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(result));
        }
      return result;
    }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

  register(user) {
    return this.repositoryService.create<User>(apiUrl.userAccount.register, user);
  }
}
