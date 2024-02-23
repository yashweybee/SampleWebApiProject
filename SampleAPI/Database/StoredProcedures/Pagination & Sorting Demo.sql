USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetInvitationCodeList]    Script Date: 22-02-2024 11:10:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_GetBooksList]
    @search nvarchar(50) = '',
    @sortColumn nvarchar(50) = 'createdDate', --code
    @sortType nvarchar(50) = 'desc', -- asc
    @pageNumber bigint = 0,
    @pageSize bigint = 10
AS
BEGIN
    SELECT COUNT(*) as count FROM TblInvitationCode;

    SELECT 
    ROW_NUMBER() OVER (Order By 
     CASE
       WHEN @SortType <> 'asc' then ''
       WHEN @SortColumn = 'createdDate'  then createdDate
    END ASC,

     CASE
       WHEN @SortType <> 'desc' then ''
       WHEN @SortColumn = 'createdDate' then createdDate
     END desc,

      CASE
       WHEN @SortType <> 'asc' then ''
       WHEN @SortColumn = 'code' then code
    END ASC,

     CASE
       WHEN @SortType <> 'desc' then ''
       WHEN @SortColumn = 'code'  then code
     END desc,

     CASE
       WHEN @SortType <> 'asc' then ''
       WHEN @SortColumn = 'ownerEmail' then ownerEmail
    END ASC,

     CASE
       WHEN @SortType <> 'desc' then ''
       WHEN @SortColumn = 'ownerEmail'  then ownerEmail
     END desc
     )
     as rowNumber,
    * 
    FROM TblInvitationCode WHERE (@search = '' OR code like '%@search%')
    ORDER BY rowNumber
    OFFSET @pageNumber * @pageSize ROWS FETCH NEXT @pagesize ROWS ONLY

END


--exec [usp_GetInvitationCodeList] @pageNumber = 0,@pageSize =10, @sortColumn = 'code',@sortType ='asc',@search =''