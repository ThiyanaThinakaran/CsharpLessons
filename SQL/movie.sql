use sample
CREATE TABLE[dbo].[mvtbl](
[mID][int]NOT NULL,[title][nvarchar](30)NOT NULL,[language][nvarchar](20)NOT NULL,[Hero][nvarchar](20)NOT NULL,
[Director][nvarchar](20)NOT NULL,[MusicDirector][nvarchar](20)NOT NULL,[ReleaseDate][DateTime]NOT NULL,
[cost][decimal](5,0)NOT NULL,[collection][numeric](30,0)NOT NULL,[review][numeric]NOT NULL
CONSTRAINT [PK_mvtbl]PRIMARY KEY CLUSTERED ([mID]ASC ) );
ALTER TABLE[dbo].[mvtbl] WITH CHECK ADD CONSTRAINT
[CK_mvtbl_review]CHECK (([review]=1 OR[review]=2 OR[review]=3 OR[review]=4 OR[review]=5))
