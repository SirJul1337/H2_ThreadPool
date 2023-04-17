class ThreadPoolDemo
{
    //task 1 with object overload
    public void task1(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }
    //task 2 with object overload
    public void task2(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    static void Main()
    {
        ThreadPoolDemo tpd = new ThreadPoolDemo();
        //loop to start work items with threadpool
        for (int i = 0; i < 2; i++)
        {
            ThreadPool.QueueUserWorkItem(tpd.task1);
            ThreadPool.QueueUserWorkItem(tpd.task2);
        }

        Console.Read();
    }
}