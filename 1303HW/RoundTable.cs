using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1303HW
{

    class RoundTable<T> : IEnumerable<T> where T : INameable, IComparable<T> 
    {

        private List<T> entities = new List<T>();

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void RemoveAt(int index)
        {
            if (entities.Count == 0)
                return;

            entities.RemoveAt(index % entities.Count);

            // without module -- zero based
            //int finalIndex = index;
            //while (finalIndex >= entities.Count)
            //{
                //finalIndex = finalIndex - entities.Count;
            //}
        }

        public void Sort()
        {
            /*
             * advanced++ 2020
            if (typeof(T) is IComparable<T>)
            {
                // sort
                entities.Sort();
            }
            else
            {
                // don't sort
            }
            */

            entities.Sort();
        }

        public void Clear()
        {
            entities.Clear();
        }
        public List<T> GetRounded(int length)
        {
            List<T> result = new List<T>();

            // who likes to complicate stuff
            /*
            int finalIndex = length;
            while (finalIndex >= entities.Count)
            {
                finalIndex = finalIndex - entities.Count;
                result.AddRange(entities);
            }
            result.AddRange(entities.GetRange(0, finalIndex));
            */

            int counter = 0;
            int index = 0;
            while (counter++ < length)
            {
                result.Add(entities[index++]);
                if (index >= entities.Count)
                    index = 0;
            }

            return result;
        }

        public void InsertAt(int index, T item)
        {
            entities.Insert(index % entities.Count, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (entities.Count == 0)
                    return default(T);
                return entities[index % entities.Count];
            }
        }

        public T this[string name]
        {
            get
            {
                if (entities.Count == 0)
                    return default(T);

                foreach (T entity in entities)
                {
                    if (entity.Name == name)
                        return entity;
                }

                return default(T);
            }
        }
    }
}
