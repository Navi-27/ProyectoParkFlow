-- =====================================================
-- ParkFlow - Migración: torres como texto y simplificación de fechas
-- =====================================================
-- Para bases que YA existen. Correr DESPUÉS de migracion_usuario_persona.sql.
-- Si se crea la base desde cero con parkflow_schema.sql y
-- parkflow_datos_prueba.sql, NO hace falta correr este script.
--
-- Cambios:
--   1. vivienda.torre pasa de número a texto (1 -> A1, 2 -> A2, 3 -> B1)
--   2. Se eliminan fecha_creacion y fecha_actualizacion de todas las tablas
--   3. estancia: fecha_llegada pasa a ser la hora en que se ocupa la plaza,
--      se elimina fecha_ocupacion y la plaza (id_parqueo) pasa a ser obligatoria.
--      El tiempo ocupado se calcula en el código (Estancia.TiempoOcupado).
--
-- ATENCIÓN: el paso 3 BORRA las estancias que no tienen plaza (vehículos que
-- estaban "esperando en la fila"); la espera ahora se maneja solo en memoria.
-- =====================================================
USE `proyecto_integrador`;

-- 1. Torre como texto
ALTER TABLE vivienda MODIFY `torre` VARCHAR(10) NOT NULL;
UPDATE vivienda SET torre = 'A1' WHERE torre = '1';
UPDATE vivienda SET torre = 'A2' WHERE torre = '2';
UPDATE vivienda SET torre = 'B1' WHERE torre = '3';

-- 2. Fechas de auditoría (no se usan en el código)
ALTER TABLE persona  DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE usuario  DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE vehiculo DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE zona     DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE vivienda DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE parqueo  DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE registro DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;

-- 3. Estancia: llegada = ocupación de la plaza
UPDATE estancia SET fecha_llegada = fecha_ocupacion
WHERE fecha_ocupacion IS NOT NULL AND id_estancia > 0;

DELETE FROM estancia WHERE id_parqueo IS NULL AND id_estancia > 0;

ALTER TABLE estancia
  DROP COLUMN fecha_ocupacion,
  MODIFY `id_parqueo` INT NOT NULL;
