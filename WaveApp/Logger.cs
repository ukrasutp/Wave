using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WaveApp.Properties;

namespace Logger
{
    /// <summary>
    /// Класс - регистратор (предназначен для регистрации событий SCADA)
    /// </summary>
    public static class Logger
    {
        private static System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog(System.Windows.Forms.Application.ExecutablePath, System.Net.Dns.GetHostName(), "");

        /// <summary>
        /// Добавление исключительной ситуации в указанный лог-файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="exc">Исключительная ситуация</param>
        public static void WriteException(String fileName, Exception exc)
        {
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Length >= 10485760)//10 Mb
                    lock (fileName)
                        fi.Delete();
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                lock (fileName)
                {
                    string messageText = exc.Message;
                    Exception innerException = exc.InnerException;
                    while (innerException != null)
                    {
                        messageText += "\n" + innerException.Message;
                        innerException = innerException.InnerException;
                    }
                    messageText += "\n-->" + exc.StackTrace;
                    byte[] text = new UTF8Encoding(true).GetBytes("[" + DateTime.Now + "]: " + messageText + Environment.NewLine);
                    fs.Write(text, 0, text.Length);
                }
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// Добавление записи в указанный лог-файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="messageText">Текст записи</param>
        public static void WriteString(String fileName, string messageText)
        {
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Length >= 10485760)//10 Mb
                    lock (fileName)
                        fi.Delete();
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                lock (fileName)
                {
                    byte[] text = new UTF8Encoding(true).GetBytes("[" + DateTime.Now + "]: " + messageText + Environment.NewLine);
                    fs.Write(text, 0, text.Length);
                }
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// Добавление исключительной ситуации в лог-файл по-умолчанию
        /// </summary>
        /// <param name="exc">Исключительная ситуация</param>
        public static void WriteException(Exception exc)
        {
            String fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName + ".log";
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Length >= 10485760)//10 Mb
                    lock (fileName)
                        fi.Delete();
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                lock (fileName)
                {
                    string messageText = exc.Message;
                    Exception innerException = exc.InnerException;
                    while (innerException != null)
                    {
                        messageText += "\n" + innerException.Message;
                        innerException = innerException.InnerException;
                    }
                    messageText += "\n-->" + exc.StackTrace;
                    byte[] text = new UTF8Encoding(true).GetBytes("[" + DateTime.Now + "]: " + messageText + Environment.NewLine);
                    fs.Write(text, 0, text.Length);
                }
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// Добавление записи в лог-файл по-умолчанию
        /// </summary>
        /// <param name="messageText">Текст записи</param>
        public static void WriteString(string messageText)
        {
            String fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName + ".log";
            if (File.Exists(fileName))
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Length >= 10485760)//10 Mb
                    lock (fileName)
                        fi.Delete();
            }
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                lock (fileName)
                {
                    byte[] text = new UTF8Encoding(true).GetBytes("[" + DateTime.Now + "]: " + messageText + Environment.NewLine);
                    fs.Write(text, 0, text.Length);
                }
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// Добавление записи о исключительной ситуации в системный журнал
        /// </summary>
        /// <param name="source">Источник, у которого возникла исключительная ситуация</param>
        /// <param name="exc">Исключительная ситуация</param>
        /// <param name="eventType">Тип исключительной ситуации</param>
        public static void WriteException(string source, Exception exc, System.Diagnostics.EventLogEntryType eventType)
        {
            if (source != null && exc != null)
            {
                try
                {
                    eventLog.Source = source;
                    string messageText = exc.Message;
                    Exception innerException = exc.InnerException;
                    while (innerException != null)
                    {
                        messageText += "\n" + innerException.Message;
                        innerException = innerException.InnerException;
                    }
                    messageText += "\n" + exc.StackTrace;
                    eventLog.WriteEntry(messageText, eventType);
                }
                catch { }
            }
        }

        /// <summary>
        /// Добавление записи в системный журнал
        /// </summary>
        /// <param name="source">Источник, который добавляет запись</param>
        /// <param name="message">Сообщение</param>
        /// <param name="eventType">Тип сообщения</param>
        public static void WriteString(string source, string message, System.Diagnostics.EventLogEntryType eventType)
        {
            if (source != null && message != null)
            {
                try
                {
                    eventLog.Source = source;
                    eventLog.WriteEntry(message, eventType);
                }
                catch { }
            }
        }
    }
}
