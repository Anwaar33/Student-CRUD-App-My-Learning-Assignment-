

CREATE PROCEDURE sp_Student_CRUD
(
    @Action NVARCHAR(10),     -- INSERT, SELECT, UPDATE, DELETE
    @StudentId INT = NULL,
    @Name NVARCHAR(100) = NULL,
    @Age INT = NULL,
    @Class NVARCHAR(50) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERT
    IF @Action = 'INSERT'
    BEGIN
        INSERT INTO Students (Name, Age, Class)
        VALUES (@Name, @Age, @Class);
    END

    -- SELECT (Get All Students)
    ELSE IF @Action = 'SELECT'
    BEGIN
        SELECT * FROM Students;
    END

    -- UPDATE
    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE Students
        SET Name = @Name,
            Age = @Age,
            Class = @Class
        WHERE StudentId = @StudentId;
    END

    -- DELETE
    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM Students
        WHERE StudentId = @StudentId;
    END
END
