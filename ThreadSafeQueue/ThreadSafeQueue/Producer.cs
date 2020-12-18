using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeQueue
{
    public class Producer
    {
        protected readonly MultiThreadedQueue<string> queue;
        protected readonly string name;
        private int seq = 0;

        public Producer(MultiThreadedQueue<string> queue, string name)
        {
            this.queue = queue;
            this.name = name;
        }

        private string GenerateSequence()
        {
            seq++;
            return name + seq;
        }

       internal void ProduceRandomly()
        {
            for(int i = 0; i< 5; i++)
            {
                //Task.Delay(1).Wait();
                Produce();
            }
        }

        private void Produce()
        {
            var message = GenerateSequence();
            queue.Enqueue(message);
            //queue.PrintStatus(name);
        }
    }
}
