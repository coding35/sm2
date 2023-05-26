using SM2Core.Model.Card.Behavior.Interface;

namespace SM2Core.Model.Card.Behavior;

public class ScoreCard : IScoreBehavior
{
    public double Score(double score)
    {
        return score;
    }
}