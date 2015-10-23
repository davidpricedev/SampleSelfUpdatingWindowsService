using System;
using System.Diagnostics;
using System.Timers;

namespace ServiceTesting
{
    public class TownCrier
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly Timer _timer;
        private readonly int intervalSeconds = 2;

        private int times = 0;

        public TownCrier()
        {
            _timer = new Timer(TimeSpan.FromSeconds(intervalSeconds).TotalMilliseconds) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => this.AllTheLogicForMainServiceStuffGoesHere();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void AllTheLogicForMainServiceStuffGoesHere()
        {
            var message = string.Format("It is {0} and all is well", DateTime.Now);
            Console.WriteLine(message);
            logger.Debug(message);
            times += 1;

            if (this.IsReadyForUpgrade())
            {
                this.UpgradeMyself();
            }
        }

        public bool IsReadyForUpgrade() {
            return this.times == 10;
        }

        public void UpgradeMyself()
        {
            logger.Debug("Starting Upgrade Process");
            var procData = new ProcessStartInfo(@"..\Upgrade\Upgrade.bat");
            
            procData.WindowStyle = ProcessWindowStyle.Hidden;
            procData.UseShellExecute = false;
            procData.WorkingDirectory = @"..\Upgrade\";

            var proc = Process.Start(procData);
        }
    }
}