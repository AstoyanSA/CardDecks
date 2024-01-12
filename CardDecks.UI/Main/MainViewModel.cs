namespace CardDecks.UI.Main;

public class MainViewModel : ViewModelBase
{
    private readonly MainFacade _mainFacade;
    private Deck _selectedDeck;

    private ObservableCollection<Deck> _deckList;

    private RelayCommand _forceLoadData;
    private Visibility _cardListVisibility;

    public MainViewModel(MainFacade mainFacade)
    {
        _mainFacade = mainFacade;
        CardListVisibility = Visibility.Collapsed;
    }

    public Deck SelectedDeck
    {
        get => _selectedDeck;
        set
        {
            Set(ref _selectedDeck, value);
            CardListVisibility = value == null ? Visibility.Collapsed : Visibility.Visible;
        }
    }

    public ObservableCollection<Deck> DeckList
    {
        get => _deckList;
        set => Set(ref _deckList, value);
    }

    public Visibility CardListVisibility
    {
        get => _cardListVisibility;
        set => Set(ref _cardListVisibility, value);
    }

    public ICommand ForceLoadData => _forceLoadData ??= new RelayCommand(async _ =>
    {
        DeckList = await _mainFacade.GetDecks(Token);
    });
}
