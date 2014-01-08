using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestionsCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Conversion();
            //Foo.Bar();
            Console.Read();
        }

        public static void Conversion()
        {
            //float f = 10.9F;        a)

            //int i = (int)f;         b)  

            //double d = i;           c) 
 
            //Single s = d;           d) 
 
        }

        public class Foo
        {
            public const string Bar = "999";
            
            public Foo()
            {
                Foo.Bar = "luljlj";

                Bar = "444";
            }
        }


        //public static class Foo
        //{
        //    static Foo()
        //    {
        //        Console.WriteLine(" Foo ");
        //    }

        //    public static void Bar()
        //    {
        //        Console.WriteLine(" Bar ");
        //    }
        //}

        public static void PrintData()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(++i);
            }
        }

        /*
        public void SaveData()
        {
            try
            {
                ///Save the data in the database which may throw error
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
            finally {

                EndTask();//task that needs to be executed despite of any error
            }
        }

        public void SaveData()
        {
            try
            {
                ///Save the data in the database which may throw error

                EndTask();//task that needs to be executed despite of any error
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public void SaveData()
        {
            try
            {
                ///Save the data in the database which may throw error

            }
            catch (Exception ex)
            {

                EndTask();//task that needs to be executed despite of any error
                throw;
            }

            EndTask();//code that needs to be executed despite of any error
        }


        public void EndTask()
        {

        }
         
         */
    }


}
