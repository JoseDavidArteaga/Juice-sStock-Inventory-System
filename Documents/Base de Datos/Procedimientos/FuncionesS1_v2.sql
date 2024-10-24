/*Lista de posibles funciones necesarias para el sprint 1*/

--Relacionadas a PRODUCTO (seguramente Sara querría esto en un paquete, pero 
--pailas, le puedo pasar el mio)

DROP FUNCTION producto_existe;
DROP FUNCTION agregar_producto;
DROP FUNCTION modificar_producto;
DROP FUNCTION eliminar_producto;
/*producto_existe : Diseñada para saber si un producto ya está en la base de datos, necesaria 
para diversas validaciones. RETORNA UN BOOLEANO 
¿El producto existe en la BD? 
SI -> TRUE
NO -> FALSE*/
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
/*agregar_producto: Agrega un producto a la base de datos, por defecto la cantidad
es cero y el estado activo. REVISAR EL ORDEN EN EL QUE DEBEN LLEGAR LOS PARAMETROS
Retorna un entero
¿El producto fue agregado?
SI -> 1
NO -> 0 */
CREATE OR REPLACE FUNCTION agregar_producto(
    id_producto PRODUCTO.ID_PROD%TYPE,
    nombre_producto PRODUCTO.NOMBRE_PROD%TYPE,
    categoria_producto PRODUCTO.CATEGORIA_PROD%TYPE,
    precio_producto PRODUCTO.PRECIO_PROD%TYPE,
    id_proveedor PRODUCTO.ID_PROV%TYPE
) RETURN NUMBER IS
BEGIN
    IF producto_existe(id_producto) THEN
        RETURN 0; 
    END IF;

    BEGIN
        INSERT INTO Producto (id_prod, nombre_prod, categoria_prod, precio_prod, cantidad_prod, estado_prod, id_prov)
        VALUES (id_producto, nombre_producto, categoria_producto, precio_producto, 0, 'ACTIVO', id_proveedor);       
        RETURN 1;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN 0;
    END;
END;
--------------------------------------------------------------------------------
/*modificar_producto: modifica un producto mediante su id. OJO, se piden dos ID
así no se modifique, debe ingresarse el "nuevo" id. que mierdota de implementacion,
pero yo solo hago lo del figma. Retorna un entero
¿El producto fue modificado?
SI -> 1
NO -> 0 */
CREATE OR REPLACE FUNCTION modificar_producto(
    id_producto PRODUCTO.ID_PROD%TYPE,
    nuevo_id_producto PRODUCTO.ID_PROD%TYPE,
    nuevo_nombre_producto PRODUCTO.NOMBRE_PROD%TYPE,
    nueva_categoria_producto PRODUCTO.CATEGORIA_PROD%TYPE,
    nuevo_precio_producto PRODUCTO.PRECIO_PROD%TYPE,
    nuevo_id_proveedor PRODUCTO.ID_PROV%TYPE
) RETURN NUMBER IS
BEGIN

    IF NOT producto_existe(id_producto) THEN
        RETURN 0; 
    END IF;

    IF id_producto != nuevo_id_producto AND producto_existe(nuevo_id_producto) THEN
        RETURN 0;
    END IF;

    BEGIN
        UPDATE Producto
        SET id_prod = nuevo_id_producto,
            nombre_prod = nuevo_nombre_producto,
            categoria_prod = nueva_categoria_producto,
            precio_prod = nuevo_precio_producto,
            id_prov = nuevo_id_proveedor
        WHERE id_prod = id_producto;

        RETURN 1;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN 0; 
    END;
END;
--------------------------------------------------------------------------------
/*eliminar_producto: esta ya se intuye, das un id y lo borra (por favor que pregunte
si se esta seguro)
¿El producto fue eliminado?
SI -> 1
NO -> 0 */
CREATE OR REPLACE FUNCTION eliminar_producto(p_id_prod PRODUCTO.ID_PROD%TYPE) RETURN NUMBER IS
BEGIN
    IF producto_existe(p_id_prod) THEN
        UPDATE Producto
        SET estado_prod = 'INACTIVO'
        WHERE id_prod = p_id_prod;
        RETURN 1;
    ELSE
        RETURN 0;
    END IF;
END eliminar_producto;
/




