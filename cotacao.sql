CREATE TABLE Cotacao (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    data DATE NOT NULL,
    indexador VARCHAR(30) NOT NULL,
    valor DECIMAL(10,2) NOT NULL
);

INSERT INTO Cotacao (data, indexador, valor) VALUES
('2025-01-01', 'SQI', 10.50),
('2025-01-02', 'SQI', 10.50),
('2025-01-03', 'SQI', 10.50),
('2025-01-06', 'SQI', 12.25),
('2025-01-07', 'SQI', 12.25),
('2025-01-08', 'SQI', 12.25),
('2025-01-09', 'SQI', 12.25),
('2025-01-10', 'SQI', 12.25),
('2025-01-13', 'SQI', 12.25),
('2025-01-14', 'SQI', 12.25),
('2025-01-15', 'SQI', 12.25),
('2025-01-16', 'SQI', 9.00),
('2025-01-17', 'SQI', 9.00),
('2025-01-20', 'SQI', 9.00),
('2025-01-21', 'SQI', 7.75),
('2025-01-22', 'SQI', 7.75),
('2025-01-23', 'SQI', 7.75),
('2025-01-24', 'SQI', 7.75),
('2025-01-27', 'SQI', 8.25),
('2025-01-28', 'SQI', 8.25),
('2025-01-29', 'SQI', 8.25),
('2025-01-30', 'SQI', 8.25),
('2025-01-31', 'SQI', 8.25);
