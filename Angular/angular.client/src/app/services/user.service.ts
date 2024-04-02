import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { NewUserDto } from '../models/newUserDto.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7250/api/Users'; // Replace with your API endpoint

  // Method to delete a user by ID
  deleteUser(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + '/withInsurancePolicies');
  }

  // Method to add a new user
  addUser(newUser: NewUserDto): Observable<NewUserDto> {
    return this.http.post<NewUserDto>(this.apiUrl, newUser);
  }

  // Method to update an existing user
  updateUser(updatedUser: User): Observable<User> {
    const url = `${this.apiUrl}/${updatedUser.id}`; // Construct the URL for the specific user
    return this.http.put<User>(url, updatedUser);
  }

  // Implement additional methods as needed (e.g., addUser, editUser, deleteUser)
}
