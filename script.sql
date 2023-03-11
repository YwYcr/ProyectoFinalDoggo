CREATE TABLE Usuarios (
    usuario VARCHAR(50) NOT NULL,
    pass CHAR(20) NOT NULL,
    correo VARCHAR(50) NOT NULL,
    direccion VARCHAR(100),
    telefono VARCHAR(8),
    rol VARCHAR(6) DEFAULT 'user',
    PRIMARY KEY (usuario)
);

ALTER TABLE Usuarios
ADD nombre VARCHAR(25) NOT NULL;

ALTER TABLE Usuarios
ADD apellido VARCHAR(25) NOT NULL;


CREATE TABLE productos (
  IDProd INT IDENTITY(1,1) PRIMARY KEY,
  nomProducto VARCHAR(255),
  precio DECIMAL(10,2),
  Categoria VARCHAR(255),
  detalles VARCHAR(255),
  cantidad INT
);

CREATE TABLE compras (
  IDTrans INT NOT NULL, 
  IDProd INT NOT NULL,
  usuario VARCHAR(50) NOT NULL,
  COSTO DECIMAL(10,2),
  CONSTRAINT PK_IDTRANS PRIMARY KEY (IDTrans)
);

ALTER TABLE compras ADD CONSTRAINT fk_compras_usuario FOREIGN KEY (usuario) REFERENCES Usuarios (usuario);
ALTER TABLE compras ADD CONSTRAINT fk_compras_productos FOREIGN KEY (IDProd) REFERENCES productos (IDProd);


INSERT INTO Usuarios (usuario, pass, correo, direccion, telefono, rol, nombre, apellido)
VALUES ('johndoe', '123456', 'johndoe@example.com', '123 Main St.', '555-1234', 'admin', 'John', 'Doe');

INSERT INTO Usuarios (usuario, pass, correo, direccion, telefono, rol, nombre, apellido)
VALUES ('janedoe', 'abcdef', 'janedoe@example.com', '456 Maple Ave.', '555-5678', 'user', 'Jane', 'Doe');

INSERT INTO Usuarios (usuario, pass, correo, direccion, telefono, rol, nombre, apellido)
VALUES ('bobsmith', 'qwerty', 'bobsmith@example.com', '789 Oak Rd.', '555-9012', 'user', 'Bob', 'Smith');

INSERT INTO productos (nomProducto, precio, Categoria, detalles, cantidad)
VALUES ('Shirt', 29.99, 'Clothing', '100% cotton', 50);

INSERT INTO productos (nomProducto, precio, Categoria, detalles, cantidad)
VALUES ('Sneakers', 59.99, 'Shoes', 'Lightweight and comfortable', 25);

INSERT INTO productos (nomProducto, precio, Categoria, detalles, cantidad)
VALUES ('Backpack', 49.99, 'Accessories', 'Durable and water-resistant', 10);

INSERT INTO compras (IDTrans, IDProd, usuario, COSTO)
VALUES (1, 1, 'johndoe', 29.99);

INSERT INTO compras (IDTrans, IDProd, usuario, COSTO)
VALUES (2, 2, 'janedoe', 59.99);

INSERT INTO compras (IDTrans, IDProd, usuario, COSTO)
VALUES (3, 3, 'bobsmith', 49.99);