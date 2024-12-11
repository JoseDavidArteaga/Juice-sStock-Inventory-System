--------------------------------------------------------------------------------
/*                              INDICES = 2                                       */
--------------------------------------------------------------------------------
CREATE INDEX PROD_ESTADO_IDX ON PRODUCTO (ESTADO_PROD);
CREATE INDEX PROV_ESTADO_IDX ON PROVEEDOR (ESTADO_PROV);
--------------------------------------------------------------------------------
/*                              VISTAS = 3                                      */
--------------------------------------------------------------------------------
CREATE OR REPLACE VIEW VISTA_PRODUCTOS AS
    SELECT id_prod, nombre_prod, nombre_categoria, nombre_prov, precio_prod, cantidad_prod
    FROM PRODUCTO NATURAL JOIN CATEGORIA_PRODUCTO NATURAL JOIN PROVEEDOR
    WHERE estado_prod = 'ACTIVO'
    ORDER BY NOMBRE_PROD ASC;
--------------------------------------------------------------------------------
CREATE OR REPLACE VIEW vista_proveedores AS
   SELECT 
   id_prov as "Identificador", 
   nombre_prov as "Nombre",
   telefono_prov as "Telefono",
   correo_prov  as "Correo Electronico",
   direccion_prov as "Dirección"
   FROM PROVEEDOR
   WHERE estado_prov = 'ACTIVO';
--------------------------------------------------------------------------------
   
CREATE OR REPLACE VIEW vista_movimientos_general AS
SELECT
    m.fecha_mov AS "FECHA",
    p.nombre_prod AS "PRODUCTO",
    m.cantidad_prod AS "CANTIDAD",
    m.precio_unitario_prod AS "PRECIO UNITARIO",
    m.tipo_mov AS "TIPO DE MOVIMIENTO"
FROM
    Movimiento m
JOIN
    Producto p ON m.id_prod = p.id_prod
ORDER BY fecha_mov DESC;   

--------------------------------------------------------------------------------
/*                              SECUENCIAS = 3                                      */
--------------------------------------------------------------------------------
CREATE SEQUENCE seq_producto_id
START WITH 100 
INCREMENT BY 10;
--------------------------------------------------------------------------------
CREATE SEQUENCE seq_proveedor_id
START WITH 101 
INCREMENT BY 11;
--------------------------------------------------------------------------------
CREATE SEQUENCE seq_movimiento_id
START WITH 100 
INCREMENT BY 10;

--------------------------------------------------------------------------------
/*                              DISPARADORES  = 4                                     */
--------------------------------------------------------------------------------
CREATE OR REPLACE TRIGGER trg_auto_increment_producto_id
BEFORE INSERT ON Producto
FOR EACH ROW
BEGIN
  IF :NEW.id_prod IS NULL THEN
    SELECT seq_producto_id.NEXTVAL INTO :NEW.id_prod FROM dual;
  END IF;
END;
--------------------------------------------------------------------------------
CREATE OR REPLACE TRIGGER trg_prevent_duplicate_usuario
BEFORE INSERT ON USUARIO
FOR EACH ROW
DECLARE
    v_count NUMBER;
BEGIN
    -- Contar cuántos usuarios existen con el mismo nombre de usuario
    SELECT COUNT(*)
    INTO v_count
    FROM USUARIO
    WHERE usuario = :NEW.usuario;

    -- Si ya existe al menos un usuario con el mismo nombre, lanzar un error
    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'El usuario ya existe en la base de datos.');
    END IF;
END trg_prevent_duplicate_usuario;
--------------------------------------------------------------------------------
CREATE OR REPLACE TRIGGER trg_auto_increment_proovedor_id
BEFORE INSERT ON Proveedor
FOR EACH ROW
BEGIN
  IF :NEW.id_prov IS NULL THEN
    SELECT seq_proveedor_id.NEXTVAL INTO :NEW.id_prov FROM dual;
  END IF;
END;
--------------------------------------------------------------------------------
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

