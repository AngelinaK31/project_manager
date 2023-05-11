using ProjectManagerApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApp.Classes
{
    public class LaborCost
    {
        public static float CalcLaborCost (Project project)
        {
            float laborCost = 0;

            foreach(var task  in project.Tasks)
            {
                switch (task.MycroobjectId)
                {
                    case 1:
                        if(task.TypeOFWorkId == 1)
                            laborCost += 0.6f;
                        else if(task.TypeOFWorkId == 2)
                            laborCost += 2.4f;
                        else
                            laborCost += 4.8f;
                        break;
                    case 2:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.53f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 2.1f;
                        else
                            laborCost += 4.2f;
                        break;
                    case 3:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.45f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 1.8f;
                        else
                            laborCost += 3.6f;
                        break;
                    case 4:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.38f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 1.5f;
                        else
                            laborCost += 3f;
                        break;
                    case 5:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.3f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 1.2f;
                        else
                            laborCost += 2.4f;
                        break;
                    case 6:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.23f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 0.9f;
                        else
                            laborCost += 1.8f;
                        break;
                    case 7:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.15f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 0.6f;
                        else
                            laborCost += 1.2f;
                        break;
                    case 8:
                        if (task.TypeOFWorkId == 1)
                            laborCost += 0.5f;
                        else if (task.TypeOFWorkId == 2)
                            laborCost += 1f;
                        else
                            laborCost += 1.5f;
                        break;

                }
            }
            laborCost = (float)Math.Round(laborCost, 2, MidpointRounding.AwayFromZero);
            return laborCost;
        }
    }
}
