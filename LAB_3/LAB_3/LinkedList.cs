using System;

public class Node<T>
{
    public T Value;
    public Node<T> Next;
    public Node<T> Previous;

    public Node(T value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
}

public class LinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    int count;

    public int Count { get { return count; } }

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public void AddLast(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        count ++;
    }

    public void AddFirst(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        count++;
    }
    public bool Remove(T value)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;
                count--;
                return true;
            }
            current = current.Next;
        }
        return false; 
    }
    public bool RemoveLast()
    {
        if (tail == null)
        {
            return false;
        }

        T value = tail.Value;

        if (tail.Previous != null)
        {
            tail = tail.Previous;
            tail.Next = null;
        }
        else
        {
            head = null;
            tail = null;
        }

        Console.WriteLine($"Удален последний элемент: {value}");
        return true;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public int IndexOf(T value)
    {
        Node<T> current = head;
        int index = 0;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    public override string ToString()
    {
        if ( head == null ) return "Список пуст! ";
        Node<T> current = head;
        string result = "";
        while (current != null)
        {
            result += current.Value + " ";
            current = current.Next;
        }
        return "Список: \n" + result.Trim();
    }
}
