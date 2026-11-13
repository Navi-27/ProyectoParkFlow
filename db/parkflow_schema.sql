-- ParkFlow: esquema proyecto_integrador (borra y recrea todo; luego correr parkflow_datos_prueba.sql)

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

DROP SCHEMA IF EXISTS `proyecto_integrador`;
CREATE SCHEMA `proyecto_integrador` DEFAULT CHARACTER SET utf8mb4;
USE `proyecto_integrador`;

-- persona
CREATE TABLE `persona` (
  `documento` VARCHAR(20) NOT NULL,
  `tipo_documento` ENUM('CC', 'TI', 'CE', 'PA', 'DNI') NOT NULL,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(100) NOT NULL,
  `telefono` VARCHAR(15) NOT NULL,
  `correo` VARCHAR(150) NULL DEFAULT NULL,
  `tipo_persona` ENUM('RESIDENTE', 'VISITANTE', 'EMPLEADO') NOT NULL,
  `movilidad_reducida` TINYINT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`documento`)
) ENGINE = InnoDB;

-- usuario
CREATE TABLE `usuario` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT,
  `persona_documento` VARCHAR(20) NOT NULL,
  `usuario` VARCHAR(100) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  `rol` ENUM('ADMIN', 'PORTERO') NOT NULL DEFAULT 'PORTERO',
  PRIMARY KEY (`id_usuario`),
  UNIQUE INDEX `uq_usuario_usuario` (`usuario`),
  UNIQUE INDEX `uq_usuario_persona` (`persona_documento`),
  CONSTRAINT `fk_usuario_persona`
    FOREIGN KEY (`persona_documento`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- vehiculo
CREATE TABLE `vehiculo` (
  `placa` VARCHAR(6) NOT NULL,
  `tipo_vehiculo` ENUM('CARRO', 'MOTO') NOT NULL DEFAULT 'CARRO',
  `persona_documento` VARCHAR(20) NOT NULL,
  `modelo` VARCHAR(30) NOT NULL,
  `marca` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`placa`),
  INDEX `fk_vehiculo_persona_idx` (`persona_documento`),
  CONSTRAINT `fk_vehiculo_persona`
    FOREIGN KEY (`persona_documento`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- zona
CREATE TABLE `zona` (
  `id_zona` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `ancho` DOUBLE NOT NULL DEFAULT 0,
  `largo` DOUBLE NOT NULL DEFAULT 0,
  PRIMARY KEY (`id_zona`),
  UNIQUE INDEX `uq_zona_nombre` (`nombre`)
) ENGINE = InnoDB;

-- vivienda
CREATE TABLE `vivienda` (
  `id_vivienda` INT NOT NULL AUTO_INCREMENT,
  `persona_documento` VARCHAR(20) NOT NULL,
  `torre` VARCHAR(10) NOT NULL,
  `piso` INT NOT NULL,
  `apartamento` INT NOT NULL,
  PRIMARY KEY (`id_vivienda`),
  INDEX `fk_vivienda_persona1_idx` (`persona_documento`),
  CONSTRAINT `fk_vivienda_persona1`
    FOREIGN KEY (`persona_documento`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- parqueo
CREATE TABLE `parqueo` (
  `id_parqueo` INT NOT NULL AUTO_INCREMENT,
  `id_zona` INT NOT NULL,
  `persona_documento` VARCHAR(20) NULL DEFAULT NULL,
  `vehiculo_placa` VARCHAR(6) NULL DEFAULT NULL,
  `codigo` VARCHAR(10) NOT NULL,
  `nivel` INT NOT NULL DEFAULT 1,
  `coord_x` DOUBLE NOT NULL DEFAULT 0,
  `coord_y` DOUBLE NOT NULL DEFAULT 0,
  `tipo` ENUM('RESIDENTE', 'VISITANTE', 'MOVILIDAD_REDUCIDA') NOT NULL DEFAULT 'VISITANTE',
  PRIMARY KEY (`id_parqueo`),
  UNIQUE INDEX `codigo_UNIQUE` (`codigo`),
  UNIQUE INDEX `vehiculo_placa_UNIQUE` (`vehiculo_placa`),
  INDEX `fk_parqueo_zona_idx` (`id_zona`),
  INDEX `fk_parqueo_persona1_idx` (`persona_documento`),
  CONSTRAINT `fk_parqueo_zona`
    FOREIGN KEY (`id_zona`)
    REFERENCES `zona` (`id_zona`)
    ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_parqueo_persona1`
    FOREIGN KEY (`persona_documento`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_parqueo_vehiculo1`
    FOREIGN KEY (`vehiculo_placa`)
    REFERENCES `vehiculo` (`placa`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- registro
CREATE TABLE `registro` (
  `id_registro` INT NOT NULL AUTO_INCREMENT,
  `persona_visitante` VARCHAR(20) NOT NULL,
  `persona_visitada` VARCHAR(20) NOT NULL,
  `vivienda_id_vivienda` INT NOT NULL,
  `fecha_ingreso` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fecha_salida` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id_registro`),
  INDEX `fk_registro_persona1_idx` (`persona_visitada`),
  INDEX `fk_registro_persona2_idx` (`persona_visitante`),
  INDEX `fk_registro_vivienda1_idx` (`vivienda_id_vivienda`),
  CONSTRAINT `fk_registro_persona1`
    FOREIGN KEY (`persona_visitada`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_registro_persona2`
    FOREIGN KEY (`persona_visitante`)
    REFERENCES `persona` (`documento`)
    ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_registro_vivienda1`
    FOREIGN KEY (`vivienda_id_vivienda`)
    REFERENCES `vivienda` (`id_vivienda`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- estancia
CREATE TABLE `estancia` (
  `id_estancia` INT NOT NULL AUTO_INCREMENT,
  `vehiculo_placa` VARCHAR(6) NOT NULL,
  `id_parqueo` INT NOT NULL,
  `fecha_llegada` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fecha_salida` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id_estancia`),
  INDEX `idx_estancia_placa` (`vehiculo_placa`),
  INDEX `idx_estancia_parqueo` (`id_parqueo`),
  INDEX `idx_estancia_llegada` (`fecha_llegada`),
  CONSTRAINT `fk_estancia_vehiculo`
    FOREIGN KEY (`vehiculo_placa`)
    REFERENCES `vehiculo` (`placa`)
    ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_estancia_parqueo`
    FOREIGN KEY (`id_parqueo`)
    REFERENCES `parqueo` (`id_parqueo`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- nodo_ruta
CREATE TABLE `nodo_ruta` (
  `id_nodo` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `tipo` ENUM('ENTRADA', 'SALIDA', 'CRUCE', 'RAMPA', 'PLAZA') NOT NULL,
  `nivel` INT NOT NULL DEFAULT 1,
  `coord_x` DOUBLE NOT NULL DEFAULT 0,
  `coord_y` DOUBLE NOT NULL DEFAULT 0,
  `id_parqueo` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id_nodo`),
  UNIQUE INDEX `uq_nodo_nombre` (`nombre`),
  UNIQUE INDEX `uq_nodo_parqueo` (`id_parqueo`),
  CONSTRAINT `fk_nodo_parqueo`
    FOREIGN KEY (`id_parqueo`)
    REFERENCES `parqueo` (`id_parqueo`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- arista_ruta
CREATE TABLE `arista_ruta` (
  `id_arista` INT NOT NULL AUTO_INCREMENT,
  `nodo_origen` INT NOT NULL,
  `nodo_destino` INT NOT NULL,
  `distancia` DOUBLE NOT NULL DEFAULT 0,
  `bidireccional` TINYINT(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id_arista`),
  UNIQUE INDEX `uq_arista_par` (`nodo_origen`, `nodo_destino`),
  INDEX `fk_arista_destino_idx` (`nodo_destino`),
  CONSTRAINT `fk_arista_origen`
    FOREIGN KEY (`nodo_origen`)
    REFERENCES `nodo_ruta` (`id_nodo`)
    ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_arista_destino`
    FOREIGN KEY (`nodo_destino`)
    REFERENCES `nodo_ruta` (`id_nodo`)
    ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