--------------------------------------------------------------------------------
/*                              FUNCIONES   = 7                                  */
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
/*                              PRODUCTO    = 4                                */
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION producto_existe(id_producto PRODUCTO.ID_PROD%TYPE) RETURN BOOLEAN IS
    v_count NUMBER;
BEGIN
    SELECT COUNT(*) INTO v_count
    FROM Producto
    WHERE id_prod = id_producto;

    IF v_count > 0 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION producto_existe_nombre (
    nombre_producto IN Producto.nombre_prod%TYPE
) RETURN BOOLEAN
IS
    v_count NUMBER;
BEGIN
    -- Contar cuántos productos existen con el mismo nombre (independiente de mayúsculas/minúsculas)
    SELECT COUNT(*) INTO v_count 
    FROM Producto 
    WHERE UPPER(nombre_prod) = UPPER(nombre_producto);

    -- Si el conteo es mayor que 0, significa que el producto ya existe
    RETURN v_count > 0;
END;
--------------------------------------------------------------------------------
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
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION id_producto_por_nombre (
    nombre_producto IN Producto.nombre_prod%TYPE
) RETURN Producto.id_prod%TYPE
IS
    v_id_prod Producto.id_prod%TYPE;
BEGIN
    -- Buscar el id del producto basado en el nombre
    SELECT id_prod INTO v_id_prod
    FROM Producto
    WHERE nombre_prod = nombre_producto;

    -- Si se encuentra el producto, retornar el id
    RETURN v_id_prod;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Si no se encuentra, lanzar una excepción
        RAISE_APPLICATION_ERROR(-20001, 'Producto no encontrado: ' || nombre_producto);
END;
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
/*                             PROVEEDOR  = 3                                   */
--------------------------------------------------------------------------------
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
--------------------------------------------------------------------------------
create or replace FUNCTION proveedor_existe_nombre (
    nombre_proveedor IN Proveedor.nombre_prov%TYPE
) RETURN BOOLEAN
IS
    v_count NUMBER;
BEGIN
    -- Contar cuántos proveedores existen con el mismo nombre
    SELECT COUNT(*) INTO v_count 
    FROM Proveedor 
    WHERE UPPER(nombre_prov) = UPPER(nombre_proveedor);

    -- Si el conteo es mayor que 0, significa que el proveedor ya existe
    IF v_count > 0 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END proveedor_existe_nombre;
--------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION proveedor_tiene_productos (
    nombre_proveedor IN Proveedor.nombre_prov%TYPE
) RETURN BOOLEAN
IS
    v_id_prov   Proveedor.id_prov%TYPE;
    v_count     NUMBER;
BEGIN
    -- Obtener el id del proveedor usando la función id_proveedor_por_nombre
    v_id_prov := id_proveedor_por_nombre(nombre_proveedor);

    -- Contar productos activos asociados a este proveedor
    SELECT COUNT(*) INTO v_count
    FROM Producto
    WHERE id_prov = v_id_prov
      AND estado_prod = 'ACTIVO';

    -- Retornar true si el proveedor tiene productos activos asociados
    RETURN v_count > 0;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN FALSE; -- Si el proveedor no existe, retorna FALSE
END;
----------------------------------------------------------------------------------
/*                             PROCEDIMIENTOS  = 13                                 */
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
/*                             PRODUCTO = 7                                         */
----------------------------------------------------------------------------------
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
----------------------------------------------------------------------------------------
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
-----------------------------------------------------------------------------------------
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
-----------------------------------------------------------------
CREATE OR REPLACE PROCEDURE eliminar_producto_proc (
    nombre_producto IN Producto.nombre_prod%TYPE,
    p_bandera OUT NUMBER
)
IS
    v_cantidad_prod NUMBER;
    v_estado_prod Producto.estado_prod%TYPE;
