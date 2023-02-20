using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApp.Entities
{
    public partial class User
    {
        public string FullName
        {
            get
            {
                var fullName = $"{FirstName}\n{SecondName}";
                if (Patronymic != null)
                    fullName += $" \n{Patronymic}";
                return fullName;
            }
        }
    }
}
