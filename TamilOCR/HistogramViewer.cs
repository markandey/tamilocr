using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for HistogramViewer.
	/// </summary>
	public class HistogramViewer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox Image;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HistogramViewer(Bitmap Bmp,long[] HH,long[] VH,int HistoWidth)
		{
			InitializeComponent();
			this.Image.Image=this.GetHistogram(Bmp,HH,VH,HistoWidth);

			
		}
		Bitmap GetHistogram(Bitmap Bmp,long[] HorizontalHistogram,long[] VerticalHistogram,int HistoWidth)
		{
			Bitmap HG=new Bitmap(Bmp.Width+HistoWidth,Bmp.Height+HistoWidth);
			Graphics G=Graphics.FromImage(HG);
			G.Clear(Color.White);
			G.DrawImage(Bmp,0,0);
			G.DrawRectangle(new Pen(Color.Blue,2),0,0,Bmp.Width,Bmp.Height);
			if(VerticalHistogram!=null)
			{
				long Max=VerticalHistogram[0];
				for(int i=1;i<VerticalHistogram.Length;i++)
				{
					if(VerticalHistogram[i]>Max)
					{
						Max=VerticalHistogram[i];
					}
				}
				for(int i=0;i<VerticalHistogram.Length;i++)
				{
					float Value=(VerticalHistogram[i]*HistoWidth)/Max;
					//G.DrawLine(new Pen(Color.Red),Bmp.Width,i,Value+Bmp.Width,i);
					G.DrawLine(new Pen(Color.Red),i,Bmp.Height,i,Value+Bmp.Height);
				}
			}
			if(HorizontalHistogram!=null)
			{
				long Max=HorizontalHistogram[0];
				for(int i=1;i<HorizontalHistogram.Length;i++)
				{
					if(HorizontalHistogram[i]>Max)
					{
						Max=HorizontalHistogram[i];
					}
				}
				for(int i=0;i<HorizontalHistogram.Length;i++)
				{
					float Value=(HorizontalHistogram[i]*HistoWidth)/Max;
					G.DrawLine(new Pen(Color.Aqua),Bmp.Width,i,Value+Bmp.Width,i);					
				}
			}
			return HG;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Image = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// Image
			// 
			this.Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Image.Name = "Image";
			this.Image.Size = new System.Drawing.Size(304, 264);
			this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Image.TabIndex = 0;
			this.Image.TabStop = false;
			// 
			// HistogramViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 390);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Image});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HistogramViewer";
			this.Text = "HistogramViewer";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
