using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int count;

    private class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public void AddFront(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (IsEmpty)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        count++;
    }

    public void AddBack(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (IsEmpty)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    public T RemoveFront()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Дек пуст!");

        T output = head.Data;
        head = head.Next;

        if (head != null)
            head.Previous = null;
        else
            tail = null; 

        count--;
        return output;
    }

    public T RemoveBack()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Дек пуст!");

        T output = tail.Data;
        tail = tail.Previous;

        if (tail != null)
            tail.Next = null;
        else
            head = null; 

        count--;
        return output;
    }

    public int Count => count;
    public bool IsEmpty => count == 0;

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void Split(out Deque<T> positiveDeque, out Deque<T> negativeDeque)
    {
        positiveDeque = new Deque<T>();
        negativeDeque = new Deque<T>();
        Node<T> current = head;

        while (current != null)
        {
            if (Convert.ToInt32(current.Data) >= 0)
                positiveDeque.AddBack(current.Data);
            else
                negativeDeque.AddBack(current.Data);

            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
