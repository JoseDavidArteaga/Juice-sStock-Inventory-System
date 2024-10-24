/*Procedimientos y funciones necesarias para el sprint 2 */

--Secuencia y trigger necesarios para tin
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
-----------------------------------------------------------------
--Estas son tema de validaciones 
CREATE OR REPLACE FUNCTION producto_existe_nombre (
    nombre_producto IN Producto.nombre_prod%TYPE
) RETURN BOOLEAN
IS
    v_count NUMBER;
BEGIN
    -- Contar cuántos productos existen con el mismo nombre
    SELECT COUNT(*) INTO v_count 
    FROM Producto 
    WHERE nombre_prod = nombre_producto;

    -- Si el conteo es mayor que 0, significa que el producto ya existe
    IF v_count > 0 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;

CREATE OR REPLACE FUNCTION id_categoria_por_nombre (
    nombre_categoria IN Categoria_Producto.nombre_categoria%TYPE
) RETURN Categoria_Producto.id_categoria%TYPE
IS
    v_id_categoria Categoria_Producto.id_categoria%TYPE;
BEGIN
    -- Buscar el id de la categoría basada en el nombre
    SELECT id_categoria INTO v_id_categoria
    FROM Categoria_Producto
    WHERE nombre_categoria = id_categoria_por_nombre.nombre_categoria;  
    RETURN v_id_categoria;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Si no se encuentra, lanzar una excepción
        RAISE_APPLICATION_ERROR(-20001, 'Categoría no encontrada: ' || nombre_categoria);
END;

CREATE OR REPLACE FUNCTION id_proveedor_por_nombre (
    nombre_proveedor IN Proveedor.nombre_prov%TYPE
) RETURN Proveedor.id_prov%TYPE
IS
    v_id_prov Proveedor.id_prov%TYPE;
BEGIN
    -- Buscar el id del proveedor basado en el nombre
    SELECT id_prov INTO v_id_prov
    FROM Proveedor
    WHERE nombre_prov = id_proveedor_por_nombre.nombre_proveedor;

    -- Si se encuentra el proveedor, retornar el id
    RETURN v_id_prov;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Si no se encuentra, lanzar una excepción
        RAISE_APPLICATION_ERROR(-20001, 'Proveedor no encontrado: ' || nombre_proveedor);
END;
---------------------------------------------------------------
--Agregar producto: 0-> agregado, 1-> nombre repetido, 2-> llamen a Dios
CREATE OR REPLACE PROCEDURE agregar_producto_proc (
    nombre_producto    IN Producto.nombre_prod%TYPE,
    nombre_categoria   IN Categoria_Producto.nombre_categoria%TYPE,
    precio_producto    IN Producto.precio_prod%TYPE,
    nombre_proveedor   IN Proveedor.nombre_prov%TYPE,
    p_bandera          OUT NUMBER
)
IS
    v_id_categoria Categoria_Producto.id_categoria%TYPE;
    v_id_prov Proveedor.id_prov%TYPE;
BEGIN
    -- Verificar si el producto ya existe
    IF producto_existe_nombre(nombre_producto) THEN
        DBMS_OUTPUT.PUT_LINE('Error: Ya existe un producto con el mismo nombre.');
        p_bandera := 1;  -- Bandera 1 indica que el producto ya existe
        RETURN;
    END IF;

    -- Obtener el id de la categoría a partir del nombre
    v_id_categoria := id_categoria_por_nombre(nombre_categoria);

    -- Obtener el id del proveedor a partir del nombre
    v_id_prov := id_proveedor_por_nombre(nombre_proveedor);

    -- Intentar insertar el producto
    BEGIN
        INSERT INTO Producto (nombre_prod, id_categoria, precio_prod, cantidad_prod, estado_prod, id_prov)
        VALUES (nombre_producto, v_id_categoria, precio_producto, 0, 'ACTIVO', v_id_prov);
        
        DBMS_OUTPUT.PUT_LINE('Producto insertado exitosamente.');
        p_bandera := 0;  -- Bandera 0 indica que el producto se insertó correctamente
    EXCEPTION
        WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Error al insertar el producto: ' || SQLERRM);
            p_bandera := 2;  -- Bandera 2 indica que ocurrió un error diferente
    END;
END agregar_producto_proc;
----------------------------------------------------------------------------------------
--Mas para validar
CREATE OR REPLACE PROCEDURE obtener_cantidad_producto (
    p_nombre_prod IN Producto.nombre_prod%TYPE,
    p_cantidad_out OUT NUMBER
) AS
BEGIN
    -- Buscar la cantidad del producto basado en el nombre
    SELECT cantidad_prod INTO p_cantidad_out
    FROM Producto
    WHERE nombre_prod = p_nombre_prod;

    -- Si no se encuentra el producto, lanzar una excepción
    IF p_cantidad_out IS NULL THEN
        RAISE_APPLICATION_ERROR(-20001, 'Producto no encontrado: ' || p_nombre_prod);
    END IF;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Manejo de excepción si no se encuentra el producto
        RAISE_APPLICATION_ERROR(-20001, 'Producto no encontrado: ' || p_nombre_prod);
    WHEN OTHERS THEN
        -- Manejo de excepciones en caso de otros errores
        DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END obtener_cantidad_producto;
-----------------------------------------------------------------------------------------------
--Eliminar producto (temporalmente): 0 -> eliminado, 1-> hay una cantidad mayor a 0 (no lo elimina),
--2-> no existe, 3 -> SOS
CREATE OR REPLACE PROCEDURE eliminar_producto_proc (
    nombre_producto IN Producto.nombre_prod%TYPE,
    p_bandera OUT NUMBER
)
IS
    v_cantidad_prod NUMBER;
BEGIN
    -- Verificar si el producto existe
    IF NOT producto_existe_nombre(nombre_producto) THEN
        DBMS_OUTPUT.PUT_LINE('Error: El producto no existe.');
        p_bandera := 2;  -- Bandera 2 indica que el producto no existe
        RETURN;
    END IF;

    -- Obtener la cantidad del producto utilizando el nuevo procedimiento obtener_cantidad_producto
    obtener_cantidad_producto(nombre_producto, v_cantidad_prod);

    -- Verificar si la cantidad del producto es mayor que 0
    IF v_cantidad_prod > 0 THEN
        DBMS_OUTPUT.PUT_LINE('Error: No se puede eliminar el producto porque tiene una cantidad mayor a 0.');
        p_bandera := 1;  -- Bandera 1 indica que el producto tiene cantidad mayor que 0
        RETURN;
    END IF;

    -- Si la cantidad es 0, proceder a eliminar el producto
    DELETE FROM Producto
    WHERE nombre_prod = nombre_producto;

    DBMS_OUTPUT.PUT_LINE('Producto eliminado exitosamente.');
    p_bandera := 0;  -- Bandera 0 indica que el producto fue eliminado
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error al eliminar el producto: ' || SQLERRM);
        p_bandera := 3;  -- Bandera 3 indica que ocurrió un error diferente
END eliminar_producto_proc;


------------------------------------------------------------------------------------