BEGIN
    -- Verificar si el producto existe
    IF NOT producto_existe_nombre(nombre_producto) THEN
        DBMS_OUTPUT.PUT_LINE('Error: El producto no existe.');
        p_bandera := 2;  -- Bandera 2 indica que el producto no existe
        RETURN;
    END IF;

    -- Obtener la cantidad del producto utilizando el procedimiento obtener_cantidad_producto
    obtener_cantidad_producto(nombre_producto, v_cantidad_prod);

    -- Verificar si la cantidad del producto es mayor que 0
    IF v_cantidad_prod > 0 THEN
        DBMS_OUTPUT.PUT_LINE('Error: No se puede desactivar el producto porque tiene una cantidad mayor a 0.');
        p_bandera := 1;  -- Bandera 1 indica que el producto tiene cantidad mayor que 0
        RETURN;
    END IF;

    -- Verificar si el estado ya es 'INACTIVO'
    SELECT estado_prod INTO v_estado_prod
    FROM Producto
    WHERE nombre_prod = nombre_producto;

    IF v_estado_prod = 'INACTIVO' THEN
        DBMS_OUTPUT.PUT_LINE('El producto ya está inactivo.');
        p_bandera := 4;  -- Bandera 4 indica que el producto ya estaba inactivo
        RETURN;
    END IF;

    -- Actualizar el estado del producto a 'INACTIVO'
    UPDATE Producto
    SET estado_prod = 'INACTIVO'
    WHERE nombre_prod = nombre_producto;

    DBMS_OUTPUT.PUT_LINE('Producto desactivado exitosamente.');
    p_bandera := 0;  -- Bandera 0 indica que el producto fue desactivado
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error al desactivar el producto: ' || SQLERRM);
        p_bandera := 3;  -- Bandera 3 indica que ocurrió un error diferente
END eliminar_producto_proc;
--------------------------------------------------------------------------------
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
    v_estado_producto Producto.estado_prod%TYPE;
BEGIN
    -- Verificar si el producto ya existe
    SELECT estado_prod 
    INTO v_estado_producto 
    FROM Producto 
    WHERE UPPER(nombre_prod) = UPPER(nombre_producto)
    FOR UPDATE;

    -- Si el producto existe y su estado es INACTIVO, modificarlo
    IF v_estado_producto = 'INACTIVO' THEN
        -- Obtener el id de la categoría a partir del nombre
        v_id_categoria := id_categoria_por_nombre(nombre_categoria);

        -- Obtener el id del proveedor a partir del nombre
        v_id_prov := id_proveedor_por_nombre(nombre_proveedor);

        -- Modificar el producto existente
        UPDATE Producto
        SET id_categoria = v_id_categoria,
            precio_prod = precio_producto,
            cantidad_prod = 0,
            estado_prod = 'ACTIVO',
            id_prov = v_id_prov
        WHERE UPPER(nombre_prod) = UPPER(nombre_producto);

        DBMS_OUTPUT.PUT_LINE('Producto actualizado y activado.');
        p_bandera := 0;  -- Bandera 0 indica que el producto fue actualizado y activado
        RETURN;
    END IF;

    -- Si el producto ya existe y está activo, devolver error
    DBMS_OUTPUT.PUT_LINE('Error: Ya existe un producto con el mismo nombre y está activo.');
    p_bandera := 1;  -- Bandera 1 indica que el producto ya existe y está activo
    RETURN;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Si el producto no existe, intentar insertarlo
        BEGIN
            -- Obtener el id de la categoría a partir del nombre
            v_id_categoria := id_categoria_por_nombre(nombre_categoria);

            -- Obtener el id del proveedor a partir del nombre
            v_id_prov := id_proveedor_por_nombre(nombre_proveedor);

            -- Insertar el nuevo producto
            INSERT INTO Producto (nombre_prod, id_categoria, precio_prod, cantidad_prod, estado_prod, id_prov)
            VALUES (nombre_producto, v_id_categoria, precio_producto, 0, 'ACTIVO', v_id_prov);

            DBMS_OUTPUT.PUT_LINE('Producto insertado exitosamente.');
            p_bandera := 0;  -- Bandera 0 indica que el producto se insertó correctamente
        EXCEPTION
            WHEN OTHERS THEN
                DBMS_OUTPUT.PUT_LINE('Error al insertar el producto: ' || SQLERRM);
                p_bandera := 2;  -- Bandera 2 indica que ocurrió un error diferente
        END;

    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error al verificar el producto: ' || SQLERRM);
        p_bandera := 2;  -- Bandera 2 indica que ocurrió un error diferente
