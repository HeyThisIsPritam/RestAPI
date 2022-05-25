CREATE DATABASE EmployeeDB;
GO
Use EmployeeDB;
GO
CREATE TABLE [dbo].[Employee] (
    [empId]       INT          IDENTITY (1000, 1) NOT NULL,
    [empName]     VARCHAR (20) NOT NULL,
    [designation] VARCHAR (20) NOT NULL,
    [DOJ]         DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([empId] ASC)
);
GO
INSERT INTO Employee VALUES('Pritam','Application Dev','2020-11-09');
INSERT INTO Employee VALUES('Debaraj','Tech Lead','2016-07-19');
INSERT INTO Employee VALUES('Shubasish','Group Manager','2002-11-09');
GO