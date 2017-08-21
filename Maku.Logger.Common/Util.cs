namespace Maku.Logger.Common
{
    public class Util
    {
        public static string GetLogTypeName(int id)
        {
            var logTypeName = string.Empty;

            switch (id)
            {
                case 1: logTypeName = "MESSAGE"; break;
                case 2: logTypeName = "WARNING"; break;
                case 3: logTypeName = "ERROR"; break;
            }

            return logTypeName;
        }
    }
}
