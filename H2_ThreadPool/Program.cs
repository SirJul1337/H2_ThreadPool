using System;
using System.Threading;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        /// <summary>
        /// Method call methods and taking time threadpool vs normal thread 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");
            sw.Start();
            ProcessWithThreadPoolMethod(); 
            sw.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + sw.ElapsedTicks.ToString()+ "Ticks");
            sw.Reset();
            Console.WriteLine("Thread Execution");
            sw.Start();
            ProcessWithThreadMethod();
            sw.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + sw.ElapsedTicks.ToString() + "Ticks");
        }
        /// <summary>
        /// Method to loop through with thread pool, creating work items
        /// </summary>
        static void ProcessWithThreadPoolMethod()
        {

            //TASK 1
            //406363 ticks

            //TASK  2
            //Loop 1: 513220 ticks
            //Loop 2: 434200 ticks

            
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        /// <summary>
        /// Method for creating threads and starting them the slow way with no pool
        /// </summary>
        static void ProcessWithThreadMethod()
        {

            //TASK 1
            //969300 ticks

            //TASK 2
            //1 loop: 992470 ticks
            //2 loop: 27709254 ticks


            //Loop to create threads and starting them
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        /// <summary>
        /// Method consist of nested loop to act as big workload, used for benchmarking
        /// </summary>
        /// <param name="callback"></param>
        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
        }
    }
}