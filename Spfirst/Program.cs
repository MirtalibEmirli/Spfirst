using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;


internal class Program
{



    private static AutoResetEvent event_1 = new AutoResetEvent(true);
    private static AutoResetEvent event_2 = new AutoResetEvent(false);

    static void Main()
    {
        Console.WriteLine("Press Enter to create three threads and start them.\r\n" +
                          "The threads wait on AutoResetEvent #1, which was created\r\n" +
                          "in the signaled state, so the first thread is released.\r\n" +
                          "This puts AutoResetEvent #1 into the unsignaled state.");
        Console.ReadLine();

        for (int i = 1; i < 4; i++)
        {
            Thread t = new Thread(ThreadProc);
            t.Name = "Thread_" + i;
            t.Start();
        }
        Thread.Sleep(250);

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Press Enter to release another thread.");
            Console.ReadLine();
            event_1.Set();
            Thread.Sleep(250);
        }

        Console.WriteLine("\r\nAll threads are now waiting on AutoResetEvent #2.");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Press Enter to release a thread.");
            Console.ReadLine();
            event_2.Set();
            Thread.Sleep(250);
        }

        // Visual Studio: Uncomment the following line.
        //Console.Readline();
    }

    static void ThreadProc()
    {
        string name = Thread.CurrentThread.Name;

        Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
        event_1.WaitOne();
        Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

        Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
        event_2.WaitOne();
        Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

        Console.WriteLine("{0} ends.", name);
    }

    #region AutoResetEvent
    /*
        private static AutoResetEvent blok = new(false);
        private static AutoResetEvent blok1 = new(false);
        private static void Main(string[] args)
        {
            var t = new Thread(SomeProc);
            t.Start();

            Console.WriteLine("Starting Main");
                blok.WaitOne();  //BIZ BURDa main thread i gozledirik  blok.WaitOne(); satırı, Main thread'ini duraklatır (bloke eder),
            *//*Buna gore artiq o islemir qaldi yerde durur ve o bri thread switch olunur ve baslayir islemeye bele olan halda switch olmur yeni t thread i isleyr ancaq buna gore de biz bu main threadde yazsaq bele blok.set olmur cunki o bri threadde qaldigi ucun ordan set yeni signal gelmelidirki men isimi bitirdim sen basla*//*

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main: {i}");
                Thread.Sleep(100);
            }
             blok1.Set();
        }

        private static void SomeProc()
        {
            Console.WriteLine("Starting SomeProc");
            Console.WriteLine("Set olundu");
            blok.Set(); //ve burda artiq main thread e signal gedirki davam ed sen , switch olur main  threade ve qaldigi yerden davam edir ordaki isleri gorur 
              //  Thread.Sleep(1000); //set edddikden sonra bu threadi sleep edrem deye birbasa qaydr maine ve orani isleyir
            Console.WriteLine("wait edildi");
               blok1.WaitOne(); 
            //eyer biz burdaki blok1 i wait eddrimesek normal qaydada switching prossesi gedecek amma biz wait edirik yeni Set oldu sozu cxr ve blok set olunur qaydir maine orda isini gorur, blok1 wait olduguna gore o bri yeni switch oldugu thread den cavab gozleyirki men ne zaman baslayim ve ordada set olur yeni signal gelirki basla

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Process: {i}");
                Thread.Sleep(100);
            }

        }

   */
    #endregion

    // Thread
    // ThreadPool
    // TPL (Task Paralel Library)

    #region Create Task
    /*

    private static void TaskMethod(string name)
    {
        Console.WriteLine($"{name} is running. Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    }
    private static void Task2 (string n)
    {
        Console.WriteLine($"{n} is running . ID : {Thread.CurrentThread.ManagedThreadId} ISThreadPool :{Thread.CurrentThread.IsThreadPoolThread}");
    }
    static void Main(string[] args)
    {
        //var task = new Task(() => { Console.WriteLine("task"); });
        //task.Start();

        var task = new Task(() => { TaskMethod("Task 1"); });
        task.Start();
        var task3 = new Task(() => { Task2("T 2"); });
        task3.Start();
     //   new Task(() => { TaskMethod("Task 2"); }).Start();

        var t1 = Task.Run(() => { TaskMethod("Task 3"); });

        var t2 = Task.Factory.StartNew(() => { TaskMethod("Task 4"); });

        var t3 = Task.Factory.StartNew(() => { TaskMethod("Task 5"); }, TaskCreationOptions.LongRunning);

        Console.WriteLine("AAA");

        *//*Console.ReadKey();*//*
    }

 */
    #endregion


    #region Working

    /*private static int TaskMethod(string name)
    {
        Console.WriteLine($"{name} is running. Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
        Thread.Sleep(2000);

        return 42;
    }

    static void Main(string[] args)
    {
        var t = new Task<int>(() => TaskMethod("Task 1"));
        t.Start();

         var result = t.Result;
        Console.WriteLine(result);//result isdedikde main threade kecmir gozdyurku task isini bitirsin
    
        Console.WriteLine("salam");
        *//* var t2 = new Task<int>(() => TaskMethod("Task 2"));
         t2.RunSynchronously();
         TaskMethod("Main");

         var t1 = new Task<int>(() => TaskMethod("Task2"));

         t1.Start();

         t1.ContinueWith(t =>
         {
             Console.WriteLine($"Result: {t.Result}. Id: {Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
         });

         Console.ReadKey();*//*



    }
*/
}

