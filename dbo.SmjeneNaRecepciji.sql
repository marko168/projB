CREATE PROCEDURE SmjeneNaRecepciji
AS
DECLARE REC CURSOR 
	FOR SELECT Br_Rec from Recepcijas
DECLARE @i int,
		@print NVARCHAR(20)
BEGIN
	Open REC;
	WHILE @@FETCH_STATUS = 0
		BEGIN		
			SELECT @print = Smjenas.Naz_Smjene FROM Smjenas, Radniks_Recepcioner where Smjenas.Id_Smjene=Radniks_Recepcioner.Smjena_Id_Smjene AND @i = Radniks_Recepcioner.Recepcija_Br_Rec; 
			FETCH NEXT FROM REC INTO @i
			PRINT @print
		END
	CLOSE REC;
	DEALLOCATE REC; 
END