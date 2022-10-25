using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ChineseChess.Helpers
{
	internal class LogHelper
	{
		public static readonly ILog logInfo = LogManager.GetLogger("logInfo");
		public static readonly ILog logError = LogManager.GetLogger("logError");

		public static void Info(string info)
		{
			logInfo.Info(info);
			//if (logInfo.IsInfoEnabled)
			//{
			//	logInfo.Info(info);
			//}
		}

		public static void InfoFormat(string info, params object[] args)
		{
			if(args != null && args.Length > 0)
			{
				info = string.Format(info, args);
			}
			LogHelper.Info(info);
		}

		public static void Error(string mesg)
		{
			if(logInfo.IsErrorEnabled)
			{
				logError.Error(mesg);
			}
		}

		public static void ErrorFormat(string mesg, params object[] args)
		{
			if (args != null && args.Length > 0)
			{
				mesg = string.Format(mesg, args);
			}
			LogHelper.Error(mesg);
		}
	}
}
