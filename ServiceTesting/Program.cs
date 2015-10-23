using Topshelf;

namespace ServiceTesting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<TownCrier>(s =>
                {
                    s.ConstructUsing(name => new TownCrier());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });


                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                    rc.RestartService(1);
                    rc.RestartService(1);
                    rc.RestartService(1);
                });

                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("SampleTopshelfSvc");
                x.SetServiceName("SampleTopshelfSvc");
            });
        }
    }
}