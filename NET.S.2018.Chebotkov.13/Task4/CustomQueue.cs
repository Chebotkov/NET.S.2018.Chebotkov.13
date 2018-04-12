using System;
using System.Collections;
using System.Collections.Generic;

namespace Task4
{
    /// <summary>
    /// Representation od the queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        private int resize = 8;
        private int positionOfTheFirstElement = 0;
        private int positionOfTheLastElement = 0;
        private int count = 0;
        private T[] queue;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomQueue{T}"/>
        /// </summary>
        public CustomQueue()
        {
            queue = new T[resize];
        }

        /// <summary>
        /// Gets count of the elemnts in the queue.
        /// </summary>
        public int Count { get { return count; } } 

        /// <summary>
        /// Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <returns>True if contains. False if doesn't.</returns>
        public bool Contains(T item)
        {
            for (int i = positionOfTheFirstElement; i <= positionOfTheLastElement; i++)
            {
                if ((dynamic)item == queue[i])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        public void Dequeue()
        {
            positionOfTheFirstElement++;
            positionOfTheLastElement++;
            count--;
        }

        /// <summary>
        /// Adds an object to the end of the Queue.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Enqueue(T item)
        {
            if (positionOfTheLastElement >= queue.Length - 1)
            {
                Resize(ref queue, queue.Length + resize);
            }

            positionOfTheLastElement++;
            queue[positionOfTheLastElement] = item;
            count++;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return queue[positionOfTheFirstElement];
        }

        /// <summary>
        /// Removes all objects from the Queue.
        /// </summary>
        public void Clear()
        {
            queue = new T[resize];
            count = 0;
            positionOfTheFirstElement = 0;
            positionOfTheLastElement = 0;
        }
        
        /// <summary>
        /// Resizes queue.
        /// </summary>
        /// <param name="array">Current queue.</param>
        /// <param name="newSize">New queue size.</param>
        private void Resize(ref T[] array, int newSize)
        {
            T[] newArray = new T[newSize];
            for (int i = positionOfTheFirstElement, j = 0; i <= positionOfTheLastElement; i++, j++)
            {
                newArray[j] = array[i];
            }

            array = newArray;
            positionOfTheLastElement -= positionOfTheFirstElement;
            positionOfTheFirstElement = 0;
        }

        /// <summary>
        /// Implements GetEnumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = positionOfTheFirstElement; i <= positionOfTheLastElement; i++)
            {
                yield return queue[i];
            }
        }

        /// <summary>
        /// Implements GetEnumerator.
        /// </summary>
        /// <returns>IEnumerator instance.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
