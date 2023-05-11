using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerApp.Entities;

namespace ProjectManagerApp.Classes.Tests
{
    [TestClass()]
    public class LaborCostTests
    {
        [TestMethod()]
        public void Check_ProjectWithTasks()
        {
            //Arrange
            Entities.Task _task = new Entities.Task();
            _task.Name = "Test";
            _task.StatusId = 1;
            _task.ExecutorId = 1;
            _task.Deadline = DateTime.Now;
            _task.ProjectId = 1;
            _task.MycroobjectId = 1;
            _task.TypeOFWorkId = 1;
            Entities.Project _project = new Entities.Project();
            _project.Tasks.Add(_task);
            //Act
            float result = LaborCost.CalcLaborCost(_project);
            //Assert
            Assert.AreEqual(0.6f, result);
        }
        [TestMethod()]
        public void Check_ProjectWithoutTasks()
        {
            //Arrange
            
            Entities.Project _project = new Entities.Project();
            //Act
            float result = LaborCost.CalcLaborCost(_project);
            //Assert
            Assert.AreEqual(0, result);

        }
        [TestMethod()]
        public void Check_LaborCostMoreHundredth()
        {
            //Arrange
            Entities.Task _task = new Entities.Task();
            _task.Name = "Test";
            _task.StatusId = 1;
            _task.ExecutorId = 1;
            _task.Deadline = DateTime.Now;
            _task.ProjectId = 1;
            _task.MycroobjectId = 2;
            _task.TypeOFWorkId = 1;
            Entities.Project _project = new Entities.Project();
            _project.Tasks.Add(_task);
            //Act
            float result = LaborCost.CalcLaborCost(_project);
            //Assert
            Assert.AreEqual(0.53f, result);

        }
    }
}