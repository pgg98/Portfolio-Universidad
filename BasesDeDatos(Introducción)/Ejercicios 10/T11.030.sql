SELECT cod,nombre,pvp,marca,tipo
FROM articulo
NATURAL JOIN memoria
WHERE tipo='Compact Flash'