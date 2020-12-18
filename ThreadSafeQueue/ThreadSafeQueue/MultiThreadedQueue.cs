using System;

namespace ThreadSafeQueue
{
    public class MultiThreadedQueue<T>
    {
        static int MAX_SIZE = 20;
        T[] data;
        private int rear;
        private int front;
        private readonly object dequeueLock = new object();
        private readonly object enqueueLock = new object();
        private readonly object printLock = new object();

        private void setRear()
        {
            rear = (rear + 1) % MAX_SIZE;
        }
        
        private void setFront()
        {
            front = (front + 1) % MAX_SIZE;
        }

        public MultiThreadedQueue()
        {
            data = new T[MAX_SIZE];
            rear = 0;
            front = 0;
        }

        public void Enqueue(T val)
        {
            lock (enqueueLock)
            {
                if (IsFull())
                    return;

                data[rear] = val;
                setRear();
            }
        }

        public T Dequeue()
        {
            lock (dequeueLock)
            {
                if (IsEmpty())
                {
                    return default(T);
                }

                var val = data[front];
                setFront();
                return val;
            }
        }

        bool IsFull()
        {
            if (front == (rear + 1) % MAX_SIZE)
            {
                return true;
            }
            return false;
        }

        bool IsEmpty()
        {
            if (rear == front)
            {
                return true;
            }
            return false;
        }

        public void PrintStatus(string name)
        {
            lock(printLock)
            {
                Console.Write(name);
                Console.Write($"Front: {front}; Rear: {rear};");
                Console.Write("Elements: ");
                int i = front;
                while (true)
                {
                    if (i == rear)
                        break;
                    Console.Write($"{data[i]}--");
                    i = (i + 1) % MAX_SIZE;
                }

                Console.WriteLine();
            }
        }

    }
}
