using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for ChangeImageDlg.
	/// </summary>
	public class ChangeImageDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.PictureBox pbSelectedImage;
		private MainFrm ParentForm;
		int SegmentIndex;
		private TrainingSample TS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.Windows.Forms.TextBox txtStr;
		private System.Windows.Forms.RadioButton rbSeg;
		private System.Windows.Forms.RadioButton rbFile;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btNext;
		private System.Windows.Forms.Button btPrev;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.Button btCancle;
		private System.ComponentModel.IContainer components;

		public ChangeImageDlg(MainFrm frm,TrainingSample ts)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			ParentForm=frm;
			TS=ts;
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
			this.components = new System.ComponentModel.Container();
			this.pbSelectedImage = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btNext = new System.Windows.Forms.Button();
			this.btPrev = new System.Windows.Forms.Button();
			this.btBrowse = new System.Windows.Forms.Button();
			this.rbFile = new System.Windows.Forms.RadioButton();
			this.rbSeg = new System.Windows.Forms.RadioButton();
			this.btOK = new System.Windows.Forms.Button();
			this.btCancle = new System.Windows.Forms.Button();
			this.txtStr = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbSelectedImage
			// 
			this.pbSelectedImage.BackColor = System.Drawing.Color.White;
			this.pbSelectedImage.Location = new System.Drawing.Point(168, 32);
			this.pbSelectedImage.Name = "pbSelectedImage";
			this.pbSelectedImage.Size = new System.Drawing.Size(104, 72);
			this.pbSelectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbSelectedImage.TabIndex = 0;
			this.pbSelectedImage.TabStop = false;
			this.pbSelectedImage.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btNext,
																					this.btPrev,
																					this.btBrowse,
																					this.rbFile,
																					this.rbSeg});
			this.groupBox1.Location = new System.Drawing.Point(8, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 104);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Image";
			// 
			// btNext
			// 
			this.btNext.Location = new System.Drawing.Point(216, 24);
			this.btNext.Name = "btNext";
			this.btNext.Size = new System.Drawing.Size(32, 23);
			this.btNext.TabIndex = 4;
			this.btNext.Text = ">>";
			this.btNext.Click += new System.EventHandler(this.btNext_Click);
			// 
			// btPrev
			// 
			this.btPrev.Location = new System.Drawing.Point(173, 24);
			this.btPrev.Name = "btPrev";
			this.btPrev.Size = new System.Drawing.Size(32, 23);
			this.btPrev.TabIndex = 3;
			this.btPrev.Text = "<<";
			this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
			// 
			// btBrowse
			// 
			this.btBrowse.Location = new System.Drawing.Point(173, 64);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.TabIndex = 2;
			this.btBrowse.Text = "Browse";
			this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
			// 
			// rbFile
			// 
			this.rbFile.Location = new System.Drawing.Point(16, 64);
			this.rbFile.Name = "rbFile";
			this.rbFile.Size = new System.Drawing.Size(88, 24);
			this.rbFile.TabIndex = 1;
			this.rbFile.Text = "From File";
			// 
			// rbSeg
			// 
			this.rbSeg.Checked = true;
			this.rbSeg.Location = new System.Drawing.Point(16, 24);
			this.rbSeg.Name = "rbSeg";
			this.rbSeg.TabIndex = 0;
			this.rbSeg.TabStop = true;
			this.rbSeg.Text = "From Segment";
			// 
			// btOK
			// 
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(8, 208);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(72, 24);
			this.btOK.TabIndex = 2;
			this.btOK.Text = "OK";
			// 
			// btCancle
			// 
			this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancle.Location = new System.Drawing.Point(240, 208);
			this.btCancle.Name = "btCancle";
			this.btCancle.Size = new System.Drawing.Size(88, 24);
			this.btCancle.TabIndex = 3;
			this.btCancle.Text = "Cancel";
			// 
			// txtStr
			// 
			this.txtStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStr.Location = new System.Drawing.Point(16, 32);
			this.txtStr.Name = "txtStr";
			this.txtStr.ReadOnly = true;
			this.txtStr.Size = new System.Drawing.Size(72, 38);
			this.txtStr.TabIndex = 4;
			this.txtStr.Text = "";
			this.txtStr.TextChanged += new System.EventHandler(this.txtStr_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Select Image for following string";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ChangeImageDlg
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancle;
			this.ClientSize = new System.Drawing.Size(336, 238);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.txtStr,
																		  this.btCancle,
																		  this.btOK,
																		  this.groupBox1,
																		  this.pbSelectedImage});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeImageDlg";
			this.Text = "Choose Image";
			this.Load += new System.EventHandler(this.ChangeImageDlg_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ChangeImageDlg_Load(object sender, System.EventArgs e)
		{
			this.txtStr.Text=this.TS.Char;
			this.pbSelectedImage.Image=this.TS.Bmp;
			if(ParentForm.ImageSegments==null)
			{
				this.rbSeg.Enabled=false;
				this.rbFile.Checked=true;
			}
			else
			{
				this.SegmentIndex=ParentForm.SegmentIndex;
				SetSegmentSelection();
			}
		}
		void SetSegmentSelection()
		{
			Segment s=(Segment)ParentForm.ImageSegments[SegmentIndex];
			this.pbSelectedImage.Image=s.bmpGlimph;
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.btBrowse.Enabled=this.rbFile.Checked;
			this.btPrev.Enabled=this.rbSeg.Checked;
			this.btNext.Enabled=this.rbSeg.Checked;
		}

		private void txtStr_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btPrev_Click(object sender, System.EventArgs e)
		{
			
			if(SegmentIndex>0)
			{
				SegmentIndex--;
				SetSegmentSelection();
			}
		}

		private void btNext_Click(object sender, System.EventArgs e)
		{
			
			if(SegmentIndex<(ParentForm.ImageSegments.Count-1))
			{
				SegmentIndex++;
				SetSegmentSelection();
			}
		}

		private void btBrowse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd=new OpenFileDialog();
			ofd.Filter="Image Files(*.BMP;*.JPG;*.GIF;*.tif)|*.BMP;*.JPG;*.GIF;*.tif|All files (*.*)|*.*";
			if(ofd.ShowDialog()==DialogResult.OK)
			{
				this.pbSelectedImage.Image=Image.FromFile(ofd.FileName);
			}
		}
	}
}
