using SM2Core.Enum;
using SM2Core.Model.Abstract;
using SM2Core.Model.Card;
using SM2Core.Model.Card.Components;

namespace SM2Core.Factory;

public class CardFactory : ICardFactory
{
    public Card CreateCard(int id, string title, CardText question, CardText answer, DateTime reviewDate)
    {
        return new FlashCard(id, title, question, answer, reviewDate);
    }
    

    public List<Card> LoadCards(CardSourceType cardSourceType)
    {
        List<Card> cards = new List<Card>();
        switch (cardSourceType)
        {
            case CardSourceType.Demo:
                cards = CreateDemoCards();
                break;
            case CardSourceType.Firebase:
                break;
            case CardSourceType.LocalDb:
                break;
            case CardSourceType.Json:
                break;
            case CardSourceType.Xml:
                break;
            case CardSourceType.Csv:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cardSourceType), cardSourceType, "Invalid card source.");
        }

        return cards;
    }
    
    public void SaveCards()
    {
        throw new NotImplementedException();
    }
    
    public void ExecuteAlgorithm(AlgorithmType algorithmType)
    {
        throw new NotImplementedException();
    }
    
    private List<Card> CreateDemoCards()
    {
        var cards = new List<Card>();
        for (var i = 0; i < 5; i++)
        {
            cards.Add(CreateCard(i,$"test {i}", new Question($"question {i}"), new Answer( $"answer {i}"), DateTime.Today));
        }
        return cards;
    }
}