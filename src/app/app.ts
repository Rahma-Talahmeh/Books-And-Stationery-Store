
/*
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './navbar/navbar';
import { Footer } from './footer/footer';
@Component({
  imports: [RouterOutlet,Navbar,Footer],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('BookStore_project');
  projectTitle:string="BookStore_project";
  imagePath:string='./images/books_photo.jpg';
  handleClick()
  {
    alert('Button Clicked!')
  }
  name:string='';
  handleNameChange(event:Event)
  {
    const input = event.target as HTMLInputElement;
    this.name=input.value;
    console.log(this.name);
  }
}
*/
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './navbar/navbar';
import { Footer } from './footer/footer';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Navbar, RouterOutlet, Footer,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}