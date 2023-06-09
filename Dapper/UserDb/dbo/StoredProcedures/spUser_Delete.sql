CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin
	select Id, FirstName, LastName
	from dbo.[User]
	where Id = @Id;
end
