CREATE PROCEDURE [dbo].[INSERT_Complaint]
	@NameOfAuhor NVARCHAR(250),
	@BuildingNumberOfAuthor INT,
	@ApartmentNumberOfAuthor INT,
	@Description NVARCHAR(2000),
	@BuildingNumberOfComplaint INT,
	@ApartmentNumberOfComplaint INT,
	@ComplaintCategory INT,
	@ComplaintStatus INT,
	@DateAdded DATETIME
AS
INSERT INTO Complaints
(Id,NameOfAuhor,BuildingNumberOfAuthor,ApartmentNumberOfAuthor, Description, BuildingNumberOfComplaint, ApartmentNumberOfComplaint, ComplaintCategory, ComplaintStatus, DateAdded)
values
(NEWID(), @NameOfAuhor,@BuildingNumberOfAuthor,@ApartmentNumberOfAuthor, @Description, @BuildingNumberOfComplaint, @ApartmentNumberOfComplaint, @ComplaintCategory, @ComplaintStatus, SYSUTCDATETIME())