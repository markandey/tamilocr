using System;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for SegmentIndicator.
	/// </summary>
	public class SegmentIndicator
	{
		/// <summary>
		/// indicates the strat of Segment
		/// </summary>
		public int start;
		/// <summary>
		/// indicatets the end of the Segment
		/// </summary>
		public int end;
		/// <summary>
		/// Constructs the indicator from given start and terminating value
		/// </summary>
		/// <param name="istart"> start value</param>
		/// <param name="iend">end value</param>
		public SegmentIndicator(int istart,int iend)
		{
			start=istart;
			end=iend;
		}
		/// <summary>
		/// constructs indicator from the zero start and end value 
		/// </summary>
		public SegmentIndicator()
		{
			start=0;
			end=0;
		}
	}
}
