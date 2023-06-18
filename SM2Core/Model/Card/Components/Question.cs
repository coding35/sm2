using SM2Core.Model.Abstract;

namespace SM2Core.Model.Card.Components;

public class Question : CardText
{
    public Question(string question)
    {
        Text = question;
    }
}