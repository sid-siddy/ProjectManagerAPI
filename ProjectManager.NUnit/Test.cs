using NUnit.Framework;
using ProjectManager.BAL;
using ProjectManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.NUnit
{
    public class Test
    {
        [Test]
        public void Getall()
        {
            ProjectBAL obj = new ProjectBAL();
            int count = obj.GetTask().Count();
            Assert.Greater(count, 0);
        }
        [Test]
        public void Getbytask()
        {
            ProjectBAL obj = new ProjectBAL();
            List<tblTask> Ts = obj.GetTask();            
            tblTask count = obj.GetTaskbyId(Ts[0].TaskId);
            Assert.IsNotNull(count);
            
        }
        [Test]
        public void AddTask()
        {
            ProjectBAL obje = new ProjectBAL();
            int count = obje.GetTask().Count();            
            tblTask T = (new tblTask { TaskName = "Testtaskname", TStartDate = DateTime.Now, TEndDate = DateTime.Now, TPriority = 10, TStatus = false, ParentTaskName = "parenttask", UserId = 1 });
            obje.AddTask(T);
            int count1 = obje.GetTask().Count();
            Assert.AreEqual(count1, count + 1);
        }
          [Test]
        public void DeleteTask()
        {
            ProjectBAL obj = new ProjectBAL();
            List<tblTask> Ts = obj.GetTask();
            tblTask Taskgetbyid = obj.GetTaskbyId(Ts[0].TaskId);
            int count1 = obj.GetTask().Count();
            obj.DeleteTask(Taskgetbyid.TaskId);
            int count2 = obj.GetTask().Count();
            Assert.AreEqual(count2, count1 - 1);
        }
    }
}

