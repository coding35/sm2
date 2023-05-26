using SM2Core.Enum;
using SM2Core.Model;
using SM2Core.Model.Abstract;
using SM2Core.Observer;

namespace SM2Core.Factory;

public interface ICardFactory
{
    public Card CreateCard(int id, string title, CardSide answer, CardSide question, DateTime reviewDate);
    List<Card> CreateCards();
    
    void LoadCards();
    
    void SaveCards();
    
    void ExecuteAlgorithm(AlgorithmType algorithmType);
}
