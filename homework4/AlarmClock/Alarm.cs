using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlarmClock
{
    class Alarm
    {
        public int time { set; get;  }
        private event Action timeUp;

        public Alarm()
        {
            timeUp += doAlarm;
        }

        public Alarm(int time): this()
        {
            this.time = time;
        }

        private void doAlarm()
        {
            Console.WriteLine("Time's up!");
        }

        public void start()
        {
            for (int i = time; i > 0; i--)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
            timeUp();
        }
    }
}
