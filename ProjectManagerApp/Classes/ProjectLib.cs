using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagerApp.Classes
{
    public class ProjectLib
    {
        public static bool CheckProjectData(Entities.Project project, out string reason)
        {
            StringBuilder stringBuilder= new StringBuilder();

            reason = string.Empty;
           
            if(string.IsNullOrWhiteSpace(project.Name))
                stringBuilder.AppendLine("Введите имя");

            if (project.Deadline < project.CreationDate)
                stringBuilder.AppendLine("Дейдлайн не может быть до начала создания проекта");

            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                reason = stringBuilder.ToString();
                return false;
            }
            else
            {
                return true;
            }
                
        }
    }
}
