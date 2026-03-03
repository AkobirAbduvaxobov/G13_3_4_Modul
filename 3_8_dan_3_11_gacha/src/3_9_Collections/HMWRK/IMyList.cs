namespace _3_9_Collections.HMWRK;

public interface IMyList<T> where T : IEntity
{
    public bool Add(T item);
    public bool RemoveAll(T item);
    public bool Remove(T item);
    public bool Contains(T item);
    public int IndexOf(T item);
    public bool RemoveAt(int index);
    public T GetById(int index);
    public void DisplayElements();
}
