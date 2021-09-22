
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace Endless_Of_Iscanet_Ir.Infrastructrues
{
    public class CultureHelper
    {
        protected HttpSessionState session;
        public CultureHelper(HttpSessionState httpsessionstate)
        {
            session = httpsessionstate;
        }
        public static int CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name=="fa-IR")
                {
                    return 0;
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value==0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
                }
                else if (value==1)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                }
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }
        }
    }
}