END agregar_producto_proc;

----------------------------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE modificar_producto_proc (
    nombre_actual IN Producto.nombre_prod%TYPE,
    nuevo_nombre IN Producto.nombre_prod%TYPE,
    nueva_categoria IN Categoria_Producto.NOMBRE_CATEGORIA%TYPE,
    nuevo_proveedor IN Proveedor.NOMBRE_PROV%TYPE,
    nuevo_precio IN Producto.precio_prod%TYPE,
    p_bandera OUT NUMBER
)
IS
    v_id_categoria Producto.id_categoria%TYPE;
    v_id_proveedor Producto.id_prov%TYPE;
BEGIN
    -- Verificar si el producto a modificar existe
    IF NOT producto_existe_nombre(nombre_actual) THEN
        DBMS_OUTPUT.PUT_LINE('Error: El producto a modificar no existe.');
        p_bandera := 2;  -- Bandera 2 por error
        RETURN;
    END IF;

    -- Verificar si el nuevo nombre ya existe (y no es el mismo producto)
    IF producto_existe_nombre(nuevo_nombre) AND nombre_actual != nuevo_nombre THEN
        DBMS_OUTPUT.PUT_LINE('Error: El nuevo nombre del producto ya está en uso.');
        p_bandera := 1;  -- Bandera 1 por nombre duplicado
        RETURN;
    END IF;

    -- Obtener el ID de la nueva categoría y el nuevo proveedor
    v_id_categoria := id_categoria_por_nombre(nueva_categoria);
    v_id_proveedor := id_proveedor_por_nombre(nuevo_proveedor);

    -- Actualizar el producto
    UPDATE Producto
    SET nombre_prod = nuevo_nombre,
        id_categoria = v_id_categoria,
        id_prov = v_id_proveedor,
        precio_prod = nuevo_precio
    WHERE nombre_prod = nombre_actual;

    DBMS_OUTPUT.PUT_LINE('Producto actualizado correctamente.');
    p_bandera := 0;  -- Bandera 0 por éxito
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Error al actualizar el producto: ' || SQLERRM);
        p_bandera := 2;  -- Bandera 2 por error
END modificar_producto_proc;
----------------------------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE obtener_detalles_producto (
    p_nombre_producto IN Producto.nombre_prod%TYPE,
    p_precio          OUT Producto.precio_prod%TYPE,
    p_nombre_proveedor OUT Proveedor.nombre_prov%TYPE,
    p_nombre_categoria OUT Categoria_Producto.nombre_categoria%TYPE
)
IS
BEGIN
    -- Intentar obtener los detalles del producto
    SELECT 
        p.precio_prod, 
        prov.nombre_prov, 
        cat.nombre_categoria
    INTO 
        p_precio, 
        p_nombre_proveedor, 
        p_nombre_categoria
    FROM 
        Producto p
    JOIN 
        Proveedor prov ON p.id_prov = prov.id_prov
    JOIN 
        Categoria_Producto cat ON p.id_categoria = cat.id_categoria
    WHERE 
        p.nombre_prod = p_nombre_producto AND p.estado_prod = 'ACTIVO';

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Manejar el caso en que el producto no exista o esté inactivo
        p_precio := -1;
        p_nombre_proveedor := NULL;
        p_nombre_categoria := NULL;
        DBMS_OUTPUT.PUT_LINE('El producto no existe o está inactivo.');
    WHEN OTHERS THEN
        -- Manejar cualquier otro error
        DBMS_OUTPUT.PUT_LINE('Error al obtener los detalles del producto: ' || SQLERRM);
        p_precio := -2;
        p_nombre_proveedor := NULL;
        p_nombre_categoria := NULL;
