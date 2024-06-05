using System;
using System.Collections.Generic;

public class Deque<T>
{
    private LinkedList<T> _items = new LinkedList<T>();

    // 앞쪽에 요소 추가
    public void AddToFront(T item)
    {
        _items.AddFirst(item);
    }

    // 뒤쪽에 요소 추가
    public void AddToBack(T item)
    {
        _items.AddLast(item);
    }

    // 앞쪽에서 요소 제거 및 반환
    public T RemoveFromFront()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T value = _items.First.Value;
        _items.RemoveFirst();
        return value;
    }

    // 뒤쪽에서 요소 제거 및 반환
    public T RemoveFromBack()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T value = _items.Last.Value;
        _items.RemoveLast();
        return value;
    }

    // 앞쪽의 요소를 반환
    public T PeekFront()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return _items.First.Value;
    }

    // 뒤쪽의 요소를 반환
    public T PeekBack()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return _items.Last.Value;
    }

    // 덱이 비어 있는지 확인
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    // 덱의 요소 개수 반환
    public int Count()
    {
        return _items.Count;
    }
}