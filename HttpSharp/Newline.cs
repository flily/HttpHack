using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HttpSharp
{
	/// <summary>
	/// Newline types
	/// </summary>
	public enum NewlineType
	{
		/// <summary>
		/// Carriage Return, '\r', Mac OS style, not used in Mac OS X.
		/// </summary>
		CR,
		/// <summary>
		/// Line Feed, '\n', Unix style, used in Unix and Unix-like systems.
		/// </summary>
		LF,
		/// <summary>
		/// '\r\n', Windows style, used in Windows, DOS, OS/2, Symbian OS etc.
		/// </summary>
		CRLF,
		/// <summary>
		/// Other type of newline string, can any string, for invalid HTTP request.
		/// </summary>
		Other
	}

	/// <summary>
	/// Instance of newline string.
	/// </summary>
	public class Newline
	{
		private NewlineType type;
		private string content;

		/// <summary>
		/// Create a new instance of newline string.
		/// </summary>
		/// <param name="type">Type of newline string.</param>
		public Newline(NewlineType type)
		{
			switch (type)
			{
				case NewlineType.CR:
					content = "\r";
					break;
				case NewlineType.LF:
					content = "\n";
					break;
				case NewlineType.CRLF:
					content = "\r\n";
					break;
				default:
					throw new ArgumentException(
						String.Format("Got unknown NewlineType '{0}'", type)
					);
			}
		}

		/// <summary>
		/// Create a new instance of newline string.
		/// </summary>
		/// <param name="newline">Value of newline string.</param>
		public Newline(string newline)
		{
			this.content = newline;
			switch (newline)
			{
				case "\r":
					type = NewlineType.CR;
					break;
				case "\n":
					type = NewlineType.LF;
					break;
				case "\r\n":
					type = NewlineType.CRLF;
					break;
				default:
					type = NewlineType.Other;
					break;
			}
		}

		/// <summary>
		/// Newline type of newline string.
		/// </summary>
		public NewlineType Type
		{
			get { return type; }
		}

		/// <summary>
		/// Content of newline string.
		/// </summary>
		public string Content
		{
			get { return content; }
		}

		/// <summary>
		/// Content of newline string.
		/// </summary>
		/// <returns>return content of newline string.</returns>
		public override string ToString()
		{
			return content;
		}

		/// <summary>
		/// Instance of CR newline string, Mac OS style.
		/// </summary>
		public static Newline CR = new Newline(NewlineType.CR);

		/// <summary>
		/// Instance of LF newline string, Unix style.
		/// </summary>
		public static Newline LF = new Newline(NewlineType.LF);

		/// <summary>
		/// Instance of CRLF newline string, Windows style.
		/// </summary>
		public static Newline CRLF = new Newline(NewlineType.CRLF);

		/// <summary>
		/// Get an instance of specified newline type.
		/// </summary>
		/// <param name="type">Type of newline string.</param>
		/// <returns>Return class static instance of specified newline type.</returns>
		public static Newline GetNewline(NewlineType type)
		{
			switch (type)
			{
				case NewlineType.CR: return CR;
				case NewlineType.LF: return LF;
				case NewlineType.CRLF: return CRLF;
				default:
					return new Newline(type);
			}
		}
	}
}
