using System;
using System.Collections.Generic;
using System.Text;

namespace Common
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
