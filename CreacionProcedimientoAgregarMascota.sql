CREATE PROCEDURE [dbo].[AgregarMascota]
(
	@nombre nvarchar(50),
	@edad nvarchar(10),
	@descrip nvarchar(100),
	@email nvarchar(10),
	@adoptado bit

)
as
begin
	INSERT INTO Mascota values(@nombre, @edad, @descrip, @email, @adoptado)
end