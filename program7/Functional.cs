using System;
using System.Collections;
using System.Collections.Generic;

public class Node
{
    public int Value { get; set; }

    public Node Next { get; set; }

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}

public class SinglyLinkedList : IEnumerable<int>
{
    private Node _head;
    private int _count;

    public SinglyLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public int Count => _count;

    public void AddAfterFirst(int value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            newNode.Next = _head.Next;
            _head.Next = newNode;
        }
        _count++;
    }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            Node current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        if (index == 0)
        {
            _head = _head.Next;
        }
        else
        {
            Node current = _head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        _count--;
    }

    public int? FindFirstGreaterThan(int value)
    {
        Node current = _head;
        while (current != null)
        {
            if (current.Value > value)
                return current.Value;
            current = current.Next;
        }
        return null;
    }

    public int SumLessThan(int value)
    {
        int sum = 0;
        Node current = _head;
        while (current != null)
        {
            if (current.Value < value)
                sum += current.Value;
            current = current.Next;
        }
        return sum;
    }

    public SinglyLinkedList GetElementsGreaterThan(int value)
    {
        SinglyLinkedList result = new SinglyLinkedList();
        Node current = _head;
        while (current != null)
        {
            if (current.Value > value)
                result.AddAfterFirst(current.Value);
            current = current.Next;
        }
        return result;
    }

    public void RemoveAfterMax()
    {
        if (_head == null || _head.Next == null)
            return;

        Node maxNode = _head;
        Node current = _head;
        int maxValue = _head.Value;
        int maxIndex = 0;
        int currentIndex = 0;

        while (current != null)
        {
            if (current.Value > maxValue)
            {
                maxValue = current.Value;
                maxNode = current;
                maxIndex = currentIndex;
            }
            current = current.Next;
            currentIndex++;
        }
        maxNode.Next = null;
        _count = maxIndex + 1;
    }

    public IEnumerator<int> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
