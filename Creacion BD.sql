--Creacion Base de datos
CREATE DATABASE Prueba_Tecnica;

--Tablas

CREATE TABLE CONSUMO_POR_TRAMO (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Linea VARCHAR(255),
    Fecha DATE,
    Residencial FLOAT,
    Comercial FLOAT,
    Industrial FLOAT
);

CREATE TABLE COSTOS_POR_TRAMO (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Linea VARCHAR(255),
    Fecha DATE,
    Residencial FLOAT,
    Comercial FLOAT,
    Industrial FLOAT
);

CREATE TABLE PERDIDAS_POR_TRAMO (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Linea VARCHAR(255),
    Fecha DATE,
    Residencial FLOAT,
    Comercial FLOAT,
    Industrial FLOAT
);
