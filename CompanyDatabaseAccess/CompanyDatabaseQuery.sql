CREATE TABLE [dbo].[Employees] (
    [Id]         INT        NOT NULL,
    [Name]       NCHAR (20) NOT NULL,
    [Surname]    NCHAR (20) NOT NULL,
    [Department] NCHAR (20) NOT NULL,
    [Post]       NCHAR (20) NOT NULL,
    [Phone]      NCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Departments] (
    [Id]    INT        NOT NULL,
    [Name]  NCHAR (20) NOT NULL,
    [Floor] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


INSERT INTO Departments(Id, Name, Floor) VALUES (1, N'Компания', 3);
INSERT INTO Departments(Id, Name, Floor) VALUES (2, N'Разработка', 4);
INSERT INTO Departments(Id, Name, Floor) VALUES (3, N'Персонал', 3);
INSERT INTO Departments(Id, Name, Floor) VALUES (4, N'Продажи', 5);
INSERT INTO Departments(Id, Name, Floor) VALUES (5, N'Финансы', 3);
INSERT INTO Departments(Id, Name, Floor) VALUES (6, N'Реклама', 5);


INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(1, N'Александр', N'Кузнецов', N'Компания', N'Директор', N'+7-999-888-77-66');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(2, N'Вадим', N'Соколов', N'Разработка', N'Руководитель', N'+7-999-888-77-67');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(3, N'Денис', N'Морозов', N'Разработка', N'Архитектор', N'+7-999-888-77-68');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(4, N'Евгений', N'Семенов', N'Разработка', N'Программист', N'+7-999-888-77-69');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(5, N'Михаил', N'Степанов', N'Разработка', N'Программист', N'+7-999-888-77-70');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(6, N'Сергей', N'Андреев', N'Разработка', N'Программист', N'+7-999-888-77-71');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(7, N'Юрий', N'Соловьев', N'Персонал', N'Руководитель', N'+7-999-888-77-72');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(8, N'Вероника', N'Киселева', N'Персонал', N'Менеджер', N'+7-999-888-77-73');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(9, N'Геннадий', N'Кузьмин', N'Персонал', N'Менеджер', N'+7-999-888-77-74');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(10, N'Алина', N'Сорокина', N'Продажи', N'Руководитель', N'+7-999-888-77-75');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(11, N'Ксения', N'Ковалева', N'Продажи', N'Агент', N'+7-999-888-77-76');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(12, N'Степан', N'Фролов', N'Продажи', N'Агент', N'+7-999-888-77-77');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(13, N'Юлия', N'Антонова', N'Продажи', N'Агент', N'+7-999-888-77-78');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(14, N'Елена', N'Давыдова', N'Финансы', N'Главный бухгалтер', N'+7-999-888-77-79');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(15, N'Валерий', N'Герасимов', N'Финансы', N'Бухгалтер', N'+7-999-888-77-80');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(16, N'Надежда', N'Маркова', N'Финансы', N'Бухгалтер', N'+7-999-888-77-81');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(17, N'Любовь', N'Крылова', N'Реклама', N'Руководитель', N'+7-999-888-77-82');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(18, N'Никита', N'Казаков', N'Реклама', N'Пиар-менеджер', N'+7-999-888-77-83');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(19, N'Олеся', N'Фомина', N'Реклама', N'Пиар-менеджер', N'+7-999-888-77-84');
INSERT INTO Employees(Id, Name, Surname, Department, Post, Phone) VALUES(20, N'Оксана', N'Ефимова', N'Реклама', N'Пиар-менеджер', N'+7-999-888-77-85');

