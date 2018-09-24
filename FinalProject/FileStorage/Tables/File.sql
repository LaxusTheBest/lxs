CREATE TABLE [File](
  [FileId] int IDENTITY(1,1) NOT NULL,
  [FileHash] uniqueidentifier NOT NULL ROWGUIDCOL,
  [FileName] int DEFAULT NULL,
  [Link] int NOT NULL,
  [PublisherId] int DEFAULT NULL,
  [PubDate] datetime DEFAULT NULL,
  [FileType] int DEFAULT NULL,
  [IsPublic] bit DEFAULT NULL,
  [Content] varbinary (MAX) FILESTREAM

  CONSTRAINT [PK_File] PRIMARY KEY ([FileId]),
  UNIQUE([FileId],[Link])
)

