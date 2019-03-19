using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm(10);
            alarm.start();
        }
    }
}
