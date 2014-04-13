$(function ()
{
	// this variable
	window.messageHub = $.connection.messageHub;

	messageHub.client.quoteUpdate = function (quoteData)
	{
		console.log(quoteData);
	};

	// Start the connection.
	$.connection.hub
	.start()
	.done(function ()
	{
		$('#StartStream').click(function ()
		{
			// Call the Send method on the messageHub. 
			messageHub.server.startQuoteStream();
		});

		$('#StopStream').click(function ()
		{
			// Call the Clear method on the messageHub. 
			messageHub.server.stopQuoteStream();
		});
	});
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value)
{
	var encodedValue = $('<div />').text(value).html();
	return encodedValue;
}