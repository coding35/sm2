using SM2Core.Model.Abstract;

namespace SM2Core.Model.Card.Components;

public class Question : CardSide
{
    public Question(string question)
    {
        Text = question;
    }
}