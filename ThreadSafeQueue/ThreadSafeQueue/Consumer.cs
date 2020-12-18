using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeQueue
{
    public class Consumer
    {
        MultiThreadedQueue<String> queue;
        private string name;

        public Consumer(MultiThreadedQueue<String> queue, String name)
        {
            this.queue = queue;
            this.name = name;
        }

        internal void ConsumeRandomly()
        {
            while (true)
            {
                Task.Delay(5).Wait();
                Consume();
            }
        }

        private void Consume()
        {
            var message = queue.Dequeue();
            //queue.PrintStatus(name);
        }
    }
}
