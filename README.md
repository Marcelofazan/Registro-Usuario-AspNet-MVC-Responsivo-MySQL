ERPSimplesLTE

Exemplo Conta de Usuário em MVC com banco de dados Mysql acessando por dicionário de dados

* Template AdminLTE 3.2 - https://adminlte.io/ 
https://github.com/ColorlibHQ/AdminLTE/archive/refs/tags/v3.2.0-rc.zip


Modo de Instalação:

Baixar Pacote de Distribuição de Download da Biblioteca e descompactar

Criar uma nova pasta chamada adminlte na raiz do projeto

- Na Pasta AdminLTE-3.2.0-rc /dist -> Copiar as pastas css, img e js e colocar dentro da pasta adminlte
- Na Pasta AdminLTE-3.2.0-rc /plugins -> Copiar as pasta plugins e colar dentro da pasta adminlte

Criação do Script:

<b>
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
</b>
