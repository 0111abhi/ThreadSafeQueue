using System;
using System.Threading.Tasks;

namespace ThreadSafeQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MultiThreadedQueue<String> queue = new MultiThreadedQueue<string>();
            Producer firstProducer = new Producer(queue, "FirstProducer");
            Producer secondProducer = new Producer(queue, "SecondProducer");
            Producer thirdProducer = new Producer(queue, "ThirdProducer");
            Producer fourthProducer = new Producer(queue, "FourthProducer");
            
            Consumer c = new Consumer(queue, "Consumer");
            
            Task t1 = Task.Run(() => firstProducer.ProduceRandomly());
            Task t2 = Task.Run(() => secondProducer.ProduceRandomly());
            Task t3 = Task.Run(() => thirdProducer.ProduceRandomly());
            Task t4 = Task.Run(() => fourthProducer.ProduceRandomly());
            // Task.Run(() => c.ConsumeRandomly
            Task.WaitAll(t1, t2, t3, t4);
            queue.PrintStatus("Main");
            Console.ReadKey();
        }
    }
}
