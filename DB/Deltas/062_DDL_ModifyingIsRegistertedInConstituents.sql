
GO

ALTER TABLE CONSTITUENTS ALTER COLUMN ISREGISTERED VARCHAR(1) NOT NULL
ALTER TABLE CONSTITUENTS ADD CONSTRAINT DF_ISREGISTERED_CONSTITUENTS DEFAULT ('N') FOR ISREGISTERED

GO