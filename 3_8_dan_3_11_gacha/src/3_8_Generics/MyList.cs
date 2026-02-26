using System;

namespace _3_8_Generics;

public class MyList<T> : IMyList<T>
{
    private T[] _nums;
    private int arrIndex = 0;
    public int Capacity
    {
        get { return _nums.Length; }
    }

    public MyList(int capacity = 4)
    {
        _nums = new T[capacity];
    }


    public bool Add(T item)
    {
        if (arrIndex >= Capacity)
        {
            DoubleCapacity();
        }

        _nums[arrIndex] = item;
        arrIndex++;

        return true;
    }

    private void DoubleCapacity()
    {
        T[] newArr = new T[Capacity * 2];
        for (var i = 0; i < Capacity; i++)
        {
            newArr[i] = _nums[i];
        }
        _nums = newArr;
    }


    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void DisplayElements()
    {
        throw new NotImplementedException();
    }

    public T GetById(int index)
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        for (var i = 0; i < Capacity; i++)
        {
            if (_nums[i].Equals(item))
            {
                for (var j = i; j < Capacity - 1; j++)
                {
                    _nums[j] = _nums[j + 1];
                }
                --arrIndex;
                return true;
            }
        }

        return false;
    }

    public bool RemoveAll(T item)
    {
        throw new NotImplementedException();
    }

    public bool RemoveAt(int index)
    {
        throw new NotImplementedException();
    }
}

