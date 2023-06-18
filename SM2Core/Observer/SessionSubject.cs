using SM2Core.Enum;
using SM2Core.Factory;
using SM2Core.Model.Abstract;
using SM2Core.Model.Card;
using SM2Core.Observer.Interface;

namespace SM2Core.Observer;

public class SessionSubject : ISubject
{
    private readonly ICardFactory _cardFactory = new CardFactory();
    private List<IObserver?> Observers { get; set; }
    private SubjectState State { get; set; }
    
    public SessionSubject()
    {
        State = new SubjectState();
        Observers = new List<IObserver?>();
    }
    
    public void AddObserver(IObserver? observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver? observer)
    {
        Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        Observers.ForEach(observer => observer?.Update());
    }
    
    public void LoadState(CardSourceType cardSourceType)
    {
        State.Cards = _cardFactory.LoadCards(cardSourceType);
    }
    
    public void UpdateState(List<Card> cards)
    {
        State.Cards = cards;
    }
    
    public SubjectState GetState()
    {
        return State;
    }
    
    public void Next()
    {
        NotifyObservers();
    }
    
    public Card GetCurrentCard()
    {
        return State.CurrentCard;
    }
    
    // inner state class
    public class SubjectState
    {
        public Card CurrentCard { get; set; } = new NullCard();
        public List<Card> Cards { get; set; } = new List<Card>();
    }
}

