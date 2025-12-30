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
