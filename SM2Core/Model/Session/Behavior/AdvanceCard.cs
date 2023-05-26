using SM2Core.Model.Session.Behavior.Interface;
using SM2Core.Model.Abstract;
using SM2Core.Observer;

namespace SM2Core.Model.Session.Behavior;

public class AdvanceCard : IAdvanceBehavior
{
    public void Next(SessionSubject.SubjectState state)
    {
        var card = state.Cards.FirstOrDefault(s => s.IsScored() == false);
        if(card != null)
        {
            state.CurrentCard = card;
        }
    }
}