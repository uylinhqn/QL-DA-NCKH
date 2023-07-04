using System;
using System.Web.Optimization;

namespace QLDANCKH
{
    internal class ScriptBundle
    {
        private string v;

        public ScriptBundle(string v)
        {
            this.v = v;
        }

        internal Bundle Include(string v)
        {
            throw new NotImplementedException();
        }
    }
}