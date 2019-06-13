using System;
using System.Reflection;

namespace Solid.OpenClosed
{
    public interface IFactory<T, U>
    {
        IDialog CreateDialog(T alertType, U severity);
    }

    public class DialogFactory : IFactory<AlertType, Severity>
    {
        public IDialog CreateDialog(AlertType alertType, Severity severity)
        {
            if (!Enum.IsDefined(typeof(AlertType), alertType))
            {
                throw new NotImplementedException();
            }

            if (!Enum.IsDefined(typeof(Severity), severity))
            {
                throw new NotImplementedException();
            }
            string className = DialogMapper.GetMapping(alertType, severity);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type dialogType = assembly.GetType(className);

            IDialog dialog = (IDialog)Activator.CreateInstance(dialogType);
            return dialog;
        }
    }

    public class DialogMapper
    {
        public static string GetMapping(AlertType alertType, Severity severity)
        {
            if (severity == Severity.High && alertType == AlertType.Error)
            {
                return typeof(MessageBox).FullName;
            }
            if (severity == Severity.High && alertType == AlertType.Warning)
            {
                return typeof(BlinkingDialog).FullName;
            }
            return typeof(NormalDialog).FullName;
        }
    }
}
