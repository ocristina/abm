using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        const string EDIFACT = "UNA:+.? '"
                             + "UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'"
                             + "UNH+EDIFACT+CUSDEC:D:96B:UN:145050'"
                             + "BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'"
                             + "LOC+17+IT044100'"
                             + "LOC+18+SOL'"
                             + "LOC+35+SE'"
                             + "LOC+36+TZ'"
                             + "LOC+116+SE003033'"
                             + "DTM+9:20090527:102'"
                             + "DTM+268:20090626:102'"
                             + "DTM+182:20090527:102'";

        const char TERMINATOR = '\'';
        

        static void Main(string[] args)
        {
            string[] elementsLOC;


            Console.WriteLine(EDIFACT);
            elementsLOC = LOCElements();
            for(int ind = 0;ind < elementsLOC.Length;++ind)
                Console.WriteLine("array[{0}] = {1}",ind,elementsLOC[ind]);
        }

        static string[] LOCElements()
        {
            string[] segments, elements;
            List<string> vecElems = new List<string>();

            segments = EDIFACT.Split(TERMINATOR);
            foreach (string segment in segments)
                if (segment.StartsWith("LOC"))
                {
                    elements = segment.Split('+');
                    if (elements.Length > 1)
                    {
                        vecElems.Add(elements[1]);
                        if (elements.Length > 2)
                        {
                            vecElems.Add(elements[2]);
                        }
                    }
                }
            return vecElems.ToArray();
        }
    }
}
