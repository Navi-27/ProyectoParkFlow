-- =====================================================
-- ParkFlow - Migración: relacionar usuario con persona
-- =====================================================
-- Para bases que YA existen (no borra datos).
-- Si se crea la base desde cero con parkflow_schema.sql y
-- parkflow_datos_prueba.sql, NO hace falta correr este script.
--
-- Cambios:
--   1. persona.tipo_persona admite 'EMPLEADO' (personal del conjunto)
--   2. Se crean las personas de los usuarios de prueba (admin y portero)
--   3. usuario.persona_documento: obligatorio, único y llave foránea a persona
--
-- Si tienes usuarios distintos de 'admin' y 'portero', créales su
-- persona EMPLEADO y asígnalos en el paso 3 antes del paso 4.
-- =====================================================
USE `proyecto_integrador`;

-- 1. Nuevo tipo de persona
ALTER TABLE persona
  MODIFY `tipo_persona` ENUM('RESIDENTE', 'VISITANTE', 'EMPLEADO') NOT NULL;

-- 2. Personas para los usuarios de prueba (si no existen)
INSERT IGNORE INTO persona (documento, tipo_documento, nombre, apellido, telefono, correo, tipo_persona, movilidad_reducida) VALUES
('3001','CC','Andrés','Morales','3071112222','admin@parkflow.com','EMPLEADO',0),
('3002','CC','Diana','Rojas','3073334444',NULL,'EMPLEADO',0);

-- 3. Columna nueva (primero opcional para poder llenarla)
ALTER TABLE usuario
  ADD COLUMN `persona_documento` VARCHAR(20) NULL AFTER `id_usuario`;

UPDATE usuario SET persona_documento = '3001' WHERE usuario = 'admin';
UPDATE usuario SET persona_documento = '3002' WHERE usuario = 'portero';

-- 4. Ya llena: obligatoria, única y con llave foránea
ALTER TABLE usuario
  MODIFY `persona_documento` VARCHAR(20) NOT NULL,
  ADD UNIQUE INDEX `uq_usuario_persona` (`persona_documento`),
  ADD CONSTRAINT `fk_usuario_persona`
    FOREIGN KEY (`persona_documento`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;
