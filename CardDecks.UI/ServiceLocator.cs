namespace CardDecks.UI;

public class ServiceLocator
{
    private MainViewModel _mainViewMoidel;

    public MainViewModel MainViewModel => _mainViewMoidel ??= ((App)Application.Current).Provider.GetRequiredService<MainViewModel>();
}
