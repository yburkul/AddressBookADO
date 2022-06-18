USE[AddressBookService]

create PROCEDURE EditContact
    @ID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(200),
    @City varchar(50),
    @State varchar(50),
    @ZipCode bigint,
    @PhoneNumber bigint,
    @EmailID varchar(50)
AS
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN
BEGIN TRY
BEGIN TRANSACTION;

	SET NOCOUNT ON;
	declare @result bit = 0;
update AddressBook set FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, State = @State,
ZipCode = @ZipCode, PhoneNumber = @PhoneNumber, EmailID = @EmailID where ID = @ID;

Commit Transaction
Set @result = 1;
return @result;
End Try
Begin Catch

if(XACT_STATE()) = -1
 Begin
  Print
   'transaction is uncommitable' + 'rolling back transaction'
   RollBack Transaction;
   Return @result;
   End;
else if(XACT_STATE()) = 1
 Begin
  Print
   'transaction is commitable' + 'commiting back transaction'
   Commit Transaction
  set @result = 1;
   return @result;
   END
END Catch
END