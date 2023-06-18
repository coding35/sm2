namespace SM2Core.Algorithms;

public abstract class Algorithm
{
    protected int Interval { get; set; }
    protected int Repetitions { get; set; }
    protected double EaseFactor { get; set; }
    
    public abstract void CalculateScore();
}