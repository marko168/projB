CREATE TRIGGER DeleteSoba
ON Sobas
INSTEAD OF DELETE
AS
DECLARE 
	@targetId int
BEGIN
	SELECT @targetId = i.Br_Sobe FROM deleted i;
	DELETE FROM Smjestajs WHERE Smjestajs.SobaBr_Sobe = @targetId;
	DELETE FROM Sobas WHERE Sobas.Br_Sobe=@targetId; 
END