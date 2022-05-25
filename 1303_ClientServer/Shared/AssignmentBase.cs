using System;
using System.Collections.Generic;
using System.Text;

namespace _1303_ClientServer.Shared
{
    public class AssignmentBase
    {
        protected virtual void Execute()
        {
        }

        public void Run()
        {
            this.Execute();
        }
    }
}
