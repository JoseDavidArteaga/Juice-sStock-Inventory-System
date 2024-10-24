CREATE TABLE Proveedor (
    id_prov NUMBER PRIMARY KEY,        
    nombre_prov VARCHAR2(30) NOT NULL, 
    telefono_prov VARCHAR2(15) NOT NULL,      
    correo_prov VARCHAR2(30),
    direccion_prov VARCHAR2(30),           
    estado_prov VARCHAR2(10) NOT NULL,      
    CONSTRAINT ck_estado_prov CHECK (estado_prov IN ('ACTIVO', 'INACTIVO')),
    CONSTRAINT ck_id_prov CHECK (id_prov > 0)
);

DROP TABLE Proveedor;
------------------------------------------------------------------------------------------------
CREATE TABLE Producto (
    id_prod NUMBER PRIMARY KEY,
    nombre_prod VARCHAR2(30) NOT NULL,
    categoria_prod VARCHAR2(15) NOT NULL,
    precio_prod NUMBER(10, 2) NOT NULL,
    cantidad_prod NUMBER NOT NULL,
    estado_prod VARCHAR2(10) NOT NULL,
    id_prov NUMBER,
    CONSTRAINT fk_proveedor FOREIGN KEY (id_prov) REFERENCES Proveedor(id_prov),
    CONSTRAINT ck_categoria CHECK (categoria_prod IN ('HELADERIA', 'ACOMPAÑANTE', 'BEBIDA CALIENTE', 'BEBIDA FRIA', 'LIMONADA', 'GRANIZADO', 'VASO DE JUGO', 'JARRA DE JUGO')),
    CONSTRAINT ck_estado_prod CHECK (estado_prod IN ('ACTIVO', 'INACTIVO')),
    CONSTRAINT ck_id_prod CHECK (id_prod > 0),
    CONSTRAINT ck_cantidad_prod CHECK (cantidad_prod >= 0)
);

DROP TABLE Producto;
------------------------------------------------------------------------------------------------
CREATE TABLE REGISTRO(
    id_registro NUMBER PRIMARY KEY,
    id_prod number NOT NULL,
    tipo_registro VARCHAR2(15) NOT NULL,
    fecha_registro TIMESTAMP not null,
    CONSTRAINT fk_registro FOREIGN KEY (id_prod) REFERENCES Producto(id_prod),
    CONSTRAINT ck_registro CHECK (tipo_registro IN ('ENTRADA', 'SALIDA')), 
    CONSTRAINT ck_id_reg CHECK (id_registro > 0)
);
DROP TABLE REGISTRO;
