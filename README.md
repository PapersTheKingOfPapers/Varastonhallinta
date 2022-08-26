# Varastonhallinta

SQL Koodi Tablen luomiseen:
 
CREATE TABLE Tuotteet(
	id int IDENTITY(1,1) PRIMARY KEY,
	tuotenimi varchar(50) not null,
	tuotenhinta int not null,
	varastoSaldo int not null
);