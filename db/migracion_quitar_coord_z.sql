-- ParkFlow: quita la coordenada z (solo para bases ya existentes)
USE `proyecto_integrador`;

-- 1. Plazas
ALTER TABLE parqueo DROP COLUMN coord_z;

-- 2. Nodos de ruta
ALTER TABLE nodo_ruta DROP COLUMN coord_z;

-- 3. Distancias de las aristas en el plano
UPDATE arista_ruta r
JOIN nodo_ruta a ON a.id_nodo = r.nodo_origen
JOIN nodo_ruta b ON b.id_nodo = r.nodo_destino
SET r.distancia = ROUND(SQRT(POW(a.coord_x - b.coord_x, 2)
                           + POW(a.coord_y - b.coord_y, 2)), 2)
WHERE r.id_arista > 0;
