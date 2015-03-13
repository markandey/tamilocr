using System;
using System.Collections;
using xpidea.neuro.net.patterns;
using xpidea.neuro.net.backprop;
using xpidea.neuro.net;
using System.Drawing;
using System.Windows.Forms;


namespace TamilOCR
{
	/// <summary>
	/// Summary description for MyOCR.
	/// </summary>
	public class MyOCR
	{
		public OCRBackPropagationNetwork backpropNetwork;
		//PatternsCollection Patterns;
		//ArrayList m_Samples;
		int m_MatrixDim;
		private PatternsCollection CreateTrainingPatterns(TrainingSample[] Samples)
		{			 
			int count =Samples.Length;
			int MatrixDim=TrainingSample.Dx;
			PatternsCollection result = new PatternsCollection(count, MatrixDim * MatrixDim, count);
			for (int i= 0; i<count; i++)
			{
				double[] BitMatrix = ((TrainingSample)(Samples[i])).GetBitMatrix(MatrixDim,0);
				for (int j = 0; j<MatrixDim * MatrixDim; j++) 
					result[i].Input[j] = BitMatrix[j];
				result[i].Output[i] = 1;
				
			}
			return result;
		}
		public void InitializeNetwork(MainFrm owner,int Count)
		{
			int MatrixDim=TrainingSample.Dx;			
			/*int[] NL=new int[]{
								(MatrixDim * MatrixDim),
								(MatrixDim * MatrixDim + Count),
							     (MatrixDim * MatrixDim + Count)/2,
								 Count
							   };*/
			int[] NL=new int[]{
								  (MatrixDim * MatrixDim),
								  (MatrixDim * MatrixDim+Count),
								  (MatrixDim * MatrixDim+Count)/2,								  
								   Count
							  };
			this.backpropNetwork= new OCRBackPropagationNetwork(owner,1, NL);
			m_MatrixDim=MatrixDim;
		}
		public void Train(TrainingSample[] Samples)
		{
			backpropNetwork.Train(CreateTrainingPatterns(Samples));
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
		private double [] GetInput(Bitmap aSrc)
		{
			double[] result=new double[m_MatrixDim*m_MatrixDim];
			double xStep = (double)aSrc.Width/(double)m_MatrixDim;
			double yStep = (double)aSrc.Height/(double)m_MatrixDim;
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
		public int  RecognizeBitmap(Bitmap b)
		{
			double[] aInput = GetInput(TrimBitmap(b));
			for (int i = 0; i< backpropNetwork.InputNodesCount;i++)
				backpropNetwork.InputNode(i).Value = aInput[i];
			backpropNetwork.Run();
			return backpropNetwork.BestNodeIndex;			
		}
		public MyOCR()
		{
			
		}
	}
}
