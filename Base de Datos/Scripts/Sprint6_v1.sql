----------------------------------------------------------------------------------
/*                            TABLA MOVIMIENTO                                        */
----------------------------------------------------------------------------------
DROP TABLE MOVIMIENTO;

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

----------------------------------------------------------------------------------
/*                              SECUENCIA                                        */
----------------------------------------------------------------------------------
--SECUENCIA PARA EL ID DE MOV
CREATE SEQUENCE seq_movimiento_id
START WITH 100 
INCREMENT BY 10;
----------------------------------------------------------------------------------
/*                              TRIGGER                                        */
----------------------------------------------------------------------------------
--Trigger para guardar movimientos
CREATE OR REPLACE TRIGGER trg_registrar_movimiento
AFTER UPDATE OF cantidad_prod ON Producto
FOR EACH ROW
DECLARE
    v_tipo_mov VARCHAR2(10);
    v_cantidad_mov NUMBER;
BEGIN
    -- Determinamos el tipo de movimiento y la cantidad cambiada
    IF :NEW.cantidad_prod > :OLD.cantidad_prod THEN
        v_tipo_mov := 'ENTRADA';
        v_cantidad_mov := :NEW.cantidad_prod - :OLD.cantidad_prod;
    ELSIF :NEW.cantidad_prod < :OLD.cantidad_prod THEN
        v_tipo_mov := 'SALIDA';
        v_cantidad_mov := :OLD.cantidad_prod - :NEW.cantidad_prod;
    ELSE
        RETURN; -- Si no hubo cambio en cantidad, no se registra movimiento.
    END IF;

    -- Insertamos el registro del movimiento en la tabla Movimiento
    INSERT INTO Movimiento (
        id_mov,
        id_prod,
        cantidad_prod,
        fecha_mov,
        precio_unitario_prod,
        tipo_mov
    ) VALUES (
        seq_movimiento_id.NEXTVAL,    -- id del movimiento usando la secuencia
        :NEW.id_prod,                 -- id del producto
        v_cantidad_mov,               -- cantidad movida
        SYSDATE,                      -- fecha del movimiento
        :NEW.precio_prod,             -- precio unitario actual
        v_tipo_mov                    -- tipo de movimiento
    );
END;
----------------------------------------------------------------------------------
/*                              VISTAS                                        */
----------------------------------------------------------------------------------
--Vista general de movimientos
CREATE OR REPLACE VIEW vista_movimientos_general AS
SELECT
    TO_CHAR(m.fecha_mov, 'DD/MM/YY') AS "FECHA",
    p.nombre_prod AS "PRODUCTO",
    m.cantidad_prod AS "CANTIDAD",
    m.precio_unitario_prod AS "PRECIO UNITARIO",
    m.tipo_mov AS "TIPO DE MOVIMIENTO"
FROM
    Movimiento m
JOIN
    Producto p ON m.id_prod = p.id_prod;
---------------------------------------------------------------------------
--Vista de movimientos de entrada
CREATE OR REPLACE VIEW vista_movimientos_entrada AS
SELECT
    TO_CHAR(m.fecha_mov, 'DD/MM/YY') AS "FECHA",
    p.nombre_prod AS "PRODUCTO",
    m.cantidad_prod AS "CANTIDAD",
    m.precio_unitario_prod AS "PRECIO UNITARIO",
    m.tipo_mov AS "TIPO DE MOVIMIENTO"
FROM
    Movimiento m
JOIN
    Producto p ON m.id_prod = p.id_prod
WHERE
    m.tipo_mov = 'ENTRADA';

------------------------------------------------------------------------
--Vista de movimientos de salida
CREATE OR REPLACE VIEW vista_movimientos_salida AS
SELECT
    TO_CHAR(m.fecha_mov, 'DD/MM/YY') AS "FECHA",
    p.nombre_prod AS "PRODUCTO",
    m.cantidad_prod AS "CANTIDAD",
    m.precio_unitario_prod AS "PRECIO UNITARIO",
    m.tipo_mov AS "TIPO DE MOVIMIENTO"
FROM
    Movimiento m
JOIN
    Producto p ON m.id_prod = p.id_prod
WHERE
    m.tipo_mov = 'SALIDA';