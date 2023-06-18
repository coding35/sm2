using SM2Core.Model.Abstract;

namespace SM2Core.Model.Card.Components;

public class Answer : CardText
{
    public Answer(string answer)
    {
        Text = answer;
    }

    public void Score(int score)
    {
        // observer.Score(score);
    }
}