-- ParkFlow: relaciona usuario con persona (solo para bases ya existentes)
USE `proyecto_integrador`;

-- 1. Nuevo tipo de persona
ALTER TABLE persona
  MODIFY `tipo_persona` ENUM('RESIDENTE', 'VISITANTE', 'EMPLEADO') NOT NULL;

-- 2. Personas para los usuarios de prueba
INSERT IGNORE INTO persona (documento, tipo_documento, nombre, apellido, telefono, correo, tipo_persona, movilidad_reducida) VALUES
('3001','CC','Andrés','Morales','3071112222','admin@parkflow.com','EMPLEADO',0),
('3002','CC','Diana','Rojas','3073334444',NULL,'EMPLEADO',0);

-- 3. Columna nueva
ALTER TABLE usuario
  ADD COLUMN `persona_documento` VARCHAR(20) NULL AFTER `id_usuario`;

UPDATE usuario SET persona_documento = '3001' WHERE usuario = 'admin';
UPDATE usuario SET persona_documento = '3002' WHERE usuario = 'portero';

-- 4. Ya llena
ALTER TABLE usuario
  MODIFY `persona_documento` VARCHAR(20) NOT NULL,
  ADD UNIQUE INDEX `uq_usuario_persona` (`persona_documento`),
  ADD CONSTRAINT `fk_usuario_persona`
    FOREIGN KEY (`persona_documento`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;
