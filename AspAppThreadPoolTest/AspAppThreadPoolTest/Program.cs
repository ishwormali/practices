using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspAppThreadPoolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10; i++)
            {
                ExecuteTask(i);
            }

            watch.Stop();
            Console.WriteLine("Complete in {0}",watch.Elapsed.TotalSeconds);

            Console.Read();
        }

        static void ExecuteTask(int taskNum)
        {
            
            var taskCollection = new List<Task>();
            var watch = new Stopwatch();

            Console.WriteLine("Task # {0} started",taskNum);

            watch.Start();
            for (int i = 0; i < 60; i++)
            {
                
                taskCollection.Add(Action(i));
            }

           
            Task.WaitAll(taskCollection.ToArray());
            watch.Stop();
            Console.WriteLine("Task # {0} completed in {1}",taskNum, watch.Elapsed.TotalSeconds);

        }

        static Task Action(int requestNum)
        {
            
            return Task.Factory.StartNew(() =>
                                             {
                                                 var httpClient = new HttpClient();
                                                 Stopwatch watch = new Stopwatch();
                                                 watch.Start();
                                                 var content =
                                                     httpClient.GetStringAsync("http://localhost:321/asynctest");
                                                 content.Wait();
                                                 
                                                 watch.Stop();
                                                 Console.WriteLine("Request # {0} completed in {1} with content {2}", requestNum,
                                                                   watch.Elapsed.TotalSeconds, content.Result);
                                             });
        }
    }
}
