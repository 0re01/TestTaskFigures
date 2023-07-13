-- create
CREATE TABLE Product (
  id int,
  name varchar(30),
  Constraint ProdPK PRIMARY KEY (id)
);

CREATE TABLE Relation(
	prodId int,
	catId int,
	Constraint UniqueRelation Unique (prodId, catId)
);

create table Category (
  id int,
  name varchar(30),
  Constraint CatPK PRIMARY KEY (id)
)

-- insert
INSERT INTO Product(id,name) VALUES (0001, 'Prod1');
INSERT INTO Product(id,name) VALUES (0002, 'Prod2');
INSERT INTO Product(id,name) VALUES (0003, 'Prod3');
INSERT INTO Product(id,name) VALUES (0004, 'Prod4');
INSERT INTO Product(id,name) VALUES (0002, 'Prod4');


-- insert
INSERT INTO Relation(prodId,catId) VALUES (0001, 0002);
INSERT INTO Relation(prodId,catId) VALUES (0002, 0001);
INSERT INTO Relation(prodId,catId) VALUES (0004, 0006);
INSERT INTO Relation(prodId,catId) VALUES (0001, 0006);
INSERT INTO Relation(prodId,catId) VALUES (0002, 0001);

INSERT INTO Category(id,name) VALUES (0001, 'Category1');
INSERT INTO Category(id,name) VALUES (0002, 'Category2');
INSERT INTO Category(id,name) VALUES (0003, 'Category3');
INSERT INTO Category(id,name) VALUES (0004, 'Category4');
INSERT INTO Category(id,name) VALUES (0005, 'Category5');
INSERT INTO Category(id,name) VALUES (0006, 'Category6');

-- fetch 
SELECT * FROM Product;

Select * from Category;
Select * from Relation;

Select Distinct p.Name, c.Name
From Product p Left Join Relation r on r.prodId = p.id
Left Join Category c on c.id = r.catId

GO
