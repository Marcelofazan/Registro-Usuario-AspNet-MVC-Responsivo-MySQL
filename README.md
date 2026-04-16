# Registro-Usuario-AspNet-MVC-Responsivo-MySQL

Exemplo de utilização do AdminLte com Registro de Usuário em MVC com banco de dados Mysql acessando por dicionário de dados.

## AdminLTE em (https://adminlte.io/ )

* Template Responsivo AdminLTE 3.2 - rc

  - [AdminLTE](https://github.com/ColorlibHQ/AdminLTE/archive/refs/tags/v3.2.0-rc.zip)

## Requisitos

Baixar Pacote de Distribuição de Download da biblioteca e descompactar

Criar uma nova pasta chamada adminlte na raiz do projeto

- Na Pasta AdminLTE-3.2.0-rc /dist -> Copiar as pastas css, img e js e Colar dentro da pasta adminlte
- Na Pasta AdminLTE-3.2.0-rc /plugins -> Copiar as pasta plugins e Colar dentro da pasta adminlte

# O que você vai encontrar neste projeto

- **AdminLTE** - Layout Responsivo JavaScript e uso de bibliotecas (Plugins). 
- **Dicionário de Dados** - Contexto definido realizado manualmente com T-SQL.

## Execução da aplicação

Para executar a aplicação é necessário a execução do Script do MySql. 

## String de conexão do banco

Modifique a string de conexão no arquivo **Web.config**, no trecho indicado:

```bash
...
		server=127.0.0.1;userid=root;password=SUASENHA;database=SEUBANCO;persistsecurityinfo=True;
...

```

O script para criação da tabela do exemplo encontra-se na pasta **Database**.
