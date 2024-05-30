CREATE PROCEDURE [dbo].[RETRIEVE_ComplaintsByDate]
	@Keyword DATETIME
AS
SELECT Id,NameOfAuhor,BuildingNumberOfAuthor,ApartmentNumberOfAuthor, Description, BuildingNumberOfComplaint, ApartmentNumberOfComplaint, ComplaintCategory, ComplaintStatus, DateAdded FROM Complaints WHERE @Keyword = DateAdded
