using EFFrm.Functions;
using EFFrm.StudentFunctions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EFFrm
{
    
   public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            DatabaseContext databaseContext = new DatabaseContext();
           DoStudentFunctions.AddStudent(databaseContext);
           //DoStudentFunctions studentFunctions= new DoStudentFunctions();
           // DoStudentFunctions.GetStudentList();
           //DoStudentFunctions.GetStudentListWithTake();
           //DoStudentFunctions.GetStudentListWithSkip();
            //DoStudentFunctions.GetStudentListWithTakeAndSkip();
        }
    }
}
