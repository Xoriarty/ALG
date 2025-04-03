using System;
using System.Collections;
using System.Collections.Generic;

namespace LAB_4
{
    public struct Person
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public string BirthPlace { get; }
        public string PassportNumber { get; }
        public string Registration { get; }

        public Person(string name, DateTime birthDate, string birthPlace, string passportNumber, string registration)
        {
            Name = name;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            PassportNumber = passportNumber;
            Registration = registration;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Дата рождения: {BirthDate.ToShortDateString()}, Место рождения: {BirthPlace}, " +
                   $"Паспорт: {PassportNumber}, Прописка: {Registration}";
        }
    }

    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> top; 
        private int count;

        private class Node<U>
        {
            public U Data { get; set; }
            public Node<U> Next { get; set; }

            public Node(U data)
            {
                Data = data;
            }
        }

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data)
            {
                Next = top
            };
            top = node;
            count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст!");

            T output = top.Data;
            top = top.Next;
            count--;
            return output;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст!");

            return top.Data;
        }

        public int Count => count;
        public bool IsEmpty => count == 0;

        public void Clear()
        {
            top = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = top;
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
}
