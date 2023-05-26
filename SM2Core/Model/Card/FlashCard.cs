using SM2Core.Model.Abstract;
using SM2Core.Model.Card.Behavior;
using SM2Core.Observer;

namespace SM2Core.Model.Card;

public class FlashCard : Abstract.Card
{    
    public FlashCard(int id, string title, CardSide question, CardSide answer, DateTime reviewDate) 
        : base(id, title, question, answer, reviewDate, new ScoreCard(), new FlipCard())
    {
    }
}
