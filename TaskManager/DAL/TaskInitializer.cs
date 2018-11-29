using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TaskManager.Models;
using TaskManager.Util;

namespace TaskManager.DAL
{
    public class TaskInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TaskManagerContext>
    {
        int encryptionKey = 200;

        protected override void Seed(TaskManagerContext context)
        {
            var users = new List<User> {
                new User{Forename="Aimee",Surname="Hilliard",UserName ="ahilliard", Password = SimpleEncryption.EncryptDecrypt("Password", encryptionKey), MothersMaidenName = "test"},
                new User{Forename="Joe",Surname="Smith",UserName ="jsmith", Password = SimpleEncryption.EncryptDecrypt("Password123", encryptionKey), MothersMaidenName = "test"}
            };

            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();

            var tasks = new List<Task> {
                new Task{UserId = 1, TaskDescription = "Write unit tests", Complete = false, LastUpdated = DateTime.Parse("2018-11-01")},
                new Task{UserId = 1, TaskDescription = "Do Code reviews", Complete = false, LastUpdated = DateTime.Parse("2018-11-01")},
                new Task{UserId = 1, TaskDescription = "Meeting at 1", Complete = false, LastUpdated = DateTime.Parse("2018-11-01")},

                new Task{UserId = 2, TaskDescription = "Write unit tests", Complete = false, LastUpdated = DateTime.Parse("2018-11-01")},
                new Task{UserId = 2, TaskDescription = "Do Code reviews", Complete = false, LastUpdated = DateTime.Parse("2018-11-01")},
                new Task{UserId = 2, TaskDescription = "Meeting at 1", Complete = false, LastUpdated = DateTime.Parse("2018-11-01")},

            };

            tasks.ForEach(s => context.Task.Add(s));
            context.SaveChanges();            
        }     
    }
}