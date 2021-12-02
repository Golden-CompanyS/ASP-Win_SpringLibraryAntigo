drop database if exists dbspringlibrary;

-- Criando o banco 

create database dbspringlibrary;
use dbspringlibrary;


-- Criando as tabelas 

create table tbAutor(
autCod int primary key auto_increment,
autNome varchar(50) not null
);

create table tbGenero(
genCod int primary key auto_increment,
genNome varchar(50) not null unique
);

create table tbEditora(
editCod int primary key auto_increment, 
editNome varchar(50) not null
);

create table tbLivro(
isbn char(13) primary key,
livTitulo varchar(50) not null,
livTituloOrig varchar(50),
livEdicao int default(1),
livAno char(4),
livNumPag int not null,
genCod int,
foreign key (genCod) references tbGenero (genCod),
editCod int,
foreign key (editCod) references tbEditora (editCod)
);

create table tbLivroAutor(
isbn char(17),
foreign key (isbn) references tbLivro (isbn),
autCod int,
foreign key (autCod) references tbAutor(autCod)
);

create table tbSouvenir(
souvCod int primary key auto_increment,
souvNome varchar(50) not null,
souvDimen varchar(100),
souvMaterial varchar(30) not null,
souvTip varchar(50) not null
);

create table tbFuncionario(
funcCod int primary key auto_increment,
funcNome varchar(50) not null,
funcNomeSoc varchar(50),
funcCargo char(1) default("F"),
funcSenha varchar(500) not null
);

create table tbProduto(
prodCod int primary key auto_increment,
prodNome varchar(50),
prodPreco decimal(15,2) not null,
prodQtdEst int not null
);

create table tbNotaFiscal(
notaCod int primary key auto_increment,
notaDtEmiss datetime default(current_timestamp),
funcCod int,
foreign key (funcCod) references tbFuncionario (funcCod)
);

create table tbLivroProd (
isbn varchar(17),
foreign key (isbn) references tbLivro (isbn),
prodCod int,
foreign key (prodCod) references tbProduto (prodCod)
);

create table tbSouvProd(
souvCod int,
foreign key (souvCod) references tbSouvenir (souvCod),
prodCod int,
foreign key (prodCod) references tbProduto (prodCod)
);

create table tbEstado(
UF char(2) primary key
);

create table tbCidade(
cidCod int primary key auto_increment,
cidNome varchar(30) not null
);

create table tbEndereco(
CEP char(9) primary key,
lograd varchar(50),
cidCod int,
foreign key (cidCod) references tbCidade (cidCod),
UF char(2),
foreign key (UF) references tbEstado (UF)
);

create table tbCliente(
cliCod int primary key auto_increment,
CPF char(14) unique,
CNPJ char(18) unique,
cliNome varchar(50) not null,
cliNomeSoc varchar(50),
cliJurRep varchar(30),
cliFisNasc date,
cliTel char(13) not null,
cliEmail varchar(50) not null,
cliEndNum int not null,
CEP char(9),
foreign key (CEP) references tbEndereco (CEP)
);

create table tbRestauracao(
	restCod int primary key auto_increment,
    restDesc varchar(400) not null,
    restDtRecebe date default (current_timestamp),
    restDtInicial date,
    restDtFinalPrev date,
    restPreco decimal(15,2) not null,
    cliCod int, 
    foreign key (cliCod) references tbCliente (cliCod)
);

create table tbDelivery(
	delCod int primary key auto_increment,
	delDtPrevEntreg datetime not null,
    delDtSaida datetime,
    delDtCheg datetime,
    notaCod int,
    foreign key (notaCod) references tbNotaFiscal (notaCod),
    cliCod int, 
    foreign key (cliCod) references tbCliente (cliCod)
);

create table tbLocacao(
	locCod int primary key auto_increment,
    locDesc varchar(500) not null,
    locHoraIni time not null,
    locHoraFim time not null,
    locData date not null,
    locPreco decimal(15,2) not null,
    cliCod int, 
    foreign key (cliCod) references tbCliente (cliCod)
);

create table tbItemVenda(
itVendaCod int primary key auto_increment,
prodCod int,
foreign key (prodCod) references tbProduto (prodCod),
itVendaQtd int, 
notaCod int,
foreign key (notaCod) references tbNotaFiscal (notaCod),
locCod int,
foreign key (locCod) references tblocacao (locCod),
restCod int,
foreign key (restCod) references tbrestauracao (restCod)
);

