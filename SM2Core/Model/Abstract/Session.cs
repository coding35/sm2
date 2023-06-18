using SM2Core.Model.Session.Behavior.Interface;
using SM2Core.Observer;
using SM2Core.Observer.Interface;

namespace SM2Core.Model.Abstract;

public abstract class Session : IObserver
{
    private readonly SessionSubject? _sessionSubject;
    private readonly INextBehavior _nextCard;
    protected Session(SessionSubject? sessionSubject, INextBehavior nextCard)
    {
        _nextCard = nextCard;
        _sessionSubject = sessionSubject;
    }

    public List<Card> Cards { get; protected init; } = new List<Card>();

    
    private void Next()
    {
        var state = _sessionSubject!.GetState();
        _nextCard.Next(state);
    } 

    public void Update()
    {
        Next();
    }
}