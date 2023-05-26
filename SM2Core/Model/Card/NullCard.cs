using SM2Core.Model.Card.Behavior;
using SM2Core.Model.Card.Components;

namespace SM2Core.Model.Card;

public class NullCard : Abstract.Card
{
    public NullCard() : base(0, "", new Question(""), new Answer(""), DateTime.MinValue, new ScoreCard(), new FlipCard())
    {
    }
}