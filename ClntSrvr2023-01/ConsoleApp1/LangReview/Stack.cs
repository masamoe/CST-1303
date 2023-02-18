using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.LangReview
{
    public class Stack<T>
    {
        private int _position;
        private int _size;
        private T[] _data;

        public Stack(int size = 100) 
        { 
            _position = 0;
            _size = size;
            _data = new T[size];
        }

        public int Count()
        {
            return _position;
        }

        public void Push(T item)
        {
            if (_position < _size)
            {
                _data[_position++] = item;
            }
            else
            {
                throw new Exception("stack is full");
            }
        }

        public T Pop()
        {
            if (_position > 0)
            {
                return _data[--_position];
            }

            return default(T);
        }

        public T Peek()
        {
            if (_position > 0)
            {
                return _data[_position - 1];
            }

            return default(T);
        }
    }
}