END obtener_detalles_producto;
--------------------------------------------------------------------------------
----------------------------------------------------------------------------------
/*                             PROVEEDOR = 4                                    */
----------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE eliminar_proveedor (
    p_nombre_proveedor IN Proveedor.nombre_prov%TYPE,
    p_resultado        OUT NUMBER
)
IS
BEGIN
    -- Verificar si el proveedor existe
    IF NOT proveedor_existe_nombre(p_nombre_proveedor) THEN
        p_resultado := 2;  -- Proveedor no encontrado
        RETURN;
    END IF;

    -- Verificar si el proveedor tiene productos asociados
    IF proveedor_tiene_productos(p_nombre_proveedor) THEN
        p_resultado := 1;  -- No se puede desactivar porque tiene productos asociados
        RETURN;
    END IF;

    -- Cambiar el estado del proveedor a INACTIVO
    UPDATE Proveedor
    SET estado_prov = 'INACTIVO'
    WHERE UPPER(nombre_prov) = UPPER(p_nombre_proveedor);

    p_resultado := 0;  -- Desactivación exitosa

EXCEPTION
    WHEN OTHERS THEN
        p_resultado := 3;  -- Otro tipo de error
END eliminar_proveedor;
---------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE agregar_proveedor (
    p_nombre     IN Proveedor.nombre_prov%TYPE,
    p_telefono   IN Proveedor.telefono_prov%TYPE,
    p_correo     IN Proveedor.correo_prov%TYPE,
    p_direccion  IN Proveedor.direccion_prov%TYPE,
    p_resultado  OUT NUMBER
)
IS
    v_estado_prov Proveedor.estado_prov%TYPE;
BEGIN
    -- Verificar si el proveedor ya existe
    IF proveedor_existe_nombre(p_nombre) THEN
        -- Verificar el estado del proveedor
        SELECT estado_prov INTO v_estado_prov
        FROM Proveedor
        WHERE nombre_prov = p_nombre;

        IF v_estado_prov = 'INACTIVO' THEN
            -- Modificar el proveedor con el nuevo estado 'ACTIVO'
            UPDATE Proveedor
            SET 
                telefono_prov = p_telefono,
                correo_prov = p_correo,
                direccion_prov = p_direccion,
                estado_prov = 'ACTIVO'
            WHERE nombre_prov = p_nombre;
            p_resultado := 0;  -- Proveedor modificado correctamente
        ELSE
            p_resultado := 1;  -- Proveedor ya activo
        END IF;
    ELSE
        -- Intentar insertar el nuevo proveedor
        BEGIN
            INSERT INTO Proveedor (
                nombre_prov, 
                telefono_prov, 
                correo_prov, 
                direccion_prov, 
                estado_prov
            ) VALUES (
                p_nombre, 
                p_telefono, 
                p_correo, 
                p_direccion, 
                'ACTIVO' -- Estado por defecto
            );
            p_resultado := 0;  -- Proveedor agregado correctamente
        EXCEPTION
            WHEN OTHERS THEN
                p_resultado := 2;  -- Otro tipo de error
        END;
    END IF;
