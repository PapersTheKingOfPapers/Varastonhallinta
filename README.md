# Varastonhallinta

SQL Koodi Tablen luomiseen:
 
CREATE TABLE Tuotteet(
	id INT primary key,
	tuotenimi varchar(50) not null,
	tuotenhinta INT not null,
	varastoSaldo INT not null
);