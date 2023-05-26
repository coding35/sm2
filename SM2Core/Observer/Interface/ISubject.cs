namespace SM2Core.Observer.Interface;

public interface ISubject
{
    void AddObserver(IObserver? observer);
    void RemoveObserver(IObserver? observer);
    void NotifyObservers();
}