namespace _3_9_Collections.HMWRK;

public interface IMyStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
}