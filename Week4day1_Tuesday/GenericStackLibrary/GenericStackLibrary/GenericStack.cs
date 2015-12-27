using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackLibrary
{
    public class GenericStack<T>
    {
        private List<T> list = new List<T>();


        public GenericStack(List<T> list)
        {
            this.list = list;
        }

        public T Peek()
        {
            T TopObj;
            if (list.Count != 0)
            {
                TopObj = list[list.Count - 1];
                return TopObj;
            }
            else
            {
                TopObj = default(T);
                return TopObj;
            }
        }

        public T Pop()
        {
            T RemoveTopObj;
            if (list.Count != 0)
            {
                RemoveTopObj = list[list.Count - 1];
                list.Remove(RemoveTopObj);
                return RemoveTopObj;
            }
            else
            {
                throw new ArgumentException("The list is empty.");
            }
        }

        public void Push(T objToAdd)
        {
            list.Add(objToAdd);
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
            } else
            {
                return false;
            }
        }
    }
}
