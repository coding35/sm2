using SM2Core.Model.Card.Behavior.Interface;

namespace SM2Core.Model.Card.Behavior;

public class FlipCard : IFlipBehavior
{
    public void Flip()
    {
        IsFlipped();
        Console.WriteLine("Flipped card");
    }

    public bool IsFlipped()
    {
        return true;
    }
}