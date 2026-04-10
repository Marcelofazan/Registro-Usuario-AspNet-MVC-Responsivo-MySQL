CREATE TABLE Usuarios (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Login varchar(100) DEFAULT NULL,
  Senha varchar(20) DEFAULT NULL,
  SenhaConfirmar varchar(20) DEFAULT NULL,
  Nome varchar(80) DEFAULT NULL,
  Email varchar(120) DEFAULT NULL,
  Celular varchar(15) DEFAULT NULL,
  Supervisor int(11) DEFAULT 0,
  TaxaPercentual double(5,2) DEFAULT NULL,
  PRIMARY KEY (Id)
);
