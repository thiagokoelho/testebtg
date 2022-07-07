SELECT v.placa, c.nome
FROM Veiculo v
INNER JOIN Cliente c ON v.Cliente_cpf = c.cpf


SELECT p.ender, e.dtEntrada, e.dtSaida
FROM Veiculo v
INNER JOIN Estaciona e ON v.placa = e.Veiculo_placa
INNER JOIN Patio p ON e.Patio_num = p.num
WHERE v.PLACA = 'BTG-2022'
