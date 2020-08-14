using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173311068_ysa
{
    class Veriler
    {
        public int[][] veriler = new int[][] 
        { 
           new int[] { // A
                 1, 1, 1, 1, 1 , 
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 1, 1, 1, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 
            },
            new int[]{ // B
                 1, 1, 1, 1, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 1, 1, 1, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 1, 1, 1, 1 
            },
            new int[]{ // C
                 0, 1, 1, 1, 1 ,
                 1, 0, 0, 0, 0 ,
                 1, 0, 0, 0, 0 ,
                 1, 0, 0, 0, 0 ,
                 1, 0, 0, 0, 0 ,
                 1, 0, 0, 0, 0 ,
                 0, 1, 1, 1, 1 
            },
            new int[]{ // D
                 1, 1, 1, 1, 0 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 0, 0, 0, 1 ,
                 1, 1, 1, 1, 0 
            },
            new int[]{ // E
                 1, 1, 1, 1, 1 ,
                 1, 0, 0, 0, 0 ,
                 1, 0, 0, 0, 0 ,
                 1, 1, 1, 1, 1 ,
                 1, 0, 0, 0, 0 ,
                 1, 0, 0, 0, 0 ,
                 1, 1, 1, 1, 1 
            },
        };

        public int[][] beklenenler = new int[][]
        {
            new int[]{ 1,0,0,0,0 },
            new int[]{ 0,1,0,0,0 },
            new int[]{ 0,0,1,0,0 },
            new int[]{ 0,0,0,1,0 },
            new int[]{ 0,0,0,0,1 }
            
            
            
            
        };

    }
}
