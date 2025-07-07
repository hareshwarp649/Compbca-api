DECLARE @SQL NVARCHAR(MAX) = '';
DECLARE @TableName NVARCHAR(256);
DECLARE @ConstraintName NVARCHAR(256);
DECLARE @ColumnName NVARCHAR(256);
DECLARE @ReferencedColumnName NVARCHAR(256);
DECLARE @ReferencedTableName NVARCHAR(256);
DECLARE @CreateSQL NVARCHAR(MAX) = '';

-- Step 1: Fetch all Foreign Keys referencing dbo.Employees
DECLARE FK_CURSOR CURSOR FOR
SELECT 
    fk.name AS ConstraintName,
    tp.name AS TableName,
    cp.name AS ColumnName,
    tr.name AS ReferencedTableName,
    cr.name AS ReferencedColumnName
FROM sys.foreign_keys fk
JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
JOIN sys.tables tp ON fkc.parent_object_id = tp.object_id
JOIN sys.columns cp ON fkc.parent_object_id = cp.object_id AND fkc.parent_column_id = cp.column_id
JOIN sys.tables tr ON fkc.referenced_object_id = tr.object_id
JOIN sys.columns cr ON fkc.referenced_object_id = cr.object_id AND fkc.referenced_column_id = cr.column_id
WHERE tr.name = 'Roles';

-- Step 2: Drop Foreign Keys
OPEN FK_CURSOR;
FETCH NEXT FROM FK_CURSOR INTO @ConstraintName, @TableName, @ColumnName, @ReferencedTableName, @ReferencedColumnName;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Store the CREATE FK statement before dropping
    SET @CreateSQL = @CreateSQL + 'ALTER TABLE ' + QUOTENAME(@TableName) + 
                     ' ADD CONSTRAINT ' + QUOTENAME(@ConstraintName) + 
                     ' FOREIGN KEY (' + QUOTENAME(@ColumnName) + ') REFERENCES ' + QUOTENAME(@ReferencedTableName) + 
                     '(' + QUOTENAME(@ReferencedColumnName) + ');' + CHAR(13);

    -- Generate DROP FK statement
    SET @SQL = 'ALTER TABLE ' + QUOTENAME(@TableName) + ' DROP CONSTRAINT ' + QUOTENAME(@ConstraintName) + ';';
    PRINT @SQL;
    EXEC sp_executesql @SQL;

    FETCH NEXT FROM FK_CURSOR INTO @ConstraintName, @TableName, @ColumnName, @ReferencedTableName, @ReferencedColumnName;
END;

CLOSE FK_CURSOR;
DEALLOCATE FK_CURSOR;

-- Step 3: Truncate the tables

PRINT 'Truncating table dbo.RolePermissions';
TRUNCATE TABLE dbo.RolePermissions;

PRINT 'Truncating table dbo.UserRoles';
TRUNCATE TABLE dbo.UserRoles;

PRINT 'Truncating table dbo.Roles';
TRUNCATE TABLE dbo.Roles;

-- Step 4: Recreate Foreign Keys
PRINT 'Recreating Foreign Keys...';
PRINT @CreateSQL;
EXEC sp_executesql @CreateSQL;
