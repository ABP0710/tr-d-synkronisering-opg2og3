namespace tråd_synkronisering_opg2og3
{
    internal class Program
    {
        static int forForloops = 60;

        static object _lock = new object();

        static void Main(string[] args)
        {
            Thread s = new Thread(star);
            s.Start();

            Thread h = new Thread(hash);
            h.Start();

            s.Join();
            h.Join();

        }

        static void star()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < forForloops; i++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine(forForloops);
                    forForloops += 60;
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }

        }

        static void hash()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < forForloops; i++)
                    {
                        Console.Write('#');
                    }
                    Console.WriteLine(forForloops);
                    forForloops += 60;
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }
    }
}