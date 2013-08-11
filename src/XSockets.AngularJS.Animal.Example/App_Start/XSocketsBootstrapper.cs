using System.Web;
using XSockets.Core.Common.Socket;

[assembly: PreApplicationStartMethod(typeof(XSockets.AngularJS.Animal.Example.App_Start.XSocketsBootstrap), "Start")]

namespace XSockets.AngularJS.Animal.Example.App_Start
{
    public static class XSocketsBootstrap
    {
        private static IXBaseServerContainer wss;
        public static void Start()
        {
            wss = XSockets.Plugin.Framework.Composable.GetExport<IXBaseServerContainer>();
            wss.StartServers();
        }        
    }
}