#endregion















//------------------------------------------------------------------------------------------------===========================----------------------------------====================================







/*using System;
using System.Threading;
int counter = 0;
object lockObj = new object();
void IncrementCounter()
{
    for (int i = 0; i < 100000; i++)
    {lock (lockObj) ;
        counter++;
    }
}

Thread t1 = new Thread(IncrementCounter);
Thread t2 = new Thread(IncrementCounter);

t1.Start();
t2.Start();

t1.Join();
t2.Join();

Console.WriteLine(counter);

*/


/*


SomeDelegate del = DoSomething;

IAsyncResult result = del.BeginInvoke(null, null);
del.EndInvoke(result);

static void DoSomething()
{
    Console.WriteLine($"{Thread.CurrentThread.Name} {Thread.CurrentThread.ManagedThreadId} {Thread.CurrentThread.IsThreadPoolThread} {Thread.CurrentThread.IsBackground}");
    Thread.Sleep(1000);
    Console.WriteLine("DoSomething");
}


delegate void SomeDelegate();*/

/*
 * 
 * 
 * 
 * try
{
    var pr = Process.GetProcessesByName("mspaint");
    foreach (var item in pr)
    {
        Console.WriteLine(item.Id + " " + item.ProcessName);
        // item.Kill();
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}

 var paints = Process.GetProcesses(); 

try
{
    foreach (var p in paints)
    {
        Console.WriteLine($"{p.Id} {p.ProcessName} {p.MachineName} {p.Threads.Count}");

        //   p.Kill();

    } }
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}*/
/*

try
{
    Console.WriteLine(Environment.ProcessorCount);

}
catch (Exception)
{

    throw;
}
*/
/*

var ps = new ProcessStartInfo();
ps.FileName = "notepad";
ps.Arguments = "n12";
ps.WindowStyle = ProcessWindowStyle.Maximized;
Process.Start(ps);
 

var a = new Process();
a.StartInfo = ps;
a.Start();
Process.Start(a.StartInfo);*/
/*static void DoTask()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Thread çalışıyor... Adım: {i}");
        Thread.Sleep(1000); // 1 saniye beklet
    }
}

Thread thread = new Thread(DoTask);
thread.Start();
for (int i = 0; i < 555; i++)
{
    Console.WriteLine($"Thread  ... Adım: {i}");
    Thread.Sleep(20);
     
}*/

//undefined behaviour
/*
for (int i = 0; i < 10; i++)
{
    int tt = i;
    Thread t = new(() => Console.WriteLine(tt));
    t.Start();
}
*/
