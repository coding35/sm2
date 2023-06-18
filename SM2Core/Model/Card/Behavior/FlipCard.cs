using SM2Core.Enum;
using SM2Core.Model.Card.Behavior.Interface;

namespace SM2Core.Model.Card.Behavior;

public class FlipCard : IFlipBehavior
{
    public CardSideType Flip(CardSideType side)
    {
        return side;
    }
}