-- Funcionalidades do Banco 

insert into tbgenero (genNome) values ("Ficção Literária");
insert into tbgenero (genNome) values ("Não-Ficção");
insert into tbgenero (genNome) values ("Ficção Científica");
insert into tbgenero (genNome) values ("Biografia");
insert into tbgenero (genNome) values ("Terror");
insert into tbgenero (genNome) values ("Suspense");
insert into tbgenero (genNome) values ("Romance Policial");
insert into tbgenero (genNome) values ("Poesia");
insert into tbgenero (genNome) values ("Fantasia");
insert into tbgenero (genNome) values ("Teologia");
insert into tbgenero (genNome) values ("Didáticos");
insert into tbgenero (genNome) values ("Autoajuda");
insert into tbgenero (genNome) values ("Mangá");
insert into tbgenero (genNome) values ("HQ");

delimiter $$
create procedure insertBook(
isbnN char(13),
livTituloN varchar(50),
livTituloOrigN varchar(50),
livEdicaoN int,
livAnoN char(4),
livNumPagN int,
livPrecoN decimal(15,2),
livQntEstoqueN int,
genCodN int,
editNomeN varchar(50),
autNomeN varchar(50)
)
begin
    if not exists (select * from tbeditora where (editNome = editNomeN)) then
		insert into tbeditora (editNome) values (editNomeN);
    end if; 
    if not exists (select * from tbautor where (autNome = autNomeN)) then
		insert into tbautor (autNome) values (autNomeN);
    end if; 
    
    insert into tblivro values (isbnN, livTituloN, livTituloOrigN, livEdicaoN, livAnoN, livNumPagN, genCodN,
    (select (editCod) from tbeditora where (editNome = editNomeN)));
    
    insert into tblivroautor values (isbnN, (select (autCod) from tbautor where(autNome = autNomeN)));
    
    insert into tbproduto values (default,livTituloN, livPrecoN, livQntEstoqueN);
    insert into tblivroprod values(isbnN, (select prodCod from tbproduto order by prodCod desc limit 1));
end
$$

delimiter $$
create procedure insertCliFis(
CPFN char(14),
cliNomeN varchar(50),
cliNomeSocN varchar(50),
cliFisNascN date,
cliTelN char(13),
cliEmailN varchar(50),
logradN varchar(50),
cliEndNumN int,
cidNomeN varchar(30),
UFN char(2),
CEPN char(9)
)
begin
	if not exists (select CEP from tbendereco where (CEP = CEPN)) then
		if not exists (select UF from tbestado where (UF = UFN)) then
			insert into tbestado (UF) values (UFN);
		end if;
        if not exists (select cidNome from tbcidade where (cidNome = cidNomeN)) then
			insert into tbcidade (cidNome) values (cidNomeN);
        end if;
        insert into tbendereco values (CEPN, logradN, (select cidCod from tbcidade where (cidNome = cidNomeN)), UFN);
    end if;
    
    insert into tbcliente (cliCod, CPF, cliNome, cliNomeSoc, cliFisNasc, cliTel, cliEmail, cliEndNum, CEP) values
    (default, CPFN, cliNomeN, cliNomeSocN, cliFisNascN, cliTelN, cliEmailN, cliEndNumN, CEPN);
end
$$

delimiter $$
create procedure insertCliJur(
CNPJN char(18),
cliNomeN varchar(50),
cliJurRepN varchar(30),
cliTelN char(13),
cliEmailN varchar(50),
logradN varchar(50),
cliEndNumN int,
cidNomeN varchar(30),
UFN char(2),
CEPN char(9)
)
begin
	if not exists (select CEP from tbendereco where (CEP = CEPN)) then
		if not exists (select UF from tbestado where (UF = UFN)) then
			insert into tbestado (UF) values (UFN);
		end if;
        if not exists (select cidNome from tbcidade where (cidNome = cidNomeN)) then
			insert into tbcidade (cidNome) values (cidNomeN);
        end if;
        insert into tbendereco values (CEPN, logradN, (select cidCod from tbcidade where (cidNome = cidNomeN)), UFN);
    end if;
    
    insert into tbcliente (cliCod, CNPJ, cliNome, cliJurRep, cliTel, cliEmail, cliEndNum, CEP) values
    (default, CNPJN, cliNomeN, cliJurRepN, cliTelN, cliEmailN, cliEndNumN, CEPN);
