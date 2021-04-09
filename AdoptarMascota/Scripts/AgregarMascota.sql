create procedure [dbo].[AgregarMascota]
(
	@Nombre nvarchar(50),
	@Edad nvarchar(10),
	@Descrip nvarchar(100),
	@Email varchar(30),
	@Adoptado bit
)
as
begin	
	Insert into Mascota values (@Nombre, @Edad, @Descrip, @Email, @Adoptado)
end