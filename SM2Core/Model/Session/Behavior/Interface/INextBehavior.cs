using SM2Core.Observer;

namespace SM2Core.Model.Session.Behavior.Interface;

public interface INextBehavior
{
    public void Next(SessionSubject.SubjectState state);
}