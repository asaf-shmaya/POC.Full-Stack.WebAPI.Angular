import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service'; // Import UserService
import { User } from '../models/user.model'; // Import User model

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users!: User[]; // Property to hold list of users
  selectedUser!: User; // Property to hold selected user

  constructor(private userService: UserService) { } // Inject UserService

  ngOnInit(): void {
    this.refreshUsers(); // Fetch users when component initializes
  }

  refreshUsers(): void {
    this.userService.getUsers().subscribe(users => this.users = users); // Fetch users from UserService
  }

  selectUser(user: User): void {
    this.selectedUser = user; // Assign selected user
    // Implement functionality to view insurance policies of selected user
  }

  addUser(): void {
    // Implement functionality to add a new user
  }
}