end
$$

delimiter $$
create procedure insertSouvenir(
souvNomeN varchar(50),
souvDimenN varchar(100),
souvMaterialN varchar(30),
souvTipN varchar(50),
souvPrecoN decimal(15,2),
souvQtdEstN int
)
begin
	insert into tbsouvenir values(default,souvNomeN,souvDimenN,souvTipN,souvMaterialN);
    
    insert into tbproduto values(default,souvNomeN,souvPrecoN,souvQtdEstN);
    insert into tbsouvprod values((select souvCod from tbsouvenir order by souvCod desc limit 1),
								  (select prodCod from tbproduto order by prodCod desc limit 1));
end
$$

delimiter $
create trigger tiraEstoque after insert
ON tbitemvenda
for each row
begin
	update tbproduto 
    set prodQtdEst = prodQtdEst - new.itVendaQtd
    where prodCod = new.prodCod;
end $

delimiter $$
create procedure sellProds(
notaCodn int,
funcCodN int,
prodCodN int,
itVendaQtdN int
)
begin
	if not exists (select notaCod from tbnotafiscal where (notaCod = notaCodn)) then
		insert into tbnotafiscal values (notaCodn, (select current_timestamp()), funcCodN);
		insert into tbitemvenda values (default,prodCodN,itVendaQtdN,(select notaCod from tbnotafiscal order by notaCod desc limit 1),null,null);
    end if;
    if exists (select notaCod from tbitemvenda where (notaCod = notaCodn) and (prodCod = prodCodN)) then
		update tbitemvenda set itVendaQtd = (itVendaQtd + itVendaQtdN);
    end if;
    if exists (select notaCod from tbitemvenda where (notaCod = notaCodn)) then
		insert into tbitemvenda values (default,prodCodN,itVendaQtdN,(select notaCod from tbnotafiscal order by notaCod desc limit 1),null,null);
    end if;
end
$$

delimiter $$
create procedure sellProdsDelivery(
notaCodn int,
funcCodN int,
prodCodN int,
itVendaQtdN int,
delDtPrevEntreg datetime,
cliCodN int
)
begin
	call sellProds(notaCodn, funcCodN, prodCodN, itVendaQtdN);
    insert into tbdelivery values(default,delDtPrevEntreg,null,null,(select notaCod from tbnotafiscal order by notaCod desc limit 1),
    cliCodN);
end
$$

delimiter $$
create procedure updateDelivery(
delCodN int,
delDtSaidaN datetime,
delDtChegN datetime
)
begin
	update tbdelivery set delDtSaida = delDtSaidaN, delDtCheg = delDtChegN where (delCod = delCodN);
end
$$

delimiter $$
create procedure sellRent(
locDescN varchar(500),
locHoraIniN time,
locHoraFimN time,
locDataN date,
locPrecoN decimal(15,2),
cliCodN int,
funcCodN int
)
begin
	insert into tblocacao values(default, locDescN, locHoraIniN, locHoraFimN, locDataN, locPrecoN, cliCodN);

	insert into tbnotafiscal values (default, (select current_timestamp()), funcCodN);
	insert into tbitemvenda values (default,null,null,(select notaCod from tbnotafiscal order by notaCod desc limit 1),
    (select locCod from tblocacao order by locCod desc limit 1),null);
end
$$

delimiter $$
create procedure sellRestor(
restDescN varchar(400),
restDtFinalPrevN date,
restPrecoN decimal(15,2),
cliCodN int,
funcCodN int
)
begin
	insert into tbrestauracao values(default, restDescN, (select current_date), null, restDtFinalPrevN, restPrecoN, cliCodN);

	insert into tbnotafiscal values (default, (select current_timestamp()), funcCodN);
	insert into tbitemvenda values (default,null,null,(select notaCod from tbnotafiscal order by notaCod desc limit 1),null,
    (select restCod from tbrestauracao order by restCod desc limit 1));
end
$$

delimiter $$
create procedure updateRestor(
restCodN int,
restDtInicialN date
)
begin
	update tbrestauracao set restDtInicial = restDtInicialN where (restCod = restCodN);
end
$$

