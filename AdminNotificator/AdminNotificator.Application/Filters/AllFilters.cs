namespace AdminNotificator.Application.Services.Filters;

public class AllFilters
{
    private FilterByDepartment filterByDepartment;
    private FilterByGender filterByGender;
    private FilterByPosts filterByPosts;
    private FilterByTowns filterByTowns;
    private FilterByOrganizationNames filterByOrganizationNames;
    public readonly List<IUserFilter> userFilters = new List<IUserFilter>();

    public AllFilters(IEnumerable<IUserFilter> givenFilters)
    {
        userFilters.AddRange(givenFilters);
        // userFilters.Add(filterByDepartment);
        // userFilters.Add(filterByGender);
        // userFilters.Add(filterByOrganizationNames);
        // userFilters.Add(filterByPosts);
        // userFilters.Add(filterByTowns);
    }

    public List<IUserFilter> GetUserFilters()
    {
        return userFilters;
    }
}