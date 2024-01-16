CREATE TABLE DESIGNATIONS
(
DesignationId INT IDENTITY(1,1) PRIMARY KEY,
NAME VARCHAR(100) NOT NULL
);

CREATE TABLE EMPLOYEES
(
ID INT IDENTITY(1,1) PRIMARY KEY,
FIRSTNAME VARCHAR(25) NOT NULL,
LASTNAME VARCHAR(25) NOT NULL,
ADDRESS VARCHAR(100) NOT NULL,
CITY VARCHAR(25) NOT NULL,
EMAIL VARCHAR(50) NOT NULL,
DesignationId INT FOREIGN KEY REFERENCES DESIGNATIONS(DesignationId)
);

INSERT INTO DESIGNATIONS VALUES('Executive Manager'),('Quality Analyst'),('Human Resource'),('Sr. Manager'),('Data Analyst'),('Sr. Analyst')

INSERT INTO EMPLOYEES VALUES('John', 'Doe', '53 Avenue Street, NJ','New Jersey', 'john.doe@deloitte.com',1);
INSERT INTO EMPLOYEES VALUES('Jane', 'Doe', '54 Avenue Street, NJ','New Jersey', 'jane.doe@deloitte.com',1);
INSERT INTO EMPLOYEES VALUES('Jose', 'Lopez', '112 Brooklyn Street, CH','Chicago', 'jose.lopez@deloitte.com',2);
INSERT INTO EMPLOYEES VALUES('Diane', 'Carter', '1802 Carriage Court, DC','Washington DC', 'diane.carter@deloitte.com',2);
INSERT INTO EMPLOYEES VALUES('Shawn', 'Foster', '618 Broad Street, OH','Ohio', 'shawn.foster@deloitte.com',5);
INSERT INTO EMPLOYEES VALUES('Brenda', 'Fisher', '619 Johnny Lane, MX','Mexico', 'brenda.fisher@deloitte.com',6);
INSERT INTO EMPLOYEES VALUES('Sean', 'Hunter', '1352 Goff Avenue, NY','New York', 'sean.hunter@deloitte.com',4);