create view showBooks as
select l.isbn as "ISBN", l.livTitulo as "Título", l.livTituloOrig as "Título Original", a.autNome as "Autor", l.livEdicao as "Edição", g.genNome as "Gênero", e.editNome as "Editora",
l.livAno as "Ano de lanc.", l.livNumPag as "Páginas", p.prodPreco as "Preço", p.prodQtdEst as "Qtd. estoque"
from ((((((tblivro as l
	inner join tblivroautor as lv on l.isbn = lv.isbn)
    inner join tbautor as a on lv.autCod = a.autCod)
    inner join tbgenero as g on l.genCod = g.genCod)
    inner join tbeditora as e on l.editCod = e.editCod)
    inner join tblivroprod as lp on l.isbn = lp.isbn)
    inner join tbproduto as p on lp.prodCod = p.prodCod);

create view showSouvs as
select s.souvCod as "Cod. do souv.", s.souvNome as "Nome", p.prodPreco as "Preço", p.prodQtdEst as "Qntd estoque", s.souvDimen as "Dimensões", s.souvMaterial as "Material",
 souvTip as "Tipo"
 from ((tbsouvenir as s
	inner join tbsouvprod as sp on s.souvCod = sp.souvCod) 
	inner join tbproduto as p on sp.prodCod = p.prodCod);
    
create view showLocs as
select l.locCod as "Cod. da loc.", l.locDesc as "Descrição", l.locData as "Data", l.locHoraIni as "Hora de início", l.locHoraFim as "Hora do fim", l.locPreco as "Preço",
c.cliNome as "Responsável"
from (tblocacao as l
	inner join tbcliente as c on l.cliCod = c.cliCod);

create view showRestors as
select r.restCod as "Cod. da rest.", r.restDesc as "Descrição", r.restDtRecebe as "Data recebido",
r.restDtInicial as "Data iniciada rest.", r.restDtFinalPrev as "Prévia finalização",r.restPreco as "Preço",
c.cliNome as "Responsável"
from (tbrestauracao as r
	inner join tbcliente as c on r.cliCod = c.cliCod);
    
create view seeClis as
select c.cliCod as "Cod. do cli.", c.CPF as "CPF", c.CNPJ as "CNPJ", c.cliNome as "Nome", c.cliNomeSoc as "Nome social", c.cliJurRep as "Representante jurídico",
c.cliFisNasc as "Data de nascimento", c.cliTel as "Telefone", c.cliEmail as "Email", e.lograd as "Logradouro", cid.cidNome as "Cidade", est.UF as "Estado", e.CEP as "CEP"
from (((tbcliente as c
	inner join tbendereco as e on c.CEP = e.CEP)
    inner join tbcidade as cid on e.cidCod = cid.cidCod)
    inner join tbestado as est on e.UF = est.UF);

create view seeSells as
select n.notaCod, n.notaDtEmiss as "Data", f.funcNome as "Funcionário"
from (tbnotafiscal as n
	inner join tbfuncionario as f on n.funcCod = f.funcCod);

create view seeSellsDelivery as
select n.notaCod, n.notaDtEmiss as "Data", f.funcNome as "Funcionário", d.delDtPrevEntreg as "Prévia entrega",
d.delDtSaida as "Data saída", d.delDtCheg as "Data entregue"
from ((tbnotafiscal as n
	inner join tbfuncionario as f on n.funcCod = f.funcCod)
    inner join tbdelivery as d on n.notaCod = d.notaCod);

create view seeProdsSell as
select n.notaCod, i.prodCod as "Cod. do prod.", p.prodNome as "Produto", i.itVendaQtd as "Quantidade",
p.prodPreco as "Preço Uni.", p.prodPreco * i.itVendaQtd as "Preço Tot."
from ((tbnotafiscal as n
    inner join tbitemvenda as i on n.notaCod = i.notaCod)
    inner join tbproduto as p on i.prodCod = p.prodCod);

/*-------------Inserções de dados no banco-------------*/

call insertBook("9788594318619","Memórias Póstumas de Brás Cubas", null, 3, 2019, 192, 9.45, 34, 1,"Principis",
"Machado de Assis");
call insertBook("9788595086784","Assassinato no Expresso do Oriente", "Murder on the Orient Express", 1, 2020,240, 24.90,38,7,
"HarperCollins","Agatha Christie");

insert into tbfuncionario values (default, "Britney Jean Spears", null,"G","gimmemore");
insert into tbfuncionario values (default, "Nelly Furtado", null, "F", "promiscuous");

call insertCliFis("183.015.170-34","Larissa Miranda Sonoda",null,"2005-04-12","11 91242-3123","larissa.sonoda@etec.sp.gov.br",
"Rua Jardim de Abril",185,"São Paulo","SP","03982-090");
call insertCliFis("154.012.093-87","Maria Eduarda Rodrigues","Erin","2005-04-12","11 9842-3242","maria.rodrigues@etec.sp.gov.br",
"Avenida Tietê",185,"São Paulo","SP","03967-014");
call insertCliFis("264.665.120-10","Sarah J. Maas",null,"1986-03-05","11 93981-3912","sarahmaass@gmail.com","Avenida Atlântica",201,"Rio de Janeiro","RJ","04768-000");

call insertCliJur("92.716.087/0001-16","Golden Company","Letícia Resina","11 99832-3192","leticia.resina@etec.sp.gov.br",
"Avenida Wallstreet",309,"São Paulo","SP","05185-420");
call insertCliJur("86.423.857/0001-87","Sandoval Doces","Dalva Sandoval","19 98149-1956","sandoval.doces@yahoo.com",
"Rua Santa Bárbara",800,"Santa Bárbara D'Oeste","SP","13450-013");

call insertSouvenir("Funko Pop 70s Wanda","6.4x6.4x9.5cm","Vinil","Estatueta",159.00,100);
call insertSouvenir("Funko Pop Halloween Vision","6.4x6.4x9.5cm","Vinil","Estatueta",138.90,100);

/*Args. da procedure
notaCodn int,
funcCodN int,
prodCodN int,
itVendaQtdN int*/
/*Cria uma nova nota*/
call sellProds(1,1,1,1);
call sellProds(2,1,3,50);

/*Vende na mesma nota*/
call sellProds((select notaCod from tbnotafiscal order by notaCod desc limit 1),
(select funcCod from tbnotafiscal order by notaCod desc limit 1),4,50);

/*Args da procedure
notaCodn int,
funcCodN int,
prodCodN int,
itVendaQtdN int,
delDtPrevEntreg datetime(YYYY-MM-DD HH:MI:SS),
cliCodN int*/
/*Vende com delivery*/
call sellProdsDelivery(3,2,2,1,"2021-12-03 18:00:00",2);
/*Vende com delivery em nova nota*/
call sellProdsDelivery((select notaCod from tbnotafiscal order by notaCod desc limit 1),
(select funcCod from tbnotafiscal order by notaCod desc limit 1),3,2,"2021-12-03 15:00:00",1);

/*Adiciona data de saída e/ou entrega dos deliveries
delCodN int,
delDtSaidaN datetime,
delDtChegN datetime*/
call updateDelivery(1,"2021-12-03 17:00:00",null);
call updateDelivery(2,"2021-12-03 14:25:00","2021-12-03 15:10:00");

/*Locações do espaço
locDescN varchar(500),
locHoraIniN time,
locHoraFimN time,
locDataN date,
locPrecoN decimal(15,2),
cliCodN int,
funcCodN int*/
call sellRent("Coquetel do lançamento de 'Corte de Chamas Patreadas'","09:00:00","15:00:00","2022-01-13",2500.00,3,2);
call sellRent("Aniversário de um ano parceria Golden Company + Spring Library","13:00:00","19:00:00","2021-12-21",0.0,4,1);

/*Restauração de livros
restDescN varchar(400),
restDtFinalPrevN date,
restPrecoN decimal(15,2),
cliCodN int,
funcCodN int*/
call sellRestor("O estado e a revolução. Polimento da capa e lombada","2021-11-26",249.99,2,1);
call sellRestor("Rainha Vermelha. Desamarelar páginas","2021-11-12",299.99,1,1);

/*Adiciona a data em que a restauração foi realizada
restCodN int,
restDtInicialN date*/
call updateRestor(1,"2021-12-27");

/*--------------Selects para ver os dados--------------*/

/*Ver todas as vendas realizadas*/
select * from seeSells;

/*Ver todos os produtos da venda escolhida (por COD)*/
select * from seeProdsSell where(notaCod = 1);

/*Ver todas as vendas com delivery*/
select * from seeSellsDelivery;

select * from showBooks;
select * from showLocs;
select * from showRestors;
select * from seeClis;

SET SQL_SAFE_UPDATES = 0;