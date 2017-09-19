//Library DB Script
//Script to create BookType table
CREATE TABLE [dbo].[BookType] (
    [BookTypeID]   INT             NOT NULL,
    [BookTypeName] NVARCHAR (50)   NOT NULL,
    [Memo]         NVARCHAR (2000) NULL,
    PRIMARY KEY CLUSTERED ([BookTypeID] ASC)
);

//Script to create BookInfo table
CREATE TABLE [dbo].[BookInfo] (
    [BookName]    NVARCHAR (256)  NOT NULL,
    [BookTypeID]  INT             NOT NULL,
    [BookAuthor]  NVARCHAR (256)  NOT NULL,
    [BookPub]     NVARCHAR (256)  NOT NULL,
    [BookPubDate] DATETIME        NOT NULL,
    [BookPubNo]   INT             NOT NULL,
    [BookPages]   INT             NOT NULL,
    [BookPrice]   DECIMAL (6, 4)  NOT NULL,
    [ISBN]        INT             NOT NULL,
    [CopiesNo]    INT             NOT NULL,
    [Memo]        NVARCHAR (2000) NULL,
    CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED ([ISBN] ASC),
    CONSTRAINT [FK_BookInfo_BookTypeID] FOREIGN KEY ([BookTypeID]) REFERENCES [dbo].[BookType] ([BookTypeID])
);

//Script to create Books table
CREATE TABLE [dbo].[Books] (
    [BookID]     INT             IDENTITY (1, 1) NOT NULL,
    [ISBN]       INT             NOT NULL,
    [BookInDate] DATETIME        NOT NULL,
    [PutUpDate]  DATETIME        NOT NULL,
    [BookMemo]   NVARCHAR (2000) NULL,
    PRIMARY KEY CLUSTERED ([BookID] ASC),
    CONSTRAINT [FK_Books_ISBN] FOREIGN KEY ([ISBN]) REFERENCES [dbo].[BookInfo] ([ISBN])
);

//CRUD PROCEDURE for BookType TABLE

//C-CREATE
CREATE PROCEDURE [dbo].[spAddBookType]
	@BookTypeID INT,
	@BookTypeName NVARCHAR(256),
	@Memo NVARCHAR(2000)
AS
BEGIN
	INSERT INTO [dbo].[BookType] (BookTypeID,BookTypeName,Memo)
	VALUES (@BookTypeID,@BookTypeName,@Memo)
END
RETURN 1

//R-READ
CREATE PROCEDURE [dbo].[spGetBookType]
AS
BEGIN
	SELECT [BookTypeID],[BookTypeName],[Memo] FROM [dbo].[BookType]
END

//U-UPDATE
CREATE PROCEDURE [dbo].[spSaveBookType]
	@BookTypeID INT,
	@BookTypeName NVARCHAR(256),
	@Memo NVARCHAR(2000)
AS
BEGIN
	UPDATE [dbo].[BookType] 
	SET BookTypeName = @BookTypeName, Memo = @Memo 
	WHERE BookTypeID = @BookTypeID
END
RETURN 1

//D-DELETE
CREATE PROCEDURE [dbo].[spDeleteBookType]
	@BookTypeID INT
AS
BEGIN
	DELETE FROM [dbo].[BookType] 
	WHERE BookTypeID = @BookTypeID
END
RETURN 1