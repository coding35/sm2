using SM2Core.Enum;
using SM2Core.Model.Abstract;
using SM2Core.Model.Card;
using SM2Core.Model.Card.Components;

namespace SM2Core.Factory;

public class CardFactory : ICardFactory
{
    public Card CreateCard(int id, string title, CardSide question, CardSide answer, DateTime reviewDate)
    {
        return new FlashCard(id, title, question, answer, reviewDate);
    }
    
    public List<Card> CreateCards()
    {
        var cards = new List<Card>();
        for (var i = 0; i < 5; i++)
        {
            cards.Add(CreateCard(i,$"test {i}", new Question($"question {i}"), new Answer( $"answer {i}"), DateTime.Today));
        }

        return cards;
    }

    void ICardFactory.LoadCards()
    {
        throw new NotImplementedException();
    }

    public void SaveCards()
    {
        throw new NotImplementedException();
    }
    
    public List<Card> LoadCards()
    {
        throw new NotImplementedException();
    }    
    
    public void ExecuteAlgorithm(AlgorithmType algorithmType)
    {
        throw new NotImplementedException();
    }
}