using System;
using System.Drawing;

namespace TamilOCR
{
	/// <summary>
	/// Segment data structure that represents the each smallest segments unit from given Bitmap
	/// it also has the line count as well as word count 
	/// </summary>
	public class Segment
	{
		public Bitmap bmpGlimph;
		public long lWordCount;
		public long lLineCount;
		public Segment(Bitmap Glimph,long WordCount,long LineCount)
		{
			bmpGlimph=Glimph;
			lWordCount=WordCount;
			lLineCount=LineCount;
		}
	}
}
