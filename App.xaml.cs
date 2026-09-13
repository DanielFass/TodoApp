using TodoApp.Views;

namespace TodoApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    // Modern .NET way to set the initial landing screen layout
    protected override Window CreateWindow(IActivationState? activationState)
    {
        var navigationPage = new NavigationPage(new TodoListPage())
        {
            BarTextColor = Colors.White
        };

        return new Window(navigationPage);
    }
}
