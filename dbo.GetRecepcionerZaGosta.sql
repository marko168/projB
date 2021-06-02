
CREATE FUNCTION dbo.GetRecepcionerZaGosta(@Gost_MBR int)  
RETURNS NVARCHAR(20)
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE @ret NVARCHAR(20);  
    SELECT @ret = Radniks.Ime from Radniks, Radniks_Recepcioner,Recepcijas,Gosts where Radniks_Recepcioner.JMBG = Radniks.JMBG and Recepcijas.Br_Rec = Radniks_Recepcioner.Recepcija_Br_Rec and Gosts.RecepcijaBr_Rec = Recepcija_Br_Rec and Gosts.MBR = @Gost_MBR; 
    RETURN @ret;  
END;