using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosovRPM_20
{
    public partial class FactoryEntities : DbContext
    {
        private static FactoryEntities context;

        public static FactoryEntities GetContext()
        {
            if (context == null)
                context = new FactoryEntities();
            return context;
        }
    }
}