using System;
using System.Drawing;
using xpidea.neuro.net.backprop;
using System.Collections;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for TrainSample.
	/// this class is the wrapper class for the training samples
	/// 
	/// </summary>
	/// 
	public class TrainingSample
	{
		
		private string m_Char;
		private Bitmap m_Bmp;
		//public int Dx=24;
		//private int Dy=24;
		public static int Dx=10;
		public static int Dy=10;
		public string Char
		{
			
			get
			{
				return m_Char;
			}
			set
			{
				m_Char=value;
			}
		}
		public Bitmap Bmp
		{
			
			get
			{
				return m_Bmp;
			}
			set
			{
				m_Bmp=TrimBitmap(value);
			}
		}
		public TrainingSample(string c,Bitmap Bmp)
		{
			m_Char=c;
			m_Bmp=TrimBitmap(Bmp);
		}
		private void ShowNoise(Size sz, Graphics g,int noisePercent)
		{			
			int range =  sz.Height*sz.Width*noisePercent/200;			
			for (int i=0; i<range; i++)
			{
				int x = (int)BackPropagationRPROPNetwork.Random(0,sz.Width);
				int y = (int)BackPropagationRPROPNetwork.Random(0,sz.Height);
				Rectangle r = new Rectangle(x,y,0,0);				
				r.Inflate(1,1);
				Brush b;
				if ((BackPropagationRPROPNetwork.Random(0,100))>80) //80% is black noise, 20% is white noise
					b = new SolidBrush(Color.White);
				else
					b = new SolidBrush(Color.Black);

				g.FillRectangle(b,r);
				b.Dispose();				
			}
			
		}
		private double MaxOf(double[] src)
		{
			double res=double.NegativeInfinity;
			foreach (double d in src)
				if (d>res) res = d;
			return res;
		}
		private double[] Scale(double[] src)
		{
			double max = MaxOf(src);
			if (max!=0)
			{
				for(int i=0; i<src.Length; i++)
					src[i] = src[i]/max;
			}
			return src;					
		}
		public double[] GetBitMatrix(int Dimension,int NoisePercent)
		{
			
			double[] result = new double[Dimension*Dimension];
			/*Bitmap TestBmp = new Bitmap(32,32);
			Graphics gr = Graphics.FromImage(TestBmp);
			Size size =Size.Round(gr.MeasureString(m_Char,m_Font));
			
			Bitmap aSrc = new Bitmap(size.Width,size.Height);
			Graphics bmp = Graphics.FromImage(aSrc);
			bmp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			bmp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			bmp.Clear(Color.White);
			bmp.DrawString(m_Char,m_Font,new SolidBrush(Color.Black),new Point(0,0),new StringFormat());
			ShowNoise(size,bmp,NoisePercent);*/
			Bitmap aSrc=GetBitmap();
			double xStep = (double)aSrc.Width/(double)Dimension;
			double yStep = (double)aSrc.Height/(double)Dimension;
			for (int i=0; i<aSrc.Width; i++)
				for (int j=0;j<aSrc.Height;j++)
				{
					int x = (int)((i/xStep));
					int y = (int)(j/yStep);
					Color c = aSrc.GetPixel(i,j);
					if(c.GetBrightness()<0.5)
					{
						result[y*x+y]+=0;//Math.Sqrt(c.R*c.R+c.B*c.B+c.G*c.G);
					}
					else
					{
						result[y*x+y]+=255;
					}
				}
			return  Scale(result);
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
					
				}
				right=i+4;
			Bitmap Ret=new Bitmap(right-left,bottom-top);
			Graphics Gr=Graphics.FromImage(Ret);
			Gr.Clear(Color.White);
			Rectangle scrRt=new Rectangle(left,top,right-left,bottom-top);
			Rectangle destRt=new Rectangle(0,0,right-left,bottom-top);
			//Point p=new Point(0,0);
			Gr.DrawImage(b,destRt,scrRt,GraphicsUnit.Pixel);
			return Ret;
				
		}
		public Bitmap GetBitmap()
		{
			#region Comment
			/*Bitmap TestBmp = new Bitmap(32,32);
			Graphics gr = Graphics.FromImage(TestBmp);
			Size size =Size.Round(gr.MeasureString(m_Char,m_Font));
			
			Bitmap aSrc = new Bitmap(size.Width,size.Height);
			Graphics bmp = Graphics.FromImage(aSrc);
			bmp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			bmp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			bmp.Clear(Color.White);
			bmp.DrawString(m_Char,m_Font,new SolidBrush(Color.Black),new Point(0,0),new StringFormat());
			ShowNoise(size,bmp,NoisePercent);*/
						
			//Bitmap res=new Bitmap(Dimension,Dimension);
			//Graphics bmp=Graphics.FromImage(res);
			
			//bmp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			//bmp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			//bmp.Clear(Color.White);
			//bmp.DrawString(m_Char,m_Font,new SolidBrush(Color.Black),new Point(0,0),new StringFormat());
			//ShowNoise(aSrc.Size,bmp,NoisePercent);
			#endregion
			return this.m_Bmp;
		}

	}
}
