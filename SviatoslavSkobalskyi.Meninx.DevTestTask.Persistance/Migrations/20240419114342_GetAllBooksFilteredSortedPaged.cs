using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SviatoslavSkobalskyi.Meninx.DevTestTask.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class GetAllBooksFilteredSortedPaged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var getAllBooksFilteredSortedPaged = @$"
                CREATE PROCEDURE GetAllBooksFilteredSortedPaged
                    @SEARCH_TEXT VARCHAR(50) = '',
                    @SORT_COLUMN_NAME VARCHAR(50) = '',
                    @SORT_COLUMN_DIRECTION VARCHAR(50) = '',
                    @START_INDEX INT = 0,
                    @PAGE_SIZE INT = 0
                AS
                BEGIN
                    DECLARE @QUERY NVARCHAR(MAX), @ORDER_QUERY NVARCHAR(MAX), @CONDITIONS NVARCHAR(MAX), @PAGINATION NVARCHAR(MAX)

                    SET @QUERY = 'SELECT * FROM Books'

                    IF ISNULL(@SEARCH_TEXT, '') <> ''
                    BEGIN
                        IF ISNUMERIC(@SEARCH_TEXT) = 1
                            SET @CONDITIONS = ' WHERE Quantity = ' + @SEARCH_TEXT + ' OR PublicationYear = ' + @SEARCH_TEXT
                        ELSE
                            SET @CONDITIONS = '
                                WHERE
                                    Title LIKE ''%' + @SEARCH_TEXT + '%''
                                    OR Author LIKE ''%' + @SEARCH_TEXT + '%''
                                    OR ISBN LIKE ''%' + @SEARCH_TEXT + '%'''
                    END

                    IF ISNULL(@SORT_COLUMN_NAME, '') <> '' AND ISNULL(@SORT_COLUMN_DIRECTION, '') <> ''
                        SET @ORDER_QUERY = ' ORDER BY ' + @SORT_COLUMN_NAME + ' ' + @SORT_COLUMN_DIRECTION
                    ELSE
                        SET @ORDER_QUERY = ' ORDER BY ID ASC'

                    IF @PAGE_SIZE > 0
                        BEGIN
                            SET @PAGINATION = ' OFFSET ' + CAST(@START_INDEX AS NVARCHAR(10)) + ' ROWS FETCH NEXT ' + CAST(@PAGE_SIZE AS NVARCHAR(10)) + ' ROWS ONLY'
                        END
                    SET @QUERY = @QUERY + ISNULL(@CONDITIONS, '') + ISNULL(@ORDER_QUERY, '') + ISNULL(@PAGINATION, '')

                    EXEC sp_executesql @QUERY
                END";
            migrationBuilder.Sql(getAllBooksFilteredSortedPaged);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropGetAllBooksFilteredSortedPaged = "DROP PROCEDURE GetAllBooksFilteredSortedPaged";
            migrationBuilder.Sql(dropGetAllBooksFilteredSortedPaged);
        }
    }
}
