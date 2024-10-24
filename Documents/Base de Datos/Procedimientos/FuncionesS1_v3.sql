CREATE SEQUENCE seq_producto_id
START WITH 100 
INCREMENT BY 10;

CREATE OR REPLACE TRIGGER trg_auto_increment_producto_id
BEFORE INSERT ON Producto
FOR EACH ROW
BEGIN
  IF :NEW.id_prod IS NULL THEN
    SELECT seq_producto_id.NEXTVAL INTO :NEW.id_prod FROM dual;
  END IF;
END;

CREATE OR REPLACE PROCEDURE agregar_producto_proc (
    nombre_producto    IN Producto.nombre_prod%TYPE,
    categoria_producto IN Producto.categoria_prod%TYPE,
    precio_producto    IN Producto.precio_prod%TYPE,
    id_proveedor       IN Producto.id_prov%TYPE
)
IS
BEGIN
    -- Intentar insertar un nuevo producto con cantidad 0 y estado 'ACTIVO'
    BEGIN
        INSERT INTO Producto (nombre_prod, categoria_prod, precio_prod, cantidad_prod, estado_prod, id_prov)
        VALUES (nombre_producto, categoria_producto, precio_producto, 0, 'ACTIVO', id_proveedor);
        
        DBMS_OUTPUT.PUT_LINE('Producto insertado exitosamente.');
    EXCEPTION
        WHEN OTHERS THEN
            -- Manejo de excepciones en caso de errores
            DBMS_OUTPUT.PUT_LINE('Error al insertar el producto: ' || SQLERRM);
    END;
END;

BEGIN
  agregar_producto_proc('Jugo de Fresa', 'VASO DE JUGO', 5500, 100);
END;


CREATE OR REPLACE PROCEDURE agregar_cantidad_procedimiento (
    p_nombre_prod IN Producto.nombre_prod%TYPE,
    p_cantidad_agregar NUMBER
) AS
    v_id_prod Producto.id_prod%TYPE; -- Variable para almacenar el id del producto
BEGIN
    -- Obtener el id del producto a partir del nombre
    v_id_prod := id_producto_por_nombre(p_nombre_prod);

    -- Verificar si el producto existe
    IF producto_existe(v_id_prod) THEN
        UPDATE Producto
        SET cantidad_prod = cantidad_prod + p_cantidad_agregar
        WHERE id_prod = v_id_prod;
        
        DBMS_OUTPUT.PUT_LINE('Cantidad actualizada exitosamente.');
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'El producto no existe.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END agregar_cantidad_procedimiento;

SET SERVEROUTPUT ON
BEGIN
    agregar_cantidad_procedimiento('Helado de limón', 10);
END;

CREATE OR REPLACE PROCEDURE eliminar_cantidad_procedimiento (
    p_nombre_prod IN Producto.nombre_prod%TYPE,
    p_cantidad_eliminar NUMBER
) AS
    v_id_prod Producto.id_prod%TYPE; -- Variable para almacenar el id del producto
    v_cantidad_actual NUMBER;
BEGIN
    -- Obtener el id del producto a partir del nombre
    v_id_prod := id_producto_por_nombre(p_nombre_prod);

    -- Verificar si el producto existe
    IF producto_existe(v_id_prod) THEN

        SELECT cantidad_prod INTO v_cantidad_actual
        FROM Producto
        WHERE id_prod = v_id_prod;

        IF p_cantidad_eliminar <= v_cantidad_actual THEN
            UPDATE Producto
            SET cantidad_prod = cantidad_prod - p_cantidad_eliminar
            WHERE id_prod = v_id_prod; 

            DBMS_OUTPUT.PUT_LINE('Cantidad eliminada exitosamente.');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Error: No se puede eliminar más cantidad de la que existe.');
        END IF;
    ELSE
        DBMS_OUTPUT.PUT_LINE('Error: El producto no existe.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END eliminar_cantidad_procedimiento;

SET SERVEROUTPUT ON
BEGIN
    eliminar_cantidad_procedimiento('Helado de limón', 5);
END;





