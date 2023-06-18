using SM2Core.Enum;

namespace SM2Core.Model.Card.Behavior.Interface;

public interface IFlipBehavior
{
    CardSideType Flip(CardSideType side);
}