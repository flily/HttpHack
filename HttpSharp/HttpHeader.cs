using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpSharp
{
	/// <summary>
	/// Base class of all HTTP headers
	/// </summary>
    public abstract class HttpHeader
    {
		private string headerString;
		private string value;
		private Newline newline;
		
		public HttpHeader(string headerString, string value, NewlineType newline)
    }
}
