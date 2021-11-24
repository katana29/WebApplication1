using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Hubs
{
    public class PolaganjeHub : Hub
    {
        public static void PolaganjeBroadcasr(List<Polaganje> polaganja) 
        {
            IHubContext contex = GlobalHost.ConnectionManager.GetHubContext<PolaganjeHub>();
            contex.Clients.All.getUpdateData(polaganja);
        }
    }
}