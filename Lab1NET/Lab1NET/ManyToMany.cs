using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1NET
{
    internal class ManyToMany
    {
        /*
         * The ManyToMany class created to implement a many-to-many relationship. It contains of two IDs (left and right) 
         *  and has a constructor to initialize these values
         */
        public int leftId { get; }
        public int rightId { get; }

        public ManyToMany(int left_Id, int right_Id)  {
            leftId = left_Id;
            rightId = right_Id;
        }
    }
}
