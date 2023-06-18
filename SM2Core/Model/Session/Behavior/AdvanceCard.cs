using SM2Core.Interface;
using SM2Core.Model.Card;
using SM2Core.Model.Session.Behavior.Interface;
using SM2Core.Observer;

namespace SM2Core.Model.Session.Behavior;

public class AdvanceCard : IAdvanceBehavior, IIterator<Abstract.Card>
{
    private List<Abstract.Card>? _list;
    private int _index;

    public void Next(SessionSubject.SubjectState state)
    {
        _list = state.Cards.Where(s => s.IsScored() == false).ToList();
        if (HasNext())
        {
            var card = GetIteration() == 0 ? CurrentItem() : Next();
            if (!card.IsScored())
            {
                state.CurrentCard = CurrentItem();
            }
        }
        else
        {
            state.CurrentCard = new NullCard();
        }
    }

    public bool HasNext()
    {
        return _index < _list!.Count;
    }

    public Abstract.Card Next()
    {
        var item = _list![_index];
        _index++;
        return item;
    }

    public void Remove()
    {
        _list![_index] = default!;
    }

    public Abstract.Card CurrentItem()
    {
        var item = _list![_index];
        return item;
    }

    public int GetIteration()
    {
        return _index;
    }
}