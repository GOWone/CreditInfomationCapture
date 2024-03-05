using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uselndll
{
	/// <summary>
	/// 系统异常信息
	/// </summary>
	public class SysExceptInfo
	{
		private Exception exception;

		private string functionName = "";

		private Type type;

		private string exceptFullName;

		private DateTime eventTime;

		private string exceptMessage;

		private string exceptSource;

		private static string DEBUG_LOG = Path.Combine(Application.StartupPath, "DebugLog");

		private static string Template = "发生时间:{0} 发生事件:{1}";

		public static bool showLog = false;

		public string FunctionName => functionName;

		/// <summary>
		/// 完全限定名(预留)
		/// </summary>
		public string ExceptFullName => exceptFullName;

		/// <summary>
		/// 发生时间
		/// </summary>
		public DateTime EventTime => eventTime;

		/// <summary>
		/// 异常名称
		/// </summary>
		public string ExceptMessage => exceptMessage;

		/// <summary>
		/// 异常来源
		/// </summary>
		public string ExceptSource => exceptSource;

		/// <summary>
		/// 初始化异常信息(实例化)
		/// </summary>
		/// <param name="error">异常实例</param>
		public SysExceptInfo(Exception error)
		{
			exception = error;
			eventTime = DateTime.Now;
			exceptMessage = exception.Message;
			exceptSource = exception.Source;
		}

		/// <summary>
		/// 初始化异常信息(实例化)
		/// </summary>
		/// <param name="error">异常实例</param>
		/// <param name="type">类型</param>
		public SysExceptInfo(Exception error, Type type)
		{
			exception = error;
			this.type = type;
			exceptFullName = type.FullName;
			eventTime = DateTime.Now;
			exceptMessage = exception.Message;
			exceptSource = exception.Source;
		}

		/// <summary>
		/// 异常信息写入日志文件中(每小时一个文件)
		/// </summary>
		public void WriteExceptLogToTxt()
		{
			string format = "发生时间:{0} 异常消息：{6} 异常名称:{1} 异常来源:{2} 异常堆栈:{3} 当前实例:{4} 当前方法:{5} ";
			format = string.Format(format, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), exceptMessage, exceptSource, exception.StackTrace, exception.InnerException, exception.TargetSite, exception.Message);
			string text = Path.Combine(Application.StartupPath, "ErrorLog");
			if (!Directory.Exists(text))
			{
				try
				{
					Directory.CreateDirectory(text);
				}
				catch
				{
				}
			}
			try
			{
				string path = Path.Combine(text, DateTime.Now.ToString("yyyyMMddHH") + ".Txt");
				using (StreamWriter streamWriter = new StreamWriter(path, append: true))
				{
					streamWriter.WriteLine(format);
					streamWriter.Close();
				}
			}
			catch (Exception)
			{
			}
		}

		public void WriteExceptLogToTxt(string functionName)
		{
			lock ("error_lock")
			{
				string format = "函数名:{7}发生时间:{0} 异常消息：{6} 异常名称:{1} 异常来源:{2} 异常堆栈:{3} 当前实例:{4} 当前方法:{5} ";
				format = string.Format(format, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), exceptMessage, exceptSource, exception.StackTrace, exception.InnerException, exception.TargetSite, exception.Message, functionName);
				string text = Path.Combine(Application.StartupPath, "ErrorLog");
				if (!Directory.Exists(text))
				{
					try
					{
						Directory.CreateDirectory(text);
					}
					catch
					{
					}
				}
				try
				{
					string path = Path.Combine(text, DateTime.Now.ToString("yyyyMMddHH") + ".Txt");
					using (StreamWriter streamWriter = new StreamWriter(path, append: true))
					{
						streamWriter.WriteLine(format);
						streamWriter.Close();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		public static void WriteLogToTxt(string ip, string message)
		{
			if (showLog)
			{
				lock ("log_lock")
				{
					if (!Directory.Exists(DEBUG_LOG))
					{
						Directory.CreateDirectory(DEBUG_LOG);
					}
					string path = Path.Combine(DEBUG_LOG, ip + "_" + DateTime.Now.ToString("yyyyMMddHH") + ".Txt");
					using (StreamWriter streamWriter = new StreamWriter(path, append: true))
					{
						try
						{
							streamWriter.WriteLine(string.Format(Template, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message));
							streamWriter.Close();
						}
						catch (Exception error)
						{
							SysExceptInfo sysExceptInfo = new SysExceptInfo(error);
							sysExceptInfo.WriteExceptLogToTxt();
						}
					}
				}
			}
		}

		public static void WriteLogToTxt(string message)
		{
			WriteLogToTxt("Debug", message);
		}

		/// <summary>
		/// 异常信息写入日志文件中(每小时一个文件)
		/// </summary>
		/// <param name="saveLog">是否保存日志</param>
		public void WriteExceptLogToTxt(bool saveLog)
		{
			if (saveLog)
			{
				WriteExceptLogToTxt();
			}
		}
	}
}
