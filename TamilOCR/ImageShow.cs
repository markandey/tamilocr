using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for ImageShow.
	/// </summary>
	public class ImageShow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btNext;
		private System.Windows.Forms.Button button1;
		private ArrayList arr;
		private int count=0;
		private System.Windows.Forms.Button btPrev;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.SaveFileDialog SFD;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button BtRecognize;
		private MyOCR mocr;
		private System.Windows.Forms.Label lblLineCount;
		private System.Windows.Forms.Label lblWordCount;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImageShow(ArrayList Im,MyOCR ocr)
		{
			//
			// Required for Windows Form Designer support
			//
			arr=Im;
			count=0;
			InitializeComponent();		
			mocr=ocr;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btNext = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btPrev = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.SFD = new System.Windows.Forms.SaveFileDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.BtRecognize = new System.Windows.Forms.Button();
			this.lblLineCount = new System.Windows.Forms.Label();
			this.lblWordCount = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// btNext
			// 
			this.btNext.Location = new System.Drawing.Point(104, 120);
			this.btNext.Name = "btNext";
			this.btNext.TabIndex = 1;
			this.btNext.Text = "Next";
			this.btNext.Click += new System.EventHandler(this.btOK_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(208, 120);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Dispose";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btPrev
			// 
			this.btPrev.Location = new System.Drawing.Point(8, 120);
			this.btPrev.Name = "btPrev";
			this.btPrev.TabIndex = 3;
			this.btPrev.Text = "Previous";
			this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(8, 152);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(280, 23);
			this.btSave.TabIndex = 4;
			this.btSave.Text = "Save All To File";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// SFD
			// 
			this.SFD.FileName = "Gli";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Arial Unicode MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(200, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 44);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "";
			// 
			// BtRecognize
			// 
			this.BtRecognize.Location = new System.Drawing.Point(112, 32);
			this.BtRecognize.Name = "BtRecognize";
			this.BtRecognize.TabIndex = 6;
			this.BtRecognize.Text = "----->";
			this.BtRecognize.Click += new System.EventHandler(this.BtRecognize_Click);
			// 
			// lblLineCount
			// 
			this.lblLineCount.Location = new System.Drawing.Point(16, 80);
			this.lblLineCount.Name = "lblLineCount";
			this.lblLineCount.Size = new System.Drawing.Size(40, 23);
			this.lblLineCount.TabIndex = 7;
			// 
			// lblWordCount
			// 
			this.lblWordCount.Location = new System.Drawing.Point(72, 80);
			this.lblWordCount.Name = "lblWordCount";
			this.lblWordCount.Size = new System.Drawing.Size(32, 23);
			this.lblWordCount.TabIndex = 8;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(184, 88);
			this.button2.Name = "button2";
			this.button2.TabIndex = 9;
			this.button2.Text = "Blur";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// ImageShow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 182);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.lblWordCount,
																		  this.lblLineCount,
																		  this.BtRecognize,
																		  this.textBox1,
																		  this.btSave,
																		  this.btPrev,
																		  this.button1,
																		  this.btNext,
																		  this.pictureBox1});
			this.Name = "ImageShow";
			this.Text = "ImageShow";
			this.Load += new System.EventHandler(this.ImageShow_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void ImageShow_Load(object sender, System.EventArgs e)
		{
			if((arr[0].GetType()) == typeof(Bitmap))
			{
				this.pictureBox1.Image=(Bitmap)arr[0];
			}
			else if((arr[0].GetType()) == typeof(Segment))
			{
				Segment s=(Segment)arr[0];
				this.pictureBox1.Image=s.bmpGlimph;
				this.lblLineCount.Text=s.lLineCount.ToString();
				this.lblWordCount.Text=s.lWordCount.ToString();
			}
			/*
			if((arr[0].GetType()) == typeof(Bitmap))
			{
				this.pictureBox1.Image=(Bitmap)arr[0];
			}
			else if((arr[0].GetType()) == typeof(Segment))
			{
				Segment s=(Segment)arr[0];
				this.pictureBox1.Image=s.bmpGlimph;
			}
			 */

		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(count<arr.Count-1)
			{
				count++;

				//this.pictureBox1.Image=(Bitmap)arr[count];
				if((arr[0].GetType()) == typeof(Bitmap))
				{
					this.pictureBox1.Image=(Bitmap)arr[count];
				}
				else if((arr[0].GetType()) == typeof(Segment))
				{
					Segment s=(Segment)arr[count];
					this.pictureBox1.Image=s.bmpGlimph;
					this.lblLineCount.Text=s.lLineCount.ToString();
					this.lblWordCount.Text=s.lWordCount.ToString();
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Dispose(true);
		}

		private void btPrev_Click(object sender, System.EventArgs e)
		{
			if(count>0)
			{
				count--;
				//this.pictureBox1.Image=(Bitmap)arr[count];
				if((arr[0].GetType()) == typeof(Bitmap))
				{
					this.pictureBox1.Image=(Bitmap)arr[count];
				}
				else if((arr[0].GetType()) == typeof(Segment))
				{
					Segment s=(Segment)arr[count];
					this.pictureBox1.Image=s.bmpGlimph;
					this.lblLineCount.Text=s.lLineCount.ToString();
					this.lblWordCount.Text=s.lWordCount.ToString();
				}
			}
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			SFD.ShowDialog();
			String str=SFD.FileName;
			if(str!="")
			{
				int c=arr.Count;
				for(int i=0;i<c;i++)
				{
					try
					{
						Bitmap b=(Bitmap)arr[i];
						b.Save(str+i.ToString()+".tif",System.Drawing.Imaging.ImageFormat.Tiff);
					}
					catch(Exception exp)
					{
						MessageBox.Show(exp.Message);
					}
	
				}
			}
		}
		private void BtRecognize_Click(object sender, System.EventArgs e)
		{
			/*if((arr[0].GetType()) == typeof(Bitmap))
			{
				//this.pictureBox1.Image=(Bitmap)arr[0];
				this.textBox1.Text= this.mocr.RecognizeBitmap((Bitmap)arr[count]);
			}
			else if((arr[0].GetType()) == typeof(Segment))
			{
				Segment s=(Segment)arr[count];
				this.textBox1.Text= this.mocr.RecognizeBitmap(s.bmpGlimph);
			}*/
			
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Bitmap b=new Bitmap(pictureBox1.Image);



		}

		
	}
}
