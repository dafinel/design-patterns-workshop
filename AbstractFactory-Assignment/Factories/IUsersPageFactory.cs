using AbstractFactory.Pages;

namespace AbstractFactory.Factories
{
    public interface IUsersPageFactory
    {
        UsersPage CreateMobilePage();
        UsersPage CreateDesktopPage();
    }
}