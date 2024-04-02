// user-list.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { NewUserDto } from '../models/newUserDto.model';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users!: User[];  // Assuming User is the interface or class representing a user
  newUser: NewUserDto = { name: '', email: '' }; // Object to store new user data
  selectedUser!: User;
  showAddUserForm = false; // Boolean variable to control visibility of "Add New User" form
  isEditing: boolean = false;
  isEditingName: boolean = false;
  isEditingEmail: boolean = false;
  originalName!: string;
  originalEmail!: string;


  constructor(private userService: UserService) { }

  ngOnInit(): void {
      this.userService.getUsers().subscribe(
          users => {
              this.users = users;
          },
          error => {
              console.error('Error fetching users:', error);
              // Handle error (e.g., show error message)
          }
      );
  }

  selectUser(user: User): void {
    this.selectedUser = user;
  }

  addUser(): void {
    // Implement functionality to add a new user
    this.showAddUserForm = true;
  }

  refreshUsers(): void {
    // Implement functionality to add a new user
    this.selectedUser = null as any; // Set selectedUser to null
    this.showAddUserForm = false; // Set showAddUserForm to false
    this.newUser = { name: '', email: '' }; // Set newUser to empty object
    this.ngOnInit();   
  }

  // Method to handle form submission
  onSubmit(): void {
    this.userService.addUser(this.newUser)
      .subscribe(() => {
        // Reset form after successful submission
        // Refresh user list
        this.refreshUsers();
      });
  }

  toggleEditMode(): void {
    this.isEditing = !this.isEditing;
  }

  toggleEditNameMode(): void {
    this.isEditingName = !this.isEditingName;
    if (this.isEditingName) {
      // Initialize editedName with the current value when entering edit mode
      this.originalName = this.selectedUser.name;
    }
  }

  toggleEditEmailMode(): void {
    this.isEditingEmail = !this.isEditingEmail;
    if (this.isEditingEmail) {
      // Initialize editedEmail with the current value when entering edit mode
      this.originalEmail = this.selectedUser.email;
    }
  }

  // Method to update an existing user
  updateUser(): void {
    const updatedUser: User = {
      id: this.selectedUser.id,
      name: this.selectedUser.name,
      email: this.selectedUser.email,
      insurancePolicies: this.selectedUser.insurancePolicies
      // You may need to include other properties as well, depending on your User model
    };

    this.userService.updateUser(updatedUser)
      .subscribe(() => {
        // Reset form after successful submission
        this.isEditingName = false;
        this.isEditingEmail = false;
        this.refreshUsers(); 
      });
  }

  deleteUser(id: number): void {
    const userToDelete = this.users.find(user => user.id === id);
    if (!userToDelete) {
      console.error('User not found');
      return;
    }

    const policiesCount = userToDelete.insurancePolicies.length;
    const policiesSum = userToDelete.insurancePolicies.reduce((sum, policy) => sum + policy.insuranceAmount, 0);

    /*const roundedAmount = policiesSum.toFixed(2);*/

    /*const message = `Are you sure you want to delete user ${userToDelete.name} (${userToDelete.email})?\n\nThis user has ${policiesCount} policies with a total insurance amount of ${roundedAmount} currency units.`;*/

    let message = `Are you sure you want to delete user '${userToDelete.name}' (${userToDelete.email})?`;

    if (policiesCount > 0) {
      const roundedAmount = policiesSum.toFixed(2);
      message += `\n\nThis user has ${policiesCount} policies with a total insurance amount of ${roundedAmount}.`;
    }

    /*if (confirm('Are you sure you want to delete this user?')) {*/
    if (confirm(message)) {
      this.userService.deleteUser(id).subscribe(() => {
        // Filter out the deleted user from the array
        this.users = this.users.filter(user => user.id !== id);
        this.refreshUsers();
      });
    }
  }

  // Check if speech synthesis is supported
  isSpeechSynthesisSupported(): boolean {
    return 'speechSynthesis' in window;
  }

  speakText(textToSpeak: string): void {
    // Check if SpeechSynthesis is supported by the browser
    if ('speechSynthesis' in window) {
      const utterance = new SpeechSynthesisUtterance(textToSpeak);
      speechSynthesis.speak(utterance);
    } else {
      console.error('Speech synthesis not supported in this browser.');
    }
  }

  getUpdateButtonStyle(): string {
    return this.isEditingName || this.isEditingEmail ? '' : 'background-color: #ccc'; // Gray background when not in edit mode
  }
  
}
