# C#project - Blood Donation Management System

A modern, full-featured **ASP.NET Core MVC** web application built with **.NET 8** and **MySQL** to connect blood donors with patients in need.

## Features

- **Donor Registration**  
  - Blood group, address, last donation date ("Never donated" option)  
  - Optional WhatsApp number and Facebook profile for direct contact  
  - Automatic approval (donors appear immediately if eligible)

- **Patient Registration & Search**  
  - Search available donors by blood group  
  - Real-time eligibility check (>4 months since last donation)  
  - Direct contact buttons: **WhatsApp** and **Facebook** (opens chat/profile with pre-filled message)

- **Admin Dashboard**  
  - Total registered donors and patients  
  - Blood group distribution with counts and animated progress bars

- **Beautiful & Responsive UI** using Bootstrap 5  
- **Data persistence** with MySQL database

## Tech Stack

- **Backend**: ASP.NET Core MVC (.NET 8)
- **Database**: MySQL (Entity Framework Core)
- **Frontend**: Bootstrap 5, Razor Views, HTML5, CSS3
- **Authentication**: Session-based with role support (Admin, Donor, Patient)

## Prerequisites

- .NET 8 SDK
- MySQL Server (e.g., XAMPP)
- Any code editor (VS Code, Visual Studio, etc.)

## Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/CSproject.git
   cd CSproject
<p>Set up MySQL Database
Start XAMPP and run MySQL
Open phpMyAdmin (http://localhost/phpmyadmin)
Create a new database named BloodDonation
Run the following SQL script to create tables and seed initial data:</p>
USE BloodDonation;

CREATE TABLE BloodGroups (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(5) NOT NULL UNIQUE
);

CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Phone VARCHAR(20) NOT NULL
);

CREATE TABLE Donors (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    BloodGroupId INT NOT NULL,
    Address VARCHAR(255) NOT NULL,
    LastDonationDate DATE NULL,
    AvailabilityStatus TINYINT(1) DEFAULT 1,
    IsApproved TINYINT(1) DEFAULT 1,
    WhatsApp VARCHAR(50) NULL,
    Facebook VARCHAR(255) NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (BloodGroupId) REFERENCES BloodGroups(Id)
);

CREATE TABLE SearchLogs (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    BloodGroupId INT NOT NULL,
    SearchDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (BloodGroupId) REFERENCES BloodGroups(Id)
);

-- Seed blood groups
INSERT INTO BloodGroups (Name) VALUES 
('A+'), ('A-'), ('B+'), ('B-'), ('AB+'), ('AB-'), ('O+'), ('O-');

-- Admin user (username: admin, password: admin123)
INSERT INTO Users (Username, PasswordHash, Role, Name, Email, Phone) 
VALUES ('admin', 'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=', 'Admin', 'Administrator', 'admin@example.com', '9999999999');

<h3>3 Run the application</h3>
dotnet run
<h3>4 Open in browser</h3>
Visit the URL shown in the terminal (usually https://localhost:7294)

<h3> Uses</h3>
<p>
  Register as Donor → Fill details (WhatsApp/Facebook optional)
  <br>
 Register as Patient → Login → Search by blood group
Click WhatsApp or Facebook button to contact donor directly
Login as Admin to view statistics dashboard
</p>

<div align="center">

# 🩸 CSproject - Blood Donation Management System

**A modern ASP.NET Core MVC web application to connect blood donors with patients in need — saving lives one donation at a time.**

<br>

[![.NET 8](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![MySQL](https://img.shields.io/badge/Database-MySQL-brightgreen.svg)](https://www.mysql.com/)
[![Bootstrap 5](https://img.shields.io/badge/UI-Bootstrap_5-purple.svg)](https://getbootstrap.com/)

<br><br>

### 🌟 Key Features

- Donor & Patient Registration with full profile
- Real-time blood donor search by blood group
- Direct contact via **WhatsApp** and **Facebook** buttons
- Automatic eligibility check (4-month rule)
- Beautiful Admin Dashboard with statistics
- Fully responsive & modern UI

<br>

### 📸 Screenshots

<table>
  <tr>
    <td align="center"><img src="https://via.placeholder.com/600x350/FF6B6B/FFFFFF?text=Landing+Page" alt="Landing Page" width="100%"/><br><strong>Home Page</strong></td>
    <td align="center"><img src="https://via.placeholder.com/600x350/DC3545/FFFFFF?text=Donor+Registration" alt="Donor Registration" width="100%"/><br><strong>Donor Registration</strong></td>
  </tr>
  <tr>
    <td align="center"><img src="https://via.placeholder.com/600x350/007BFF/FFFFFF?text=Patient+Search+Results" alt="Search Results" width="100%"/><br><strong>Patient Search Results</strong></td>
    <td align="center"><img src="https://via.placeholder.com/600x350/28A745/FFFFFF?text=Admin+Dashboard" alt="Admin Dashboard" width="100%"/><br><strong>Admin Dashboard</strong></td>
  </tr>
</table>

> Replace the placeholder images above with your actual screenshots!

<br>

### 🚀 Tech Stack

- **Backend**: ASP.NET Core MVC (.NET 8)
- **Database**: MySQL + Entity Framework Core
- **Frontend**: Bootstrap 5, Razor Views
- **Authentication**: Session-based roles (Admin, Donor, Patient)

<br>

### ⚙️ Setup

```bash
git clone https://github.com/yourusername/CSproject.git
cd CSproject
dotnet run
