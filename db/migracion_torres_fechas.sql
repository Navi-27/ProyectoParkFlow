-- ParkFlow: torres como texto y simplificación de fechas (solo para bases ya existentes)
-- Correr después de migracion_usuario_persona.sql. ATENCIÓN: borra las estancias sin plaza.
USE `proyecto_integrador`;

-- 1. Torre como texto
ALTER TABLE vivienda MODIFY `torre` VARCHAR(10) NOT NULL;
UPDATE vivienda SET torre = 'A1' WHERE torre = '1';
UPDATE vivienda SET torre = 'A2' WHERE torre = '2';
UPDATE vivienda SET torre = 'B1' WHERE torre = '3';

-- 2. Fechas de auditoría
ALTER TABLE persona  DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE usuario  DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE vehiculo DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE zona     DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE vivienda DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE parqueo  DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;
ALTER TABLE registro DROP COLUMN fecha_creacion, DROP COLUMN fecha_actualizacion;

-- 3. Estancia
UPDATE estancia SET fecha_llegada = fecha_ocupacion
WHERE fecha_ocupacion IS NOT NULL AND id_estancia > 0;

DELETE FROM estancia WHERE id_parqueo IS NULL AND id_estancia > 0;

ALTER TABLE estancia
  DROP COLUMN fecha_ocupacion,
  MODIFY `id_parqueo` INT NOT NULL;
