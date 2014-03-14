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
         //   Conversion();
            //Foo.Bar();
           // Console.Write(ReturnBool());
            SaveData();
            Console.Read();
        }

        static bool ReturnBool()
        {

            bool a = false;
            bool b = true;
            int i = 4;
            int j = 6;

            bool ret = a || b && false || --j > ++i;
            return ret;
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
                //Foo.Bar = "luljlj";

                //Bar = "444";
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

        
        public static void SaveData()
        {
            try
            {
                ///Save the data in the database which may throw error
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                
            }
            finally {

                EndTask();//task that needs to be executed despite of any error
            }
        }

        
        public static void SaveData()
        {
            try
            {
                ///Save the data in the database which may throw error
                
                EndTask();//task that needs to be executed despite of any error
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                EndTask();//task that needs to be executed despite of any error
                 
            }
            
        }

       
        public static void SaveData()
        {
            try
            {
                ///Save the data in the database which may throw error
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
            }

            EndTask();//code that needs to be executed despite of any error
        }


        /*
       */
        public static void EndTask()
        {
            Console.WriteLine("end task");
        }
         
         
    }


}
