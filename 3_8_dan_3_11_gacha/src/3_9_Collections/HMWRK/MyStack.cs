namespace _3_9_Collections.HMWRK;

public class MyStack<T> : IMyStack<T>
{
    private List<T> _items;
    public MyStack(int capacity = 4)
    {
        _items = new List<T>(capacity);
    }
    public T Peek()
    {
        var res = _items[_items.Count - 1];
        return res;
    }

    public T Pop()
    {
        var res = _items[_items.Count - 1];
        _items.RemoveAt(_items.Count - 1);
        return res;
    }

    public void Push(T item)
    {
        _items.Add(item);
    }
}
