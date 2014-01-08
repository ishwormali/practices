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

        }

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
    }


}
