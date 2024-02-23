USE [BookStore]
GO
CREATE OR ALTER PROCEDURE [dbo].[usp_GetBooksList]
    @search nvarchar(50) = '',
    @sortColumn nvarchar(50) = 'Title', 
    @sortType nvarchar(50) = 'desc',
    @pageNumber bigint = 0,
    @pageSize bigint = 10
AS
BEGIN
    SELECT COUNT(*) as count FROM Books;

    SELECT 
    ROW_NUMBER() OVER (Order By
     CASE
       WHEN @SortType <> 'asc' then ''
       WHEN @SortColumn = 'Title'  then Title
    END ASC,

     CASE
       WHEN @SortType <> 'desc' then ''
       WHEN @SortColumn = 'Title' then Title
     END desc

    --  CASE
    --   WHEN @SortType <> 'asc' then ''
    --   WHEN @SortColumn = 'Price' then Price
    --END ASC,

    -- CASE
    --   WHEN @SortType <> 'desc' then ''
    --   WHEN @SortColumn = 'Price'  then Price
    -- END desc,

    -- CASE
    --   WHEN @SortType <> 'asc' then ''
    --   WHEN @SortColumn = 'PublicationDate' then PublicationDate
    --END ASC,

    -- CASE
    --   WHEN @SortType <> 'desc' then ''
    --   WHEN @SortColumn = 'PublicationDate'  then PublicationDate
    -- END desc
     )
     as rowNumber,
    * 
    FROM Books WHERE (@search = '' OR Title like CONCAT('%',@search, '%'))
    ORDER BY rowNumber
    OFFSET @pageNumber * @pageSize ROWS FETCH NEXT @pagesize ROWS ONLY

END

exec [usp_GetBooksList] @pageNumber = 0,@pageSize =10, @sortColumn = 'Title',@sortType ='asc',@search =''
