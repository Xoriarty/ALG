using System;
using System.Collections;
using System.Collections.Generic;

namespace LAB_3
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }


    internal class LList<T> : IEnumerable<T>
    {

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        Node<T> head;
        Node<T> tail;
        int count;

        public int Count { get { return count; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;

            tail = node;
            count++;
        }

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        public void AddIndex(T data, int index)
        {

            Node<T> node = new Node<T>(data);

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            current.Next = node;

            if (node.Next == null)
                tail = node;

            count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {      
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                return false;

            Node<T> current = head;
            Node<T> previous = null;

            if (index == 0)
            {
                head = head.Next;
                if (head == null)
                    tail = null;
                count--;
                return true;
            }

            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.Next;
            }

            previous.Next = current.Next;
            if (current.Next == null)
                tail = previous;

            count--;
            return true;
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

        public int IndexOf(T data)
        {
            Node<T> current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return index;
                current = current.Next;
                index++;
            }
            return -1; 
        }

        public override string ToString()
        {
            if (head == null) return "Список пуст! ";
            var result = "Список: \n";
            Node<T> current = head;
            while (current != null)
            {
                result += current.Data.ToString();
                current = current.Next;
                if (current != null)
                    result += " ";
            }
            return result;
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

    }
}
    
