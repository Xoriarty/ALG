using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
    public Node(T data)
    {
        Data = data;
    }

    public T Data { get; set; }
    public Node<T> Next { get; set; }
}

public class Queue<T> : IEnumerable<T>
{
    private Node<T> head; 
    private Node<T> tail;
    private int count;

    
    public void Enqueue(T data)
    {
        Node<T> node = new Node<T>(data);
        Node<T> tempNode = tail;
        tail = node;
        if (count == 0)
            head = tail;
        else
            tempNode.Next = tail;
        count++;
    }

  
    public T Dequeue()
    {
        if (count == 0)
            throw new InvalidOperationException("Очередь пуста!");

        T output = head.Data;
        head = head.Next;
        count--;
        return output;
    }

    public T First
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста!");
            return head.Data;
        }
    }

    public T Last
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста!");
            return tail.Data;
        }
    }

    public int Count { get { return count; } }
    public bool IsEmpty { get { return count == 0; } }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public bool Contains(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void Split(out Queue<T> positiveQueue, out Queue<T> negativeQueue)
    {
        positiveQueue = new Queue<T>();
        negativeQueue = new Queue<T>();
        Node<T> current = head;

        while (current != null)
        {
            if (Convert.ToInt32(current.Data) >= 0)
                positiveQueue.Enqueue(current.Data);
            else
                negativeQueue.Enqueue(current.Data);

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