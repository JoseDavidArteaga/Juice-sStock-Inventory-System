CREATE TABLE Proveedor (
    id_prov NUMBER PRIMARY KEY,        
    nombre_prov VARCHAR2(30) NOT NULL, 
    telefono_prov VARCHAR2(15) NOT NULL,      
    correo_prov VARCHAR2(30),
    direccion_prov VARCHAR2(30),           
    estado_prov VARCHAR2(10) NOT NULL,      
    CONSTRAINT ck_estado_prov CHECK (estado_prov IN ('ACTIVO', 'INACTIVO'))
);

INSERT INTO Proveedor (id_prov, nombre_prov, telefono_prov, correo_prov, direccion_prov, estado_prov) 
VALUES (id_prov_value, nombre_prov_value, telefono_prov_value, correo_prov_value, direccion_prov_value, estado_prov_value);

DROP TABLE Proveedor;
------------------------------------------------------------------------------------------------
CREATE TABLE Producto (
    id_prod NUMBER PRIMARY KEY,            
    nombre_prod VARCHAR2(30) NOT NULL,    
    categoria_prod VARCHAR2(15) NOT NULL,  
    precio_prod NUMBER(10, 2) NOT NULL,    
    cantidad_prod NUMBER NOT NULL,
    id_prov NUMBER,                        
    CONSTRAINT fk_proveedor FOREIGN KEY (id_prov) REFERENCES Proveedor(id_prov),
    CONSTRAINT ck_categoria CHECK (categoria_prod IN ('BEBIDAS', 'FRITOS', 'HORNEADOS'))
);
INSERT INTO Producto (id_prod, nombre_prod, categoria_prod, precio_prod, id_prov)
VALUES (id_prod_value, nombre_prod_value, categoria_prod_value, precio_prod_value, id_prov_value);

DROP TABLE Producto;
------------------------------------------------------------------------------------------------
CREATE TABLE REGISTRO(
    id_registro NUMBER PRIMARY KEY,
    id_prod number NOT NULL,
    id_emp number not null,
    tipo_registro VARCHAR2(15) NOT NULL,
    fecha_registro TIMESTAMP not null,
    CONSTRAINT fk_registro FOREIGN KEY (id_prod) REFERENCES Producto(id_prod),
    CONSTRAINT ck_registro CHECK (tipo_registro IN ('ENTRADA', 'SALIDA'))    
);
DROP TABLE REGISTRO;
