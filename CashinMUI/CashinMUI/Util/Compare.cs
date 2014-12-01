using CashinMUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashinMUI.Util
{
    public class CompareItem : IEqualityComparer<Itemorcamento>
    {
        public bool Equals(Itemorcamento x, Itemorcamento y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Itemorcamento obj)
        {
            return obj.ID.GetHashCode();
        }
    }

    public class CompareTarefa : IEqualityComparer<Tarefa>
    {

        public bool Equals(Tarefa x, Tarefa y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(Tarefa obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
