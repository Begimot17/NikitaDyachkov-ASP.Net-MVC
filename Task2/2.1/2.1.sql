CREATE PROCEDURE UserIdGenerate (@oldId INTEGER, @newId INTEGER Output)
    AS 
Begin
     SELECT @newId=ABS(CHECKSUM(NEWID()) % 100000)
   UPDATE Users
        SET Id = @newId
        WHERE Id = @oldId;
End
