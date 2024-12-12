namespace DbTask.DataAccess.Enums
{
    public enum QueryName
    {
        CreateAuthor,
        RemoveAuthorById,

        CreateProject,
        RemoveProjectById,

        GetTestsByBrowser,
        GetTestsByIds,
        GetTestsByStatus,
        CreateTests,
        RemoveTestsByIds,
        SetTestsAuthorByBrowser
    }
}
