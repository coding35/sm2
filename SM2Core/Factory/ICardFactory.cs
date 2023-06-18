using SM2Core.Enum;
using SM2Core.Model;
using SM2Core.Model.Abstract;
using SM2Core.Observer;

namespace SM2Core.Factory;

public interface ICardFactory
{
    Card CreateCard(int id, string title, CardText answer, CardText question, DateTime reviewDate);
    void SaveCards();
    void ExecuteAlgorithm(AlgorithmType algorithmType);
    public List<Card> LoadCards(CardSourceType cardSourceType);
}
