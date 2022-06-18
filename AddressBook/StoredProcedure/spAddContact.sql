use [AddressBookService]

CREATE PROCEDURE AddContactInAddressBook
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
	insert into AddressBook values (@FirstName,@LastName,@Address,@City,@State,@ZipCode,@PhoneNumber,@EmailID)

Commit Transaction
Set @result = 1;
return @result;
END TRY
Begin Catch

if(XACT_STATE()) = -1
 Begin
  Print
  'transaction is uncommitable' + 'rolling back transaction'
 ROLLBACK TRANSACTION;
 RETURN @result;
 End;
else if (XACT_STATE()) = 1
Begin
Print
   'transaction is commitable' + 'commiting back transaction'
   COMMIT TRANSACTION
   set @result = 1;
   return @result;
   END
END Catch
END

select * from AddressBook

exec AddContactInAddressBook 'Yogesh','Burkul','Asola','Pune','Maharashtra',443232,8800998899,'y.burkul@gmail.com';