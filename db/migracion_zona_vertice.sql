-- ParkFlow: vértices de las zonas para calcular su área con el teorema de Green
-- (solo para bases ya existentes; el esquema y los datos de prueba ya lo incluyen)
USE `proyecto_integrador`;

-- 1. Tabla de vértices: el borde de cada zona, en orden
CREATE TABLE IF NOT EXISTS `zona_vertice` (
  `id_vertice` INT NOT NULL AUTO_INCREMENT,
  `id_zona` INT NOT NULL,
  `orden` INT NOT NULL,
  `x` DOUBLE NOT NULL,
  `y` DOUBLE NOT NULL,
  PRIMARY KEY (`id_vertice`),
  UNIQUE INDEX `uq_vertice_orden` (`id_zona`, `orden`),
  CONSTRAINT `fk_vertice_zona`
    FOREIGN KEY (`id_zona`)
    REFERENCES `zona` (`id_zona`)
    ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE = InnoDB;

-- 2. Zona B con la esquina de la jardinera cortada: 9 × 6 = 54 m² menos un triángulo de 2 m²
--    Green: A = ½ |Σ (xᵢ·yᵢ₊₁ − xᵢ₊₁·yᵢ)| = 52 m²
--    La Zona A queda sin vértices y usa ancho × largo
INSERT INTO zona_vertice (id_zona, orden, x, y)
SELECT z.id_zona, v.orden, v.x, v.y
FROM zona z
JOIN (
  SELECT 1 AS orden, 0 AS x, 8 AS y UNION ALL
  SELECT 2, 9, 8 UNION ALL
  SELECT 3, 9, 14 UNION ALL
  SELECT 4, 2, 14 UNION ALL
  SELECT 5, 0, 12
) v
WHERE z.nombre = 'Zona B'
  AND NOT EXISTS (SELECT 1 FROM zona_vertice zv WHERE zv.id_zona = z.id_zona);
