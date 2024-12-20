namespace DbTask.DataAccess.Enums
{
    public enum QueryName
    {
        CreateAuthor,
        RemoveAuthorById,

        CreateProject,
        RemoveProjectById,

        GetTestsByBrowser,
        GetTestsByStatus,
        CreateTests,
        RemoveTestsByIds,
        SetTestsAuthorByBrowser,
        SetTestsEnvByIds,
        SetTestsStatusByIds
    }
}
