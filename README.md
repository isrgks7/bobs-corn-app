# 🌽 Coding challenge - Bob’s Corn

### Business rule

You are a farmer named Bob that sells corn 🌽. You are a very fair farmer and your policy is to sell at most 1 corn per client per minute.

Your clients buy corn by making POST petitions to an API that returns a 200 🌽 every time they successfully buy some corn.

### Task at hand

First task: Build a rate limiter using a SQL database that will return a successful response if a client buys corn below the 1 corn per limit rate or a 429 Too Many Requests if the client is buying corn beyond that limit.

### Client portal

You realized most of your clients don’t know how to make a POST petition.

### Task at hand

Second task: Create a website built in Vue/React/Angular where clients can buy corn with the click of a button and see how much corn they have successfully brought. You can use Tailwind or a Block Set like Shadcn.


## Features

- Backend with **Rate Limiting**: Clients can only purchase **1 corn per minute**.
- If a client exceeds the limit, the server returns `429 Too Many Requests`.
- Built with clean architecture principles (Domain, Application, Infrastructure layers).
- SQL-based persistence using **Entity Framework Core** and **InMemory** DB for testing.
- REST API with ASP.NET Core Web API.
- Frontend built with **React + MUI** (Material UI) for quick and responsive UI.
- Displays number of successful purchases.
- Temporizer shown if the client exceeds the rate limit.

## Tech Stack

### Backend
- **.NET 8 / C#**
- **Entity Framework Core** (InMemory and SQLite)
- **ASP.NET Core Web API**
- **xUnit** for unit testing
- Clean architecture: Domain, Application, Infrastructure

### Frontend
- **React**
- **Material UI (MUI)** – used instead of Tailwind or Shadcn for styling
- **Axios** for API calls

## Screenshots

<p align="center">
  <img src="https://github.com/user-attachments/assets/31eb65e2-f3a4-4e25-98d4-bc93b4ed4e09" width="30%" />
  <img src="https://github.com/user-attachments/assets/031ec3f8-f9f0-4060-a158-04a3ffc76597" width="30%" />
  <img src="https://github.com/user-attachments/assets/36f7b9a0-f582-4a8f-9459-c39c4ecfa0cb" width="30%" />
</p>

## How to Run

### Backend
cd backend/BobCorn
dotnet run --project BobCorn.API

### Frontend
cd frontend/
npm run dev

### Database
Microsoft SQL Server

~~~~
CREATE DATABASE BobCornDb;
GO

USE BobCornDb;
GO

CREATE TABLE CornPurchases (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ClientId NVARCHAR(100) NOT NULL,
    PurchaseTime DATETIME NOT NULL
);
~~~~
```bash



