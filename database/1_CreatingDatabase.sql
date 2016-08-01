Drop database IF EXISTS Starter;
CREATE DATABASE Starter;

use Starter;

-- Client
Create Table Example (
Id varchar(50) NOT NULL,
Prop1 varchar(50) NULL,
Prop2 varchar(50) NULL,
PRIMARY KEY (Id)
);