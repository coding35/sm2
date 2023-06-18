using SM2Core.Enum;
using SM2Core.Factory;
using SM2Core.Model.Session.Behavior;
using SM2Core.Observer;

namespace SM2Core.Model.Session;

public class Sm2Session : Abstract.Session
{
    public Sm2Session(SessionSubject? sessionSubject) :base (sessionSubject, new AdvanceCard())
    {
       
    }
}