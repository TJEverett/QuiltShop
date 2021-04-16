# Quilt Shop

#### _Track Instructors Projects and Students, 02/26/2021_

#### By _**Tristen Everett**_

## Description

This project was to practice many-to-many functionality within a database to accomplish a task based on user stories. In this project I built a ASP.NET MVC webapp that allows the user to add instructors, projects, and students to a database then as a student or instructor sign up for a project to learn or teach. The user stories used are included below, along with stretch goals as possible additions for future updates.

### User Stories

* Create a Instructor including the instructor's name
* Create a Projects including the project's name
* Create a Student including the student's name
* Instructors can sign up to teach Projects
* Students can sign up for the Projects they want to work on
* Let multiple instructors teach the same project
* Let multiple projects be taught by the same instructor
* Let multiple students work on the same project

#### Stretch Goals

1. Dates
   * Add start date for Projects
   * Limit Students to only sign up for future Projects
2. Capacity
   * Add student capacity to Instructor
   * Limit Students signed up for a Project to no more than the combined instructor's capacity

## Setup/Installation Requirements

1. Clone this Repo
2. Run `dotnet ef database update` from within /QuiltShop to create the database
3. You may need to update file /QuiltShop/appsettings.json to match the userID and password for the computer your using
4. Run `dotnet restore` from within /QuiltShop file location
5. Run `dotnet build` from within /QuiltShop file location
6. Run `dotnet run` from within /QuiltShop file location
7. Using your preferred browser navigate to http://localhost:5000/

## Technologies Used

* C#
* ASP.NET Core
* Entity Framework Core
* MYSQL
* Razor Pages

### License

This software is licensed under the MIT license

Copyright (c) 2021 **_Tristen Everett_**