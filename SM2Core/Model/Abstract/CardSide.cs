using SM2Core.Interface;

namespace SM2Core.Model.Abstract;

public abstract class CardSide : ICardSide
{
    protected string Text { get; set; }
    public string GetText() => Text;
}