using SM2Core.Extensions;
using SM2Core.Model.Card;
using SM2Core.Model.Session.Behavior.Interface;
using SM2Core.Observer;

namespace SM2Core.Model.Session.Behavior;

public class RandomAdvanceCard : IRandomAdvanceBehavior
{
    public void Next(SessionSubject.SubjectState state)
    {
        var card = state.Cards.Where(s => s.IsScored() == false).ToList().Randomize().FirstOrDefault();;
        if(card != null)
        {
            state.CurrentCard = card;
        }
    }
}