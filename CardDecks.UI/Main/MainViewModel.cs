namespace CardDecks.UI.Main;

public class MainViewModel : ViewModelBase
{
    private readonly MainFacade _mainFacade;
    private Deck _selectedDeck;
    private Visibility _cardListVisibility;

    private ObservableCollection<Deck> _deckList;

    private RelayCommand _forceLoadData;
    private RelayCommand _removeDeck;
    private RelayCommand _shuffleDeck;
    private RelayCommand _addDeckForm;

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

    public List<Card> CardList { get; set; }

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
        CardList = await _mainFacade.GetCards(Token);
    });

    public ICommand AddDeckForm => _addDeckForm ??= new RelayCommand(async _ =>
    {
        Deck newDeck = new()
        {
            DeckName = $"dsgsdgdsg {DateTime.Now}",
            IsDeck36 = false
        };

        DeckList.Add(await _mainFacade.AddDeck(newDeck, Token));
    });

    public ICommand RemoveDeck => _removeDeck ??= new RelayCommand(async _ =>
    {
        await _mainFacade.RemoveDeck(SelectedDeck, Token);
    }, _ => SelectedDeck != null);

    public ICommand ShuffleDeck => _shuffleDeck ??= new RelayCommand(async _ =>
    {
        await _mainFacade.ShuffleDeck(SelectedDeck, Token);
    }, _ => SelectedDeck != null &&
        SelectedDeck.DeckCards.Count > 1);
}
