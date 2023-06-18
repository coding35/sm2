using SM2Core.Interface;

namespace SM2Core.Model.Abstract;

public abstract class CardText : ICardSideText
{
    protected string Text { get; set; }
    public string GetText() => Text;
}