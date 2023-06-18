using SM2Core.Model.Card.Behavior.Interface;

namespace SM2Core.Algorithms;

// Based on SuperMemo (Sm2) Algorithm
// https://super-memory.com/english/ol/sm2.htm
public class Sm2Algorithm : Algorithm, IScoreBehavior
{
    private readonly int _quality;
    private int _repetitions;
    private readonly int _previousInterval;
    private readonly double _previousEaseFactor;

 /*   public Sm2Algorithm(double previousEaseFactor, int previousInterval, int repetitions, int quality)
    {
        _previousEaseFactor = previousEaseFactor;
        _previousInterval = previousInterval;
        _repetitions = repetitions;
        _quality = quality;
    }
*/
    public override void CalculateScore()
    {
        int interval;
        double easeFactor;
        if (_quality >= 3)
        {
            switch (_repetitions)
            {
                case 0:
                    interval = 1;
                    break;
                case 1:
                    interval = 6;
                    break;
                default:
                    interval = (int)Math.Round((_previousInterval * _previousEaseFactor),
                        MidpointRounding.AwayFromZero);
                    break;
            }
            
            _repetitions++;
            easeFactor = _previousEaseFactor + (0.1 - (5 - _quality) * (0.08 + (5 - _quality) * 0.02));
        }
        else
        {
            _repetitions = 0;
            interval = 1;
            easeFactor = _previousEaseFactor;
        }
        
        if (easeFactor < 1.3) {
            easeFactor = 1.3;
        }
        
        Interval = interval;
        Repetitions = _repetitions;
        EaseFactor = easeFactor;
    }

    public double Score(double score)
    {
        CalculateScore();
        return score;
    }
}