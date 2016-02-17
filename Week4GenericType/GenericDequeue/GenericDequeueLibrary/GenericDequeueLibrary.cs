using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDequeueLibrary
{
    public class GenericDequeue<T>
    {
        private List<T> list;

        public GenericDequeue(List<T> list)
        {
            this.list = list;
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T objToSearch)
        {
            if (list.Contains(objToSearch))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T RemoveFromFront()
        {
            T objToRemove;
            if (list.Count != 0)
            {
                objToRemove = list[0];
                list.Remove(objToRemove);
                return objToRemove;
            }
            else
            {
                throw new ArgumentException("The list is empty!");
            }
        }


        public T RemoveFromEnd()
        {
            T objToRemove;
            if (list.Count != 0)
            {
                objToRemove = list[list.Count - 1];
                list.Remove(objToRemove);
                return objToRemove;
            }
            else
            {
                throw new ArgumentException("The list is empty!");
            }

        }

        public void AddToFront(T objToAdd)
        {
            list.Insert(0, objToAdd);
        }

        public void AddToEnd(T objToAdd)
        {
            list.Insert(list.Count, objToAdd);
        }

        public T PeekFromFront()
        {
            T objToPeek;
            if (list.Count != 0)
            {
                objToPeek = list[0];
                return objToPeek;
            }
            else
            {
                throw new ArgumentException("The list is empty!");
            }
        }

        public T PeekFromEnd()
        {
            T objToPeek;
            if (list.Count != 0)
            {
                objToPeek = list[list.Count - 1];
                return objToPeek;
            } else
            {
                throw new ArgumentException("The list is empty!");
            }
        }
    }
}
