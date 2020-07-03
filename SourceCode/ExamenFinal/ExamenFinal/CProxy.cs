using System;
using System.Collections.Generic;

namespace ExamenFinal
{
    public class CProxy
    {
        public interface ILogin
        {
            void log(int op);
        }

        public class BProxy : ILogin
        {
            

            public void log(int op)
            {

                if (op == 1)
                {
                    
                }
                else if (op == 2)
                {
                            
                }
                else if (op == 3)
                {
                    
                }
                else if (op == 4)
                {
                    
                }
            }
        }
    }

        public class IniciodeSesion
        {

        }
}
