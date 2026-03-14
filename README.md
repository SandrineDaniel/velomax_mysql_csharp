# Velomax MySQL Database Management System

This project is a **C# console application** designed to interact with a **MySQL database** to manage the operations of a fictional bicycle company called **Velomax**.

The application allows users to perform database operations such as **inserting, updating, deleting, displaying data, and running statistical queries** through a command-line interface.

---

## Project Overview

The system connects to a **MySQL database named `velomax`** and allows management of several entities involved in the business operations of the company.

The application simulates a small **database management system** for a bicycle retailer.

Main features include:

- managing clients
- managing suppliers
- managing bicycles
- managing spare parts
- managing employees
- managing orders
- generating statistical insights from the data

---

## Technologies Used

- **C#**
- **.NET**
- **MySQL**
- **MySQL Connector for .NET**
- **Visual Studio**

---

## Database Entities

The system manages the following tables:

- **Client**
- **Fournisseur (Supplier)**
- **Bicyclette (Bicycle)**
- **Pièces de rechange (Spare Parts)**
- **Salarié (Employee)**
- **Commande (Order)**

Each entity supports standard **CRUD operations**:

- Create (insert data)
- Read (display data)
- Update
- Delete

---

## Application Features

### Authentication

The system supports two types of users.

#### Root

Full access to the database:

- modify tables
- insert / delete / update data
- access statistics
- manage stock
- run demo mode

#### Bozo

Limited access:

- view data
- access statistics

---

## CRUD Operations

The program allows users to perform operations such as:

- inserting a new client
- updating supplier information
- deleting bicycles from inventory
- displaying employee records
- managing spare parts stock

These operations are implemented through SQL queries executed from the C# application.

---

## Statistics Module

The application includes a module executing analytical SQL queries such as:

- quantities of spare parts sold per store
- quantities of bicycles sold per store
- list of customers and their membership program
- best customers based on total spending
- average order amount
- average number of parts per order

These queries simulate **basic business analytics for Velomax**.

