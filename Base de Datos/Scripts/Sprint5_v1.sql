--Secuencia necesaria para asignar id en proovedores
CREATE SEQUENCE seq_proveedor_id
START WITH 101 
INCREMENT BY 11;

--Disparador para poner el id del proveedor
CREATE OR REPLACE TRIGGER trg_auto_increment_proovedor_id
BEFORE INSERT ON Proveedor
FOR EACH ROW
BEGIN
  IF :NEW.id_prov IS NULL THEN
    SELECT seq_proveedor_id.NEXTVAL INTO :NEW.id_prov FROM dual;
  END IF;
END;

----------------------------------------------------------------------------------
/*                              FUNCIONES                                        */
----------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION proveedor_existe_nombre (
    nombre_proveedor IN Proveedor.nombre_prov%TYPE
) RETURN BOOLEAN
IS
    v_count NUMBER;
BEGIN
    -- Contar cuántos proveedores existen con el mismo nombre
    SELECT COUNT(*) INTO v_count 
    FROM Proveedor 
    WHERE nombre_prov = nombre_proveedor;

    -- Si el conteo es mayor que 0, significa que el proveedor ya existe
    IF v_count > 0 THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END;

------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION proveedor_tiene_productos (
    nombre_proveedor IN Proveedor.nombre_prov%TYPE
) RETURN BOOLEAN
IS
    v_id_prov   Proveedor.id_prov%TYPE;
    v_count     NUMBER;
BEGIN
    -- Obtener el id del proveedor usando la función id_proveedor_por_nombre
    v_id_prov := id_proveedor_por_nombre(nombre_proveedor);

    -- Contar productos asociados a este proveedor
    SELECT COUNT(*) INTO v_count
    FROM Producto
    WHERE id_prov = v_id_prov;

    -- Retornar true si el proveedor tiene productos asociados
    RETURN v_count > 0;
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RETURN FALSE; -- Si el proveedor no existe, retorna FALSE
END;

----------------------------------------------------------------------------------
/*                              PROCEDIMIENTOS                                        */
----------------------------------------------------------------------------------
--Agregar proveedor: devuelve 0 si lo agregó correctamente, 1 si ya existe y 2 por otro tipo de error

CREATE OR REPLACE PROCEDURE agregar_proveedor (
    p_nombre     IN Proveedor.nombre_prov%TYPE,
    p_telefono   IN Proveedor.telefono_prov%TYPE,
    p_correo     IN Proveedor.correo_prov%TYPE,
    p_direccion  IN Proveedor.direccion_prov%TYPE,
    p_resultado  OUT NUMBER
)
IS
BEGIN
    -- Verificar si el proveedor ya existe
    IF proveedor_existe_nombre(p_nombre) THEN
        p_resultado := 1;  -- Proveedor ya existe
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

----------------------------------------------------------------------------
--Eliminiar proveedor: 0 si lo elimino correctamente, 1 si el proveedor tiene productos proveídos (no lo elimina),
--2 otro tipo de error

CREATE OR REPLACE PROCEDURE eliminar_proveedor (
    p_nombre_proveedor IN Proveedor.nombre_prov%TYPE,
    p_resultado        OUT NUMBER
)
IS
BEGIN
    -- Verificar si el proveedor tiene productos asociados
    IF proveedor_tiene_productos(p_nombre_proveedor) THEN
        p_resultado := 1;  -- No se puede eliminar porque tiene productos asociados
    ELSE
        -- Eliminar el proveedor
        DELETE FROM Proveedor
        WHERE nombre_prov = p_nombre_proveedor;

        p_resultado := 0;  -- Eliminación exitosa
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        p_resultado := 2;  -- Otro tipo de error
END;





