using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRExample.Hubs
{
	public class Quote
	{
		public double? LastPrice { get; set; }
		public double? Bid { get; set; }
		public double? Ask { get; set; }
		public DateTime? LastTradeTime{ get; set; }
	}

	public class MessageHub : Hub
	{
		private static Timer _QuoteTimer;

		public void Send(string message)
		{
			// Call the addNewMessageToPage method to update clients.
			Clients.All.addNewMessageToPage(message);
		}

		public void StartQuoteStream()
		{
			_QuoteTimer = new Timer(400);
			_QuoteTimer.Elapsed += new ElapsedEventHandler(_QuoteUpdate);
			_QuoteTimer.Enabled = true;
			_QuoteTimer.Start();
		}

		public void StopQuoteStream()
		{
			_QuoteTimer.Enabled = false;
			_QuoteTimer.Stop();
		}

		private void _QuoteUpdate(object sender, ElapsedEventArgs e)
		{
			Clients.All.quoteUpdate(
				new Quote()
				{ 
					Bid = new Random((int)DateTime.Now.Ticks).NextDouble() * 50,
					Ask = new Random((int)DateTime.Now.Ticks).NextDouble() * 50,
					LastPrice = new Random((int)DateTime.Now.Ticks).NextDouble() * 50,
					LastTradeTime = DateTime.Now
				}
			);	
		}
	}
}