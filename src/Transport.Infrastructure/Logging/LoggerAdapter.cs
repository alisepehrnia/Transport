using Microsoft.Extensions.Logging;

namespace Transport.Infrastructure.Logging
{
	public class LoggerAdapter<T>
	{
		private readonly ILogger<T> _logger;
		public LoggerAdapter(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<T>();
		}

		public void LogWarning(string message, params object[] args)
		{
			_logger.LogWarning(message, args);
		}

		public void LogInformation(string message, params object[] args)
		{
			_logger.LogInformation(message, args);
		}
	}
}