END;
---------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE modificar_proveedor_proc (
    p_nombre_actual    IN Proveedor.nombre_prov%TYPE,
    p_nuevo_nombre     IN Proveedor.nombre_prov%TYPE,
    p_nuevo_telefono   IN Proveedor.telefono_prov%TYPE,
    p_nuevo_correo     IN Proveedor.correo_prov%TYPE,
    p_nueva_direccion  IN Proveedor.direccion_prov%TYPE,
    p_resultado        OUT NUMBER
)
IS
BEGIN
    -- Verificar si el proveedor actual existe
    IF NOT proveedor_existe_nombre(p_nombre_actual) THEN
        p_resultado := 2;  -- El proveedor a modificar no existe
        RETURN;
    END IF;

    -- Verificar si el nuevo nombre ya está en uso por otro proveedor
    IF UPPER(p_nuevo_nombre) <> UPPER(p_nombre_actual) 
       AND proveedor_existe_nombre(p_nuevo_nombre) THEN
        p_resultado := 1;  -- El nuevo nombre ya está en uso
        RETURN;
    END IF;

    -- Actualizar los datos del proveedor
    UPDATE Proveedor
    SET nombre_prov = p_nuevo_nombre,
        telefono_prov = p_nuevo_telefono,
        correo_prov = p_nuevo_correo,
        direccion_prov = p_nueva_direccion
    WHERE UPPER(nombre_prov) = UPPER(p_nombre_actual);

    -- Confirmar la actualización
    IF SQL%ROWCOUNT > 0 THEN
        p_resultado := 0;  -- Actualización exitosa
    ELSE
        p_resultado := 2;  -- Error inesperado (no se modificó ninguna fila)
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        p_resultado := 2;  -- Otro tipo de error
END modificar_proveedor_proc;
---------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE obtener_detalles_proveedor (
    p_nombre_proveedor  IN Proveedor.nombre_prov%TYPE,
    p_telefono          OUT Proveedor.telefono_prov%TYPE,
    p_correo            OUT Proveedor.correo_prov%TYPE,
    p_direccion         OUT Proveedor.direccion_prov%TYPE
)
IS
BEGIN
    -- Intentar obtener los detalles del proveedor
    SELECT 
        telefono_prov, 
        correo_prov, 
        direccion_prov
    INTO 
        p_telefono, 
        p_correo, 
        p_direccion
    FROM 
        Proveedor
    WHERE 
        nombre_prov = p_nombre_proveedor
        AND estado_prov = 'ACTIVO';

EXCEPTION                                                                       
    WHEN NO_DATA_FOUND THEN
        -- Manejar el caso en que el proveedor no exista o esté inactivo        
        p_telefono := NULL;                                                     
        p_correo := NULL;                                                       
        p_direccion := NULL;                                                    
        DBMS_OUTPUT.PUT_LINE('El proveedor no existe o está inactivo.');        
    WHEN OTHERS THEN                                                            
        -- Manejar cualquier otro error                                         
        DBMS_OUTPUT.PUT_LINE('Error al obtener los detalles del proveedor: ' || SQLERRM);
        p_telefono := NULL;                                                     
        p_correo := NULL;                                                       
        p_direccion := NULL;                                                    
END obtener_detalles_proveedor;                                                 
--------------------------------------------------------------------------------
/*                             USUARIO =2                                       */
--------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE verificar_credenciales(                             
    p_usuario IN VARCHAR2,                                                      
    p_contrasena IN VARCHAR2,                                                   
    p_resultado OUT NUMBER                                                      
) IS                                                                            
    v_contrasena USUARIO.contrasena%TYPE;                                       
BEGIN                                                                           
    -- Verificar si el usuario existe                                           
    SELECT contrasena                                                           
    INTO v_contrasena                                                           
    FROM USUARIO                                                        
    WHERE usuario = p_usuario;                                            
    
    -- Verificar si la contraseña es correcta
    IF v_contrasena = p_contrasena THEN
        p_resultado := 0;  -- Usuario y contraseña correctos
    ELSE
        p_resultado := 1;  -- Contraseña incorrecta
    END IF;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_resultado := 2;  -- El usuario no existe
    WHEN OTHERS THEN
        p_resultado := 3;  -- Otro tipo de error
END verificar_credenciales;
---------------------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE obtener_nombre_usuario(
    p_usuario IN VARCHAR2,
    p_nom_usuario OUT VARCHAR2
) AS
BEGIN
    -- Intenta recuperar el nombre del usuario basado en el campo usuario
    SELECT nom_Usuario
    INTO p_nom_usuario
    FROM USUARIO
    WHERE usuario = p_usuario;

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        -- Si no encuentra el usuario, devuelve NULL en el parámetro de salida
        p_nom_usuario := NULL;
    WHEN OTHERS THEN
        -- Manejo de otros errores inesperados
        p_nom_usuario := NULL;
        RAISE;
END obtener_nombre_usuario;
--------------------------------------------------------------------------------