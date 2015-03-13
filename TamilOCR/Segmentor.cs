using System;
using System.Drawing;
using System.Collections;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for Segmentor.
	/// sdfgjsd
	/// sdgsdf
	/// sdfg
	/// sdfgs
	/// dfgsdf
	/// gsdfg
	/// </summary>
	public class Segmentor
	{
		private Bitmap m_InputBitmap;
		public Segmentor(Bitmap InputBitmap)
		{
			m_InputBitmap=InputBitmap;
		}
		/// <summary>
		/// Creates the Vertical Histogram of given Bitmap
		/// </summary>
		/// <param name="bitmap"> The Bitmap of which you need the histogram</param>
		/// <returns>Array of size equal to the width of bitmap containg  the count of black pixels in each column</returns>
		public static long[] GetVerticalHistogram(Bitmap bitmap)
		{
			long[] Ret=new long[bitmap.Width];
			for(int i=0;i<bitmap.Width;i++)
			{
				int count=0;
				for(int j=0;j<bitmap.Height;j++)
				{
					Color pix=bitmap.GetPixel(i,j);
					if(pix.GetBrightness()<1)
					{
						count++;
					}
				}
				Ret[i]=count;
			}
			return Ret;
		}
		/// <summary>
		/// this function calculate the average Line height of given Document
		/// </summary>
		/// <param name="HorizontalHistogram">[in]Array of long which contains count of black pixel in each Horizontal scan line</param>
		/// <param name="NonKernedLines">[Out] This Array will be initialized with Non Kernedlines segments</param>
		/// <returns>return average Line height of given Document</returns>
		private double GetAvgLineHeight(long[] HorizontalHistogram,ref SegmentIndicator[] NonKernedLines)
		{
			bool Black=false;
			int PTop=0,PBottom=0;
			ArrayList LHeight=new ArrayList();
			ArrayList AlNonKernedLines=new ArrayList();
			if(HorizontalHistogram[0]>0)
			{
				Black=true;
				PTop=0;
			}			
			for(int i=1;i<HorizontalHistogram.Length;i++)
			{
				if(Black==false && HorizontalHistogram[i]>0)
				{
					PTop=i-1;
					Black=true;
				}
				if(Black==true && HorizontalHistogram[i]==0)
				{
					Black=false;
					PBottom=i;
					SegmentIndicator si=new SegmentIndicator(PTop,PBottom);
					AlNonKernedLines.Add(si);
					int Height=PBottom-PTop;
					LHeight.Add(Height);
					//PTop=PBottom+1;
				}
			}
			NonKernedLines =new SegmentIndicator[AlNonKernedLines.Count];
			AlNonKernedLines.CopyTo(NonKernedLines);
			double dbSum=0;
			for(int i=0;i<LHeight.Count;i++)
			{
				dbSum+=(double)((int)LHeight[i]);
			}
			if(LHeight.Count==0)
			{
				return (double)0;
			}
			else
			{
				return dbSum/LHeight.Count;
			}
			
		}
		/// <summary>
		/// Creates the Horizontal Histogram of given Bitmap
		/// </summary>
		/// <param name="bitmap"> The Bitmap of which you need the histogram</param>
		/// <returns>Array of size equal to the Hieght of bitmap containg  the count of black pixels in each row</returns>
		public static long[] GetHorizontalHistogram(Bitmap bitmap)
		{
			long[] Ret=new long[bitmap.Height];
			for(int j=0;j<bitmap.Height;j++)
			{
				int count=0;
				for(int i=0;i<bitmap.Width;i++)
				{
					Color pix=bitmap.GetPixel(i,j);
					byte Alpha=pix.A;
					byte R=pix.R;
					byte G=pix.G;
					byte B=pix.B;
					byte color=(byte)(Alpha*G*R*B);
					if(color==0)
					{
						count++;
					}
				}
				Ret[j]=count;
			}
			return Ret;
		}
		public double GetAvgCharacterWidth(long[] VerticalHistogram,ref SegmentIndicator[] Chars)
		{
			bool Black=false;
			int PLeft=0,PRight=0;
			ArrayList alWidth=new ArrayList();
			ArrayList alChars=new ArrayList();//Chars means each unique letters
			if(VerticalHistogram[0]>0)
			{
				Black=true;
				PLeft=0;
			}			
			for(int j=1;j<VerticalHistogram.Length;j++)
			{
				if(Black==false && VerticalHistogram[j]>0)
				{
					PLeft=j-1;
					Black=true;
				}
				if(Black==true && VerticalHistogram[j]==0)
				{
					Black=false;
					PRight=j;
					SegmentIndicator si=new SegmentIndicator(PLeft,PRight);
					alChars.Add(si);
					int Width=PRight-PLeft;
					alWidth.Add(Width);					
				}
			}
			Chars =new SegmentIndicator[alChars.Count];
			alChars.CopyTo(Chars);
			double dbSum=0;
			for(int i=0;i<alWidth.Count;i++)
			{
				dbSum+=(double)((int)alWidth[i]);
			}
			if(alWidth.Count==0)
			{
				return (double)0;
			}
			else
			{
				return dbSum/alWidth.Count;
			}
			
		}
		/// <summary>
		/// Splits the lines in two lines if their height is grater than 1.6 times average line height else return the same LineIndicator
		/// </summary>
		/// <param name="HorizontalHisto">[in]Array of long which contains count of black pixel in each Horizontal scan line</param>
		/// <param name="AvgLineHeight">[in]AvgLineHeight of Lines</param>
		/// <param name="LineIndicator">[in]LineIndicator to split</param>
		/// <param name="outLineIndicators">[out]SplitedIndicators</param>
		private void SplitKernedLines(long[] HorizontalHisto,double AvgLineHeight,SegmentIndicator LineIndicator,ArrayList outLineIndicators)
		{
			
			double height=(double)(LineIndicator.end-LineIndicator.start);
			if(height>1.6*AvgLineHeight)
			{
				int offset=(int)(AvgLineHeight*0.25);
				if(offset<2)
				{
					offset=2;
				}
				int minIndex=LineIndicator.start+offset;
				int maxIndex=LineIndicator.end-offset;
				int minCount=(int)HorizontalHisto[minIndex];
				for(int i=minIndex+1;i<maxIndex;i++)
				{
					if(minCount>HorizontalHisto[i])
					{
						minCount=(int)HorizontalHisto[i];
						minIndex=i;
					}
				}
				outLineIndicators.Add(new SegmentIndicator(LineIndicator.start,minIndex));
				outLineIndicators.Add(new SegmentIndicator(minIndex,LineIndicator.end));				
				
			}
			else
			{
				outLineIndicators.Add(LineIndicator);
			}
			return;
		}
		/// <summary>
		///This fuction segments the input bitmap into lines.
		/// </summary>
		/// <returns>Returns ArrayList of segmented Bitmaps</returns>
		public ArrayList GetLines()
		{
			//This fuction segments the input bitmap into lines.
			//1.count the of black pixels in each horizontal scan lines (i.e. call GetHorizontalHistogram())
			//2. if the count is zero this is seperation of lines.
			//3.For kerned text line the seperation of lines will be min black pixel count withing the range of 1.6*AverageLineHeight 
			//
			SegmentIndicator[] NonKernedLinesIndicator=null;
			ArrayList Lines=new ArrayList();
			long[] HorizontalHisto=Segmentor.GetHorizontalHistogram(this.m_InputBitmap);
			double AvgLineHeight=GetAvgLineHeight(HorizontalHisto,ref NonKernedLinesIndicator);
			//HistogramViewer HV=new HistogramViewer(this.m_InputBitmap,HorizontalHisto,null,100);
			//HV.ShowDialog();
			for(int i=0;i<NonKernedLinesIndicator.Length;i++)
			{
				double height=(double)(NonKernedLinesIndicator[i].end-NonKernedLinesIndicator[i].start);
				
				if(height>1.6*AvgLineHeight)
				{
					//two lines are joined together split them and the add
					SplitKernedLines(HorizontalHisto,AvgLineHeight,NonKernedLinesIndicator[i],Lines);
					
				}
				else if(height<0.5*AvgLineHeight)
				{
					//merg with next line;
					if(i<NonKernedLinesIndicator.Length)
					{
						NonKernedLinesIndicator[i+1].start=NonKernedLinesIndicator[i].start;
					}
				}
				else
				{
					Lines.Add(NonKernedLinesIndicator[i]);
				}
			}
			ArrayList Ret=new ArrayList();
			for(int i=0;i<Lines.Count;i++)
			{	
				SegmentIndicator LineIndicator=(SegmentIndicator)Lines[i];
				Bitmap b=new Bitmap(this.m_InputBitmap.Width+4,(int)(1.6*AvgLineHeight));
				Graphics g=Graphics.FromImage(b);
				g.Clear(Color.White);
				Rectangle srcRect=new Rectangle(0,LineIndicator.start,m_InputBitmap.Width,(LineIndicator.end-LineIndicator.start));
				Rectangle DestRect=new Rectangle(2,2,b.Width-4,b.Height-4);
				g.DrawImage(m_InputBitmap,DestRect,srcRect,GraphicsUnit.Pixel);
				Ret.Add(b);
			}
			return Ret;

		}
		double GetAvgLineSpacing(SegmentIndicator[] siLetters)
		{
			double Avg=0;
			for(int i=1;i<siLetters.Length;i++)
			{
				int iPrevCharEnd=siLetters[i-1].end;
				int iCurCharStart=siLetters[i].start;
				int Spacing=iCurCharStart-iPrevCharEnd;
				Avg+=Spacing;	
			}
			if(siLetters.Length>2)
			{
				Avg/=(siLetters.Length-1);
			}
			else
			{
				Avg=99999.9;//Any big value;
			}
			return Avg;
		}
		private ArrayList GetWordIndicator(Bitmap bmpLine)
		{
			SegmentIndicator[] siLetters=null;
			ArrayList alWords=new ArrayList();
			long[] lVerticalHisto=Segmentor.GetVerticalHistogram(bmpLine);
			double dblAvgCharWidth=this.GetAvgCharacterWidth(lVerticalHisto,ref siLetters);
			double dblAvgCharSpace=this.GetAvgLineSpacing(siLetters);
			//HistogramViewer HV=new HistogramViewer(bmpLine,null,lVerticalHisto,100);
			//HV.ShowDialog();
			//Group into the words
			int WordStart=siLetters[0].start;
			int WordEnd=siLetters[0].end;
			for(int i=1;i<siLetters.Length;i++)
			{
				int iPrevCharEnd=siLetters[i-1].end;
				int iCurCharStart=siLetters[i].start;
				int Spacing=iCurCharStart-iPrevCharEnd;

				if(((double)Spacing)>(dblAvgCharSpace*1.50))
				{
					WordEnd=siLetters[i-1].end;
					SegmentIndicator WordIndicator=new SegmentIndicator(WordStart,WordEnd);
					alWords.Add(WordIndicator);
					WordStart=siLetters[i].start;
				}
			}
			if(true)
			{
				WordEnd=siLetters[siLetters.Length-1].end;
				SegmentIndicator WordIndicator=new SegmentIndicator(WordStart,WordEnd);
				alWords.Add(WordIndicator);
			}

			return alWords;
		
		}
		public ArrayList GetWords(Bitmap bmpLine)
		{
			
			
			//Create the Bitmap of word;
			ArrayList alWords=GetWordIndicator(bmpLine);
			ArrayList alRet=new ArrayList();
			foreach(SegmentIndicator WordIndicator in alWords)
			{
				int WordWidth=(WordIndicator.end-WordIndicator.start);
				Bitmap b=new Bitmap(WordWidth+4,bmpLine.Height+4);
				Graphics g=Graphics.FromImage(b);
				g.Clear(Color.White);
				Rectangle srcRect=new Rectangle(WordIndicator.start,0,WordIndicator.end-WordIndicator.start,bmpLine.Height);
                Rectangle DestRect=new Rectangle(2,2,b.Width-4,b.Height-4);
				g.DrawImage(bmpLine,DestRect,srcRect,GraphicsUnit.Pixel);
				alRet.Add(b);
			}
				
			return alRet;

		}
		private void SplitCharacters(long[] VerticalHisto,double dblAvgCharWidth,SegmentIndicator CharIndicator,ArrayList outCharIndicators)
		{
			int offset=(int)(dblAvgCharWidth*0.5);
			if(offset<1)
			{
				offset=1;
			}
			int minIndex=CharIndicator.start+offset;
			int maxIndex=CharIndicator.end-offset;
			int minCount=(int)VerticalHisto[minIndex];
			for(int i=minIndex+1;i<maxIndex;i++)
			{
				if(minCount>VerticalHisto[i])
				{
					minCount=(int)VerticalHisto[i];
					minIndex=i;
				}
			}
			outCharIndicators.Add(new SegmentIndicator(CharIndicator.start,minIndex));
			outCharIndicators.Add(new SegmentIndicator(minIndex,CharIndicator.end));
			return;
		}
		private ArrayList GetSegmentIndicator(Bitmap bmpLine)
		{
			SegmentIndicator[] siLetters=null;
			ArrayList alCharacter=new ArrayList();
			long[] lVerticalHisto=Segmentor.GetVerticalHistogram(bmpLine);
			double dblAvgCharWidth=this.GetAvgCharacterWidth(lVerticalHisto,ref siLetters);
			//
			for(int i=0;i<siLetters.Length;i++)
			{
				double dblWidth=siLetters[i].end-siLetters[i].start;
				if(dblWidth>1.6*dblAvgCharWidth)
				{
					//two characters are joined together split them and the add
					SplitCharacters(lVerticalHisto,dblAvgCharWidth,siLetters[i],alCharacter);
					
				}
				else
				{
					alCharacter.Add(siLetters[i]);
				}
			}
			return alCharacter;			
		}
		public ArrayList GetSegments()
		{
						
			int iLineCount=0;
			int iWordCount=0;
			ArrayList alLines=this.GetLines();
			ArrayList alSegmentsToReturn=new ArrayList();
			foreach(Bitmap bmpLine in alLines)
			{
				ArrayList alSegmentIndicator=GetSegmentIndicator(bmpLine);
				ArrayList alWordIndicator=GetWordIndicator(bmpLine);
				int iseg=0;
				int iword=0;				
				foreach(SegmentIndicator Seg in alSegmentIndicator)
				{
					SegmentIndicator WordIndc=(SegmentIndicator)alWordIndicator[iword];
					if(Seg.start>WordIndc.end)
					{
						iWordCount++;
						iword++;
					}
					
					int CharWidth=(Seg.end-Seg.start);
					Bitmap b=new Bitmap(CharWidth+4,bmpLine.Height+4);
					Graphics g=Graphics.FromImage(b);
					g.Clear(Color.White);
					Rectangle srcRect=new Rectangle(Seg.start,0,Seg.end-Seg.start,bmpLine.Height);
					Rectangle DestRect=new Rectangle(2,2,b.Width-4,b.Height-4);
					g.DrawImage(bmpLine,DestRect,srcRect,GraphicsUnit.Pixel);
					Segment s=new Segment(this.TrimBitmap(b),iWordCount,iLineCount);
					alSegmentsToReturn.Add(s);
					iseg++;
				}
				iLineCount++;
			}
			return alSegmentsToReturn;

		}
		public Bitmap TrimBitmap(Bitmap b)
		{
			int top,left,right,bottom;
			int i=0,j=0,count=0;
			//int i=0,j=0,count=0;
			//[Get the glimph top]
			while(count==0)
			{
				for(i=0;i<b.Width;i++)
				{
					Color c=b.GetPixel(i,j);
					int val=c.A*c.B*c.G*c.R;
					if(val==0)
					{
						count++;
					}					
				}
				j++;
				if(j>=b.Height)
				{
					break;
				}
			}
			top=j-4;
			//[Get Glimph Bottom]
			i=0;j=b.Height;count=0;
			while(count==0)
			{
				j--;
				for(i=0;i<b.Width;i++)
				{
					Color c=b.GetPixel(i,j);
					int val=c.A*c.B*c.G*c.R;
					if(val==0)
					{
						count++;
					}					
				}
				if(j<=0)
				{
					break;
				}
						
			}
			bottom=j+4;
			//Get Glimph Left
			i=0;j=0;count=0;
			while(count==0)
			{
				for(j=0;j<b.Height;j++)
				{
					Color c=b.GetPixel(i,j);
					int val=c.A*c.B*c.G*c.R;
					if(val==0)
					{
						count++;
					}					
				}
				i++;
				if(i>=b.Width)
				{
					break;
				}
			}
			left=i-4;
			//Get Glimph Left
			i=b.Width;j=0;count=0;
			while(count==0)
			{
				i--;
				for(j=0;j<b.Height;j++)
				{
					Color c=b.GetPixel(i,j);
					int val=c.A*c.B*c.G*c.R;
					if(val==0)
					{
						count++;
					}					
				}
				if(i<=0)
				{
					break;
				}
					
			}
			Bitmap Ret=new Bitmap(20,20);
			Graphics Gr=Graphics.FromImage(Ret);
			Gr.Clear(Color.White);
			right=i+4;
			Rectangle scrRt=new Rectangle(left,top,right-left,bottom-top);
			Rectangle destRt=new Rectangle(0,0,20,20);
			//Point p=new Point(0,0);
			Gr.DrawImage(b,destRt,scrRt,GraphicsUnit.Pixel);
			
			return Ret;
				
		}
	}
}
