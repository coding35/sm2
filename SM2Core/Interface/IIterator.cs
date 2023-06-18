namespace SM2Core.Interface;

public interface IIterator<out T>
{
    bool HasNext();
    T? Next();
    void Remove();
    T? CurrentItem();
    int GetIteration();
}