CREATE TABLE TaskItems (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000) NULL,
    IsCompleted BIT NOT NULL,
    CreatedAt DATETIME2 NOT NULL
);
INSERT INTO TaskItems (Id, Title, Description, IsCompleted, CreatedAt)
VALUES
(NEWID(), 'Write Swagger Docs', 'Add annotations for all endpoints.', 0, GETUTCDATE()),
(NEWID(), 'Design Database Schema', 'Ensure all relationships are well defined.', 0, GETUTCDATE()),
(NEWID(), 'Build API Layer', 'Implement MediatR commands and queries.', 1, GETUTCDATE()),
(NEWID(), 'Create Frontend UI', 'Develop a simple task board interface.', 0, GETUTCDATE()),
(NEWID(), 'Integrate EF Core', 'Setup DbContext and repository patterns.', 1, GETUTCDATE()),
(NEWID(), 'Deploy to Azure', 'Push final build to Azure Web App.', 0, GETUTCDATE()),
(NEWID(), 'Test CRUD Endpoints', 'Ensure all API routes function correctly.', 1, GETUTCDATE()),
(NEWID(), 'Add Logging', 'Integrate Serilog for structured logs.', 0, GETUTCDATE()),
(NEWID(), 'Optimize Queries', 'Add indexes and tune performance.', 0, GETUTCDATE()),
(NEWID(), 'Write Unit Tests', 'Cover handlers and repo methods.', 0, GETUTCDATE());
