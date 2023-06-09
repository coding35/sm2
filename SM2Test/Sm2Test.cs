using SM2Core.Enum;
using SM2Core.Model.Abstract;
using SM2Core.Model.Session;
using SM2Core.Observer;

namespace SM2Test;

public class Tests
{
    private SessionSubject? _sessionSubject;
    private Session? _session;

    [SetUp]
    public void Setup()
    {
        _sessionSubject = new SessionSubject();
        _session = new Sm2Session(_sessionSubject);
        _sessionSubject.LoadState(CardSourceType.Demo);
        _sessionSubject.AddObserver(_session);
        _sessionSubject.Next();
    }

    [Test]
    public void ShouldCreateCardList()
    {
        Assert.That(_sessionSubject!.GetState().Cards.Count, Is.EqualTo(5));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(.0)]
    [TestCase(1.0)]
    [TestCase(10.0)]
    [TestCase(100.0)]
    [TestCase(100.00)]
    public void ShouldScoreCard(double arg)
    {
        var card = _sessionSubject!.GetState().CurrentCard;
        card.SetScore(arg);
        Assert.That(card.GetScore(), Is.EqualTo(arg));
    }

    [Test]
    public void ShouldAdvanceCardByOne()
    {
        var card = _sessionSubject!.GetState().CurrentCard;
        card.SetScore(5);
        _sessionSubject.Next();
        var nextCard = _sessionSubject.GetState().CurrentCard;
        Assert.That(card, Is.Not.EqualTo(nextCard));
        Assert.That(nextCard.GetId(), Is.EqualTo(1));
    }

    [Test]
    public void ShouldAdvanceCardByTwo()
    {
        var firstCard = _sessionSubject!.GetState().CurrentCard;
        firstCard.SetScore(1);
        _sessionSubject.Next();
        var secondCard = _sessionSubject.GetState().CurrentCard;
        secondCard.SetScore(2);
        _sessionSubject.Next();
        var thirdCard = _sessionSubject.GetState().CurrentCard;
        thirdCard.SetScore(3);
        _sessionSubject.Next();
        Assert.That(secondCard, Is.Not.EqualTo(firstCard));
        Assert.That(secondCard.GetId(), Is.EqualTo(1));
        Assert.That(thirdCard, Is.Not.EqualTo(secondCard));
        Assert.That(thirdCard.GetId(), Is.EqualTo(2));
    }

    [Test]
    public void CardShouldFlip()
    {
        var firstCard = _sessionSubject!.GetState().CurrentCard;
        firstCard.Flip();
        Assert.That(firstCard.GetIsFlipped(), Is.True);
        Assert.That(firstCard.GetCardSide(), Is.EqualTo(CardSideType.Answer));
        firstCard.Flip();
        Assert.That(firstCard.GetIsFlipped(), Is.True);
        Assert.That(firstCard.GetCardSide(), Is.EqualTo(CardSideType.Question));
        firstCard.Flip();
        Assert.That(firstCard.GetIsFlipped(), Is.True);
        Assert.That(firstCard.GetCardSide(), Is.EqualTo(CardSideType.Answer));
    }

    [Test]
    public void CardShouldKeepScore()
    {
        var firstCard = _sessionSubject!.GetState().CurrentCard;
        firstCard.SetScore(1);
        firstCard.Flip();;
        _sessionSubject.Next();
        var secondCard = _sessionSubject.GetState().CurrentCard;

        secondCard.SetScore(2);
        secondCard.Flip();;
        _sessionSubject.Next();
        var thirdCard = _sessionSubject.GetState().CurrentCard;

        thirdCard.SetScore(3);
        thirdCard.Flip();;
        _sessionSubject.Next();

        var cards = _sessionSubject.GetState().Cards;
        Assert.That(cards[0].GetScore(), Is.EqualTo(1));
        Assert.That(cards[0].GetIsFlipped(), Is.True);
        Assert.That(cards[1].GetScore(), Is.EqualTo(2));
        Assert.That(cards[1].GetIsFlipped(), Is.True);
        Assert.That(cards[2].GetScore(), Is.EqualTo(3));
        Assert.That(cards[2].GetIsFlipped(), Is.True);
        Assert.That(cards[3].GetScore(), Is.EqualTo(0));
        Assert.That(cards[3].GetIsFlipped(), Is.False);
    }
}