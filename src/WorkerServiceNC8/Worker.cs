using ClassLibraryNS20;

namespace WorkerServiceNC8
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    IDBHelper dBHelper = new DBHelper();

                    //Using Simple Transaction
                    dBHelper.InsertCustomer1();

                    //Using Transaction Scope
                    dBHelper.InsertCustomer2();

                    //Using Dapper Transaction
                    dBHelper.InsertCustomer3();
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
