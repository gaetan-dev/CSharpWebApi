Drop database IF EXISTS Starter;
CREATE DATABASE Starter;

use Starter;

-- Client
Create Table Example (
Id INT NOT NULL AUTO_INCREMENT,
Prop1 varchar(50) NULL,
Prop2 varchar(50) NULL,
PRIMARY KEY (Id)
);