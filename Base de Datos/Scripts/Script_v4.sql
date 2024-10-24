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

DROP TABLE Proveedor;
-------------------------------------
-- Tabla para las categorías de productos
CREATE TABLE Categoria_Producto (
    id_categoria NUMBER PRIMARY KEY,
    nombre_categoria VARCHAR2(40) NOT NULL
);
DROP TABLE Categoria_Producto;

-- Tabla Producto con la clave compuesta y la relación con la tabla de categorías
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
--Inserts-----------------------------------------
--Categoria productos
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (1, 'HELADERIA');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (2, 'ACOMPAÑANTE');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (3, 'BEBIDA CALIENTE');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (4, 'BEBIDA FRIA');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (5, 'LIMONADA');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (6, 'GRANIZADO');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (7, 'VASO DE JUGO');
INSERT INTO Categoria_Producto (id_categoria, nombre_categoria) VALUES (8, 'JARRA DE JUGO');
-----------------
--Proveedores
INSERT INTO Proveedor VALUES (100, 'Zumo Vital', '3157852415', 'zumovital100@gmail.com', 'Calle 4 #12-10, Barrio Centro', 'ACTIVO');
INSERT INTO Proveedor VALUES (200, 'La Casa del Helado', '3224859612', 'chelado123@gmail.com', 'Carrera 8 #7-18, B. Bolivar', 'ACTIVO');
INSERT INTO Proveedor VALUES (300, 'Crocantes y Cía', '3114587625', 'ciacrocante@hotmail.com', 'Avenida Principal #15-25', 'ACTIVO');
INSERT INTO Proveedor VALUES (400, 'Horno Tradicional', '3109988547', 'alhornotrad@gmail.com', 'Calle 10 #9-30, B. La Paz', 'ACTIVO');
---------------------------------

