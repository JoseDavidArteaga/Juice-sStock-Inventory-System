--Eliminacion de tablas
DROP TABLE Proveedor CASCADE CONSTRAINTS;
DROP TABLE Categoria_Producto CASCADE CONSTRAINTS;
DROP TABLE Producto CASCADE CONSTRAINTS;
DROP TABLE USUARIO CASCADE CONSTRAINTS;
DROP TABLE MOVIMIENTO CASCADE CONSTRAINTS;
--Agregar en el siguiente orden:

CREATE TABLE Proveedor (
    id_prov NUMBER PRIMARY KEY,        
    nombre_prov VARCHAR2(50) NOT NULL, 
    telefono_prov VARCHAR2(15) NOT NULL,      
    correo_prov VARCHAR2(50),
    direccion_prov VARCHAR2(50),           
    estado_prov VARCHAR2(10) NOT NULL,      
    CONSTRAINT ck_estado_prov CHECK (estado_prov IN ('ACTIVO', 'INACTIVO')),
    CONSTRAINT ck_id_prov CHECK (id_prov > 0)
);



CREATE TABLE Categoria_Producto (
    id_categoria NUMBER PRIMARY KEY,
    nombre_categoria VARCHAR2(40) NOT NULL
);


CREATE TABLE Producto (
    id_prod NUMBER PRIMARY KEY,
    nombre_prod VARCHAR2(50) NOT NULL,
    id_categoria NUMBER NOT NULL,
    precio_prod NUMBER(10, 2) NOT NULL,
    cantidad_prod NUMBER NOT NULL,
    estado_prod VARCHAR2(10) NOT NULL,
    id_prov NUMBER,
    CONSTRAINT fk_categoria FOREIGN KEY (id_categoria) REFERENCES Categoria_Producto(id_categoria),
    CONSTRAINT fk_proveedor FOREIGN KEY (id_prov) REFERENCES Proveedor(id_prov),
    CONSTRAINT ck_estado_prod CHECK (estado_prod IN ('ACTIVO', 'INACTIVO')),
    CONSTRAINT ck_id_prod CHECK (id_prod > 0),
    CONSTRAINT ck_cantidad_prod CHECK (cantidad_prod >= 0)
);


CREATE TABLE USUARIO(
    Id_Usuario NUMBER(10) PRIMARY KEY,
    nom_Usuario varchar2(50),
    usuario varchar2(50),
    contrasena varchar2(50),
    CONSTRAINT ck_id_usuario CHECK (Id_Usuario > 0)    
);


CREATE TABLE MOVIMIENTO
(
    id_mov number PRIMARY KEY,
    id_prod number not null,
    cantidad_prod number not null,
    fecha_mov timestamp not null,
    precio_unitario_prod number not null,
    tipo_mov varchar2(10),
    CONSTRAINT ck_tipo_mov CHECK (tipo_mov IN ('ENTRADA', 'SALIDA'))
);

INSERT INTO USUARIO VALUES(100, 'Juice´s Stock', 'admin', '1234');
INSERT INTO USUARIO VALUES(300, 'Tester', 'pruebas', '1234');
commit;