/* 
   Please note that you don't need to run the create table queries as the program will auto-generate 
   these on startup if they are not already present. You will however be required to do:
   - Create the database (Leave default or configure name in the configuration file
   - Create an employee user (Or use the small query below the employee table)
*/

DROP DATABASE IF EXISTS BetterPizzaApp_db;
CREATE DATABASE BetterPizzaApp_db;
USE BetterPizzaApp_db;

CREATE TABLE IF NOT EXISTS tbl_employees (
    ID INT AUTO_INCREMENT NOT NULL,
    username VARCHAR(30) NOT NULL,
    password VARCHAR(30) NOT NULL,
    employeeKey VARCHAR(10) NOT NULL,
    PRIMARY KEY (ID),
    UNIQUE (employeeKey)
)engine=innodb;

INSERT INTO tbl_employees VALUES (NULL,'Admin','Test','556FTJJ89');

CREATE TABLE IF NOT EXISTS tbl_receipts (
    ID INT AUTO_INCREMENT NOT NULL,
    employeeKey VARCHAR(10) NOT NULL,
    basePrice DECIMAL NOT NULL,
    deliveryPrice DECIMAL NOT NULL,
    finalPrice DECIMAL NOT NULL,
    timestamp DATETIME NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (employeeKey) REFERENCES tbl_employees(employeeKey)
)engine=innodb;

CREATE TABLE IF NOT EXISTS tbl_pizzas (
    ID INT AUTO_INCREMENT NOT NULL,
    size VARCHAR(6) NOT NULL,
    toppings VARCHAR(200) NOT NULL,
    price DECIMAL NOT NULL,
    receiptID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (receiptID) REFERENCES tbl_receipts(ID)
)engine=innodb;

CREATE TABLE IF NOT EXISTS tbl_sides (
    ID INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(20) NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL NOT NULL,
    receiptID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (receiptID) REFERENCES tbl_receipts(ID)
)engine=innodb;

CREATE TABLE IF NOT EXISTS tbl_drinks (
    ID INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(20) NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL NOT NULL,
    receiptID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (receiptID) REFERENCES tbl_receipts(ID)
)engine=innodb;

CREATE TABLE IF NOT EXISTS tbl_customers (
    ID INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(50) NOT NULL,
    address VARCHAR(50) NOT NULL,
    postcode VARCHAR(6),
    receiptID INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ID) REFERENCES tbl_receipts(ID)
)engine=innodb;