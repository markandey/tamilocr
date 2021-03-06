using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace TamilOCR
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainFrm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.ToolBar MainToolBar;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.TabPage TabTrnSam;
		private System.Windows.Forms.TabPage tabRText;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TabPage TabImage;
		private System.Windows.Forms.PictureBox pbImage;
		private System.Windows.Forms.HScrollBar hsView;
		private System.Windows.Forms.VScrollBar vsView;
		private System.Windows.Forms.Panel pView;
		private System.Drawing.Bitmap ImageBmp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btCngImage;
		private System.Windows.Forms.NumericUpDown angle;
		private System.Windows.Forms.Label label1;
		private TrainingSample[] TrainSamples;
		private System.Windows.Forms.ListBox TrainList;
		private MyOCR OCR;
		public ArrayList ImageSegments;
		public bool stop=false;
		public int SegmentIndex=0;
		#region StringList
		object[] StringList=new object[] {
											 "அ",
											 "ஆ",
											 "இ",
											 "ஈ",
											 "ஊ",
											 "எ",
											 "ஏ",
											 "ஐ",
											 "ஒ",
											 "ஓ",
											 "ஔ",
											 "க்",
											 "ங்",
											 "ச்",
											 "ஞ்",
											 "ட்",
											"ண்",
											 "த்",
											 "ழ்",
											 "ப்",
											 "ம்",
											 "ய்",
											 "ர்",
											 "ல்",
											 "வ்",
											 "ழ்",
											 "ள்",
											 "ற்",
											 "ன்",
											 "க",
											 "ங",
											 "ச",
											 "ஞ",
											 "ட",
											 "ண",
											 "த",
											 "ழ",
											 "ப",
											 "ம",
											 "ய",
											 "ர",
											 "ல",
											 "வ",
											 "ழ",
											 "ள",
											 "ற",
											 "ன",
											 "கி",
											 "ஙி",
											 "சி",
											 "ஞி",
											 "டி",
											 "ணி",
											 "தி",
											 "ழி",
											 "பி",
											 "மி",
											 "யி",
											 "ரி",
											 "லி",
											 "வி",
											 "ழி",
											 "ளி",
											 "றி",
											 "னி",
											 "க",
											 "ங",
											 "ச",
											 "ஞ",
											 "ட",
											 "ண",
											 "த",
											 "ழ",
											 "ப",
											 "ம",
											 "ய",
											 "ர",
											 "ல",
											 "வ",
											 "ழ",
											 "ள",
											 "ற",
											 "ன",
											 "கீ",
											 "ஙீ",
											 "சீ",
											 "ஞீ",
											 "டீ",
											 "ணீ",
											 "தீ",
											 "ழீ",
											 "பீ",
											 "மீ",
											 "யீ",
											 "ரீ",
											 "லீ",
											 "வீ",
											 "ழீ",
											 "ளீ",
											 "றீ",
											 "னv",
											 "கு",
											 "ஙு",
											 "சு",
											 "ஞு",
											 "டு",
											 "ணு",
											 "து",
											 "ழு",
											 "பு",
											 "மு",
											 "யு",
											 "ரு",
											 "லு",
											 "வு",
											 "ழு",
											 "ளு",
											 "று",
											 "னு",
											 "கூ",
											 "ஙூ",
											 "சூ",
											 "ஞூ",
											 "டூ",
											 "ணூ",
											 "தூ",
											 "ழூ",
											 "பூ",
											 "மூ",
											 "யூ",
											 "ரூ",
											 "லூ",
											 "வூ",
											 "ழூ",
											 "ளூ",
											 "றூ",
											 "னூ",
											 "ே",
											 "ை",
											 "ே"};
		#endregion

		public System.Windows.Forms.ProgressBar progressBar1;
		public System.Windows.Forms.Button btStartTraining;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.Label lblerror;
		public System.Windows.Forms.Button btStopTraining;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button Next;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox gbSegmentView;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.PictureBox pbSegment;
		private System.Windows.Forms.Label SegInfo;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.TextBox txtSegmentText;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton btOpenImage;
		private System.Windows.Forms.ToolBarButton btSaveText;
		private System.Windows.Forms.ToolBarButton btSaveNetwork;
		private System.Windows.Forms.ToolBarButton Segment;
		private System.Windows.Forms.ToolBarButton btRecognize;
		private System.Windows.Forms.ToolBarButton btOpenNetwork;
		private System.Windows.Forms.ToolBarButton btBinarize;
		private System.Windows.Forms.ToolBarButton btStart;
		private System.Windows.Forms.ToolBarButton btStop;
		private System.Windows.Forms.ToolBarButton btSep1;
		private System.Windows.Forms.ToolBarButton btSep2;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.PictureBox pbPreView;
		private System.ComponentModel.IContainer components;

		public MainFrm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeTrainingSamples();
			OCR=new MyOCR();
			OCR.InitializeNetwork(this,TrainSamples.Length);			
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainFrm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.TabTrnSam = new System.Windows.Forms.TabPage();
			this.pbPreView = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblerror = new System.Windows.Forms.Label();
			this.btStopTraining = new System.Windows.Forms.Button();
			this.btStartTraining = new System.Windows.Forms.Button();
			this.gbSegmentView = new System.Windows.Forms.GroupBox();
			this.SegInfo = new System.Windows.Forms.Label();
			this.txtSegmentText = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.Next = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.pbSegment = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btCngImage = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.TrainList = new System.Windows.Forms.ListBox();
			this.TabImage = new System.Windows.Forms.TabPage();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.angle = new System.Windows.Forms.NumericUpDown();
			this.hsView = new System.Windows.Forms.HScrollBar();
			this.pView = new System.Windows.Forms.Panel();
			this.pbImage = new System.Windows.Forms.PictureBox();
			this.vsView = new System.Windows.Forms.VScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.tabRText = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.MainToolBar = new System.Windows.Forms.ToolBar();
			this.btOpenImage = new System.Windows.Forms.ToolBarButton();
			this.btSaveText = new System.Windows.Forms.ToolBarButton();
			this.btSaveNetwork = new System.Windows.Forms.ToolBarButton();
			this.Segment = new System.Windows.Forms.ToolBarButton();
			this.btRecognize = new System.Windows.Forms.ToolBarButton();
			this.btOpenNetwork = new System.Windows.Forms.ToolBarButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btBinarize = new System.Windows.Forms.ToolBarButton();
			this.btStart = new System.Windows.Forms.ToolBarButton();
			this.btStop = new System.Windows.Forms.ToolBarButton();
			this.btSep1 = new System.Windows.Forms.ToolBarButton();
			this.btSep2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tabControl1.SuspendLayout();
			this.TabTrnSam.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gbSegmentView.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.TabImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.angle)).BeginInit();
			this.pView.SuspendLayout();
			this.tabRText.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.TabTrnSam,
																					  this.TabImage,
																					  this.tabRText});
			this.tabControl1.HotTrack = true;
			this.tabControl1.Location = new System.Drawing.Point(0, 40);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(896, 531);
			this.tabControl1.TabIndex = 0;
			// 
			// TabTrnSam
			// 
			this.TabTrnSam.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.pbPreView,
																					this.groupBox2,
																					this.gbSegmentView,
																					this.groupBox1});
			this.TabTrnSam.Location = new System.Drawing.Point(4, 25);
			this.TabTrnSam.Name = "TabTrnSam";
			this.TabTrnSam.Size = new System.Drawing.Size(888, 502);
			this.TabTrnSam.TabIndex = 0;
			this.TabTrnSam.Text = "Neural Network";
			// 
			// pbPreView
			// 
			this.pbPreView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pbPreView.Image = ((System.Drawing.Bitmap)(resources.GetObject("pbPreView.Image")));
			this.pbPreView.Location = new System.Drawing.Point(8, 0);
			this.pbPreView.Name = "pbPreView";
			this.pbPreView.Size = new System.Drawing.Size(392, 488);
			this.pbPreView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbPreView.TabIndex = 9;
			this.pbPreView.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.progressBar1,
																					this.lblStatus,
																					this.lblerror,
																					this.btStopTraining,
																					this.btStartTraining});
			this.groupBox2.Location = new System.Drawing.Point(408, 256);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(472, 192);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Training";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(8, 16);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(440, 16);
			this.progressBar1.TabIndex = 2;
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(8, 48);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(440, 24);
			this.lblStatus.TabIndex = 1;
			// 
			// lblerror
			// 
			this.lblerror.Location = new System.Drawing.Point(8, 88);
			this.lblerror.Name = "lblerror";
			this.lblerror.Size = new System.Drawing.Size(440, 48);
			this.lblerror.TabIndex = 4;
			// 
			// btStopTraining
			// 
			this.btStopTraining.Location = new System.Drawing.Point(184, 160);
			this.btStopTraining.Name = "btStopTraining";
			this.btStopTraining.Size = new System.Drawing.Size(128, 24);
			this.btStopTraining.TabIndex = 5;
			this.btStopTraining.Text = "Stop Training";
			this.btStopTraining.Click += new System.EventHandler(this.btStopTraining_Click);
			// 
			// btStartTraining
			// 
			this.btStartTraining.Location = new System.Drawing.Point(24, 160);
			this.btStartTraining.Name = "btStartTraining";
			this.btStartTraining.Size = new System.Drawing.Size(128, 24);
			this.btStartTraining.TabIndex = 3;
			this.btStartTraining.Text = "Start Training";
			this.btStartTraining.Click += new System.EventHandler(this.btStartTraining_Click);
			// 
			// gbSegmentView
			// 
			this.gbSegmentView.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.SegInfo,
																						this.txtSegmentText,
																						this.button4,
																						this.Next,
																						this.button2,
																						this.pbSegment});
			this.gbSegmentView.Location = new System.Drawing.Point(648, 24);
			this.gbSegmentView.Name = "gbSegmentView";
			this.gbSegmentView.Size = new System.Drawing.Size(232, 224);
			this.gbSegmentView.TabIndex = 6;
			this.gbSegmentView.TabStop = false;
			this.gbSegmentView.Text = "Segments";
			// 
			// SegInfo
			// 
			this.SegInfo.Location = new System.Drawing.Point(16, 112);
			this.SegInfo.Name = "SegInfo";
			this.SegInfo.Size = new System.Drawing.Size(192, 48);
			this.SegInfo.TabIndex = 5;
			// 
			// txtSegmentText
			// 
			this.txtSegmentText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSegmentText.Location = new System.Drawing.Point(160, 32);
			this.txtSegmentText.Name = "txtSegmentText";
			this.txtSegmentText.Size = new System.Drawing.Size(56, 38);
			this.txtSegmentText.TabIndex = 4;
			this.txtSegmentText.Text = "";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(72, 40);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 24);
			this.button4.TabIndex = 3;
			this.button4.Text = "----->";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Next
			// 
			this.Next.Location = new System.Drawing.Point(136, 184);
			this.Next.Name = "Next";
			this.Next.Size = new System.Drawing.Size(72, 24);
			this.Next.TabIndex = 2;
			this.Next.Text = "Next";
			this.Next.Click += new System.EventHandler(this.Next_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 184);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 1;
			this.button2.Text = "Previous";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// pbSegment
			// 
			this.pbSegment.BackColor = System.Drawing.Color.White;
			this.pbSegment.Location = new System.Drawing.Point(8, 24);
			this.pbSegment.Name = "pbSegment";
			this.pbSegment.Size = new System.Drawing.Size(56, 56);
			this.pbSegment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbSegment.TabIndex = 0;
			this.pbSegment.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button1,
																					this.btCngImage,
																					this.pictureBox1,
																					this.TrainList});
			this.groupBox1.Location = new System.Drawing.Point(408, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 224);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Training Sample";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(160, 104);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 24);
			this.button1.TabIndex = 4;
			this.button1.Text = "Test";
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// btCngImage
			// 
			this.btCngImage.Location = new System.Drawing.Point(16, 184);
			this.btCngImage.Name = "btCngImage";
			this.btCngImage.Size = new System.Drawing.Size(152, 24);
			this.btCngImage.TabIndex = 3;
			this.btCngImage.Text = "Change Image";
			this.btCngImage.Click += new System.EventHandler(this.btCngImage_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Location = new System.Drawing.Point(160, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 56);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// TrainList
			// 
			this.TrainList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TrainList.ItemHeight = 29;
			this.TrainList.Location = new System.Drawing.Point(8, 24);
			this.TrainList.Name = "TrainList";
			this.TrainList.Size = new System.Drawing.Size(136, 149);
			this.TrainList.TabIndex = 0;
			this.TrainList.SelectedIndexChanged += new System.EventHandler(this.TrainList_SelectedIndexChanged);
			// 
			// TabImage
			// 
			this.TabImage.AutoScroll = true;
			this.TabImage.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.statusBar1,
																				   this.angle,
																				   this.hsView,
																				   this.pView,
																				   this.vsView,
																				   this.label1});
			this.TabImage.Location = new System.Drawing.Point(4, 25);
			this.TabImage.Name = "TabImage";
			this.TabImage.Size = new System.Drawing.Size(888, 502);
			this.TabImage.TabIndex = 1;
			this.TabImage.Text = "Image";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 480);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(888, 22);
			this.statusBar1.TabIndex = 3;
			// 
			// angle
			// 
			this.angle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.angle.DecimalPlaces = 1;
			this.angle.Location = new System.Drawing.Point(832, 40);
			this.angle.Maximum = new System.Decimal(new int[] {
																  360,
																  0,
																  0,
																  0});
			this.angle.Minimum = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  -2147483648});
			this.angle.Name = "angle";
			this.angle.Size = new System.Drawing.Size(48, 20);
			this.angle.TabIndex = 2;
			this.angle.ValueChanged += new System.EventHandler(this.angle_ValueChanged);
			// 
			// hsView
			// 
			this.hsView.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.hsView.Location = new System.Drawing.Point(8, 472);
			this.hsView.Name = "hsView";
			this.hsView.Size = new System.Drawing.Size(808, 17);
			this.hsView.TabIndex = 1;
			this.hsView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsView_Scroll);
			// 
			// pView
			// 
			this.pView.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pView.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pView.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.pbImage});
			this.pView.Location = new System.Drawing.Point(8, 8);
			this.pView.Name = "pView";
			this.pView.Size = new System.Drawing.Size(792, 456);
			this.pView.TabIndex = 0;
			// 
			// pbImage
			// 
			this.pbImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbImage.Location = new System.Drawing.Point(24, 8);
			this.pbImage.Name = "pbImage";
			this.pbImage.Size = new System.Drawing.Size(184, 160);
			this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbImage.TabIndex = 0;
			this.pbImage.TabStop = false;
			this.pbImage.Resize += new System.EventHandler(this.pbImage_Resize);
			this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
			// 
			// vsView
			// 
			this.vsView.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.vsView.Location = new System.Drawing.Point(808, 8);
			this.vsView.Name = "vsView";
			this.vsView.Size = new System.Drawing.Size(17, 472);
			this.vsView.TabIndex = 1;
			this.vsView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsView_Scroll);
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.Location = new System.Drawing.Point(832, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Rotate";
			// 
			// tabRText
			// 
			this.tabRText.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.richTextBox1});
			this.tabRText.Location = new System.Drawing.Point(4, 25);
			this.tabRText.Name = "tabRText";
			this.tabRText.Size = new System.Drawing.Size(888, 502);
			this.tabRText.TabIndex = 2;
			this.tabRText.Text = "Recognized Text";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(8, 8);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(864, 480);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem16,
																					 this.menuItem12,
																					 this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem8,
																					  this.menuItem11});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5});
			this.menuItem2.Text = "New";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "Network";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.menuItem7});
			this.menuItem3.Text = "Open";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItem6.Text = "Image To Recognize";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftO;
			this.menuItem7.Text = "Trained Network";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9,
																					  this.menuItem10});
			this.menuItem8.Text = "Save";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuItem9.Text = "Recognized Text";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
			this.menuItem10.Text = "Trained Network";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "Exit";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem17,
																					   this.menuItem18,
																					   this.menuItem19});
			this.menuItem16.Text = "Network";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "Start Training";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 1;
			this.menuItem18.Text = "Stop Training";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 2;
			this.menuItem19.Text = "Add Training Sample";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem22,
																					   this.menuItem15,
																					   this.menuItem14,
																					   this.menuItem13,
																					   this.menuItem23,
																					   this.menuItem24});
			this.menuItem12.Text = "Image";
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 0;
			this.menuItem22.Text = "Scan an Image";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 1;
			this.menuItem15.Text = "Convert To Grayscale";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 2;
			this.menuItem14.Text = "Binarize The Image";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.Text = "Skew Correction";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 4;
			this.menuItem23.Text = "Segment";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 5;
			this.menuItem24.Text = "Recognize";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem21,
																					  this.menuItem20});
			this.menuItem4.Text = "Help";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 0;
			this.menuItem21.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuItem21.Text = "Content";
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 1;
			this.menuItem20.Text = "About Tamil OCR";
			// 
			// MainToolBar
			// 
			this.MainToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.btOpenNetwork,
																						   this.btOpenImage,
																						   this.btSep1,
																						   this.btSaveText,
																						   this.btSaveNetwork,
																						   this.btSep2,
																						   this.Segment,
																						   this.btRecognize,
																						   this.btBinarize,
																						   this.toolBarButton1,
																						   this.btStart,
																						   this.btStop});
			this.MainToolBar.ButtonSize = new System.Drawing.Size(32, 20);
			this.MainToolBar.DropDownArrows = true;
			this.MainToolBar.ImageList = this.imageList1;
			this.MainToolBar.Name = "MainToolBar";
			this.MainToolBar.ShowToolTips = true;
			this.MainToolBar.Size = new System.Drawing.Size(896, 25);
			this.MainToolBar.TabIndex = 1;
			this.MainToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.MainToolBar_ButtonClick);
			// 
			// btOpenImage
			// 
			this.btOpenImage.ImageIndex = 1;
			this.btOpenImage.Tag = "OpenImg";
			this.btOpenImage.ToolTipText = "Open image to recognize";
			// 
			// btSaveText
			// 
			this.btSaveText.ImageIndex = 2;
			this.btSaveText.Tag = "SaveTxt";
			this.btSaveText.ToolTipText = "Save Recognized Text";
			// 
			// btSaveNetwork
			// 
			this.btSaveNetwork.ImageIndex = 4;
			this.btSaveNetwork.Tag = "SaveNet";
			this.btSaveNetwork.ToolTipText = "Save Trained Network";
			// 
			// Segment
			// 
			this.Segment.ImageIndex = 5;
			this.Segment.Tag = "Segment";
			this.Segment.ToolTipText = "Segment The Image";
			// 
			// btRecognize
			// 
			this.btRecognize.ImageIndex = 6;
			this.btRecognize.Tag = "Recognize";
			this.btRecognize.ToolTipText = "Recognize";
			// 
			// btOpenNetwork
			// 
			this.btOpenNetwork.ImageIndex = 7;
			this.btOpenNetwork.Tag = "OpenNet";
			this.btOpenNetwork.ToolTipText = "Open Trained Network";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btBinarize
			// 
			this.btBinarize.ImageIndex = 8;
			this.btBinarize.Tag = "Binarize";
			this.btBinarize.ToolTipText = "Binarize";
			// 
			// btStart
			// 
			this.btStart.ImageIndex = 9;
			this.btStart.Tag = "Start";
			this.btStart.ToolTipText = "Start Training";
			// 
			// btStop
			// 
			this.btStop.ImageIndex = 10;
			this.btStop.Tag = "Stop";
			this.btStop.ToolTipText = "Stop Training";
			// 
			// btSep1
			// 
			this.btSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btSep2
			// 
			this.btSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// MainFrm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(896, 569);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.MainToolBar,
																		  this.tabControl1});
			this.Menu = this.mainMenu;
			this.Name = "MainFrm";
			this.Text = "TamilOCR";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFrm_Closing);
			this.tabControl1.ResumeLayout(false);
			this.TabTrnSam.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.gbSegmentView.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.TabImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.angle)).EndInit();
			this.pView.ResumeLayout(false);
			this.tabRText.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainFrm());
		}

		private void pbImage_Resize(object sender, System.EventArgs e)
		{
			RefreshScrollBars();
		}
		private void RefreshScrollBars()
		{
			vsView.Visible =(pbImage.Height>pView.Height); //Show the ScrollBars only when it is required
			hsView.Visible =(pbImage.Width>pView.Width);
			if(pbImage.Height>pView.Height)
			{
				vsView.Maximum=(pbImage.Height-pView.Height);
				vsView.Minimum=0;
				vsView.Height=pView.Height;
				vsView.Left=pView.Left+pView.Width+10;
				vsView.Top=pView.Top;
			}
			if(pbImage.Width>pView.Width)
			{
				hsView.Maximum=(pbImage.Width-pView.Width);
				hsView.Minimum=0;
				hsView.Width=pView.Width;
				hsView.Left=pView.Left;
				hsView.Top=pView.Top+pView.Height+10;
								
			}
			pbImage.Top=-(vsView.Value);
			pbImage.Left=-(hsView.Value);
		}
		private void OpenNewImage()
		{
			
			OpenFileDialog ofd=new OpenFileDialog();
			ofd.Filter="Image Files(*.BMP;*.JPG;*.GIF;*.tif)|*.BMP;*.JPG;*.GIF;*.tif|All files (*.*)|*.*";
			if(ofd.ShowDialog(this)==DialogResult.OK)
			{
				this.ImageBmp=(Bitmap)Image.FromFile(ofd.FileName);
				this.pbImage.Image=ImageBmp;
				this.pbPreView.Image=ImageBmp;
			}			
		}
		private void BinarizeImage()
		{
			if(this.ImageBmp!=null)
			{
				this.ImageBmp=ImageProcessing.Binarize(this.ImageBmp);
				this.pbImage.Image=ImageBmp;
			}
		}
		private void ConvertToGrayscale()
		{
			if(this.ImageBmp!=null)
			{
				this.ImageBmp=ImageProcessing.ConvertToGrayscale(this.ImageBmp);
				this.pbImage.Image=ImageBmp;
			}
		}
		private void vsView_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			pbImage.Top=-(vsView.Value);
			pbImage.Left=-(hsView.Value);
		}

		private void hsView_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			pbImage.Top=-(vsView.Value);
			pbImage.Left=-(hsView.Value);
		}
        private void menuItem6_Click(object sender, System.EventArgs e)
		{
			OpenNewImage();
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			BinarizeImage();			
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			ConvertToGrayscale();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		}
		private void pbImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			/*if(MessageBox.Show("???","lk",MessageBoxButtons.YesNo)==DialogResult.Yes)
			{
				// Set world transform of graphics object to translate.
				e.Graphics.TranslateTransform(100.0F, 0.0F);
				// Then to rotate, appending rotation matrix.
				e.Graphics.RotateTransform(30.0F, MatrixOrder.Append);
				// Draw translated, rotated ellipse to screen.
				e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
			}*/
		}
		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			this.ImageBmp=ImageProcessing.SkewCorrection(ImageBmp);
			this.pbImage.Image=this.ImageBmp;
		}
		private void angle_ValueChanged(object sender, System.EventArgs e)
		{
			
			//this.ImageBmp=ImageProcessing.SkewCorrection(ImageBmp);
			if( angle.Value > 359.9m )
			{
				angle.Value = 0;
				return ;
			}

			if( angle.Value < 0.0m )
			{
				angle.Value = 359;
				return ;
			}
			Bitmap Old=(Bitmap)this.pbImage.Image;
			this.pbImage.Image =ImageProcessing.RotateImage(this.ImageBmp, (float) angle.Value);
			if( Old != ImageBmp )
			{
				Old.Dispose();
			}
		}
		private void InitializeTrainingSamples()
		{
			TrainList.Items.AddRange(StringList);
			TrainSamples=new TrainingSample[StringList.Length];
			for(int i=0;i<StringList.Length;i++)
			{
				TrainSamples[i]=new TrainingSample((string)StringList[i],DrawString((string)StringList[i]));
			}
		}
		private  Bitmap DrawString(string str)
		{
			Bitmap TestBmp = new Bitmap(32,32);
			Font m_Font=this.TrainList.Font;
			Graphics gr = Graphics.FromImage(TestBmp);
			Size size =Size.Round(gr.MeasureString(str,m_Font));
			TestBmp.Dispose();			
			Bitmap aSrc = new Bitmap(size.Width+4,size.Height+4);
			Graphics bmp = Graphics.FromImage(aSrc);
			bmp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			bmp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			bmp.Clear(Color.White);
			bmp.DrawString(str,m_Font,new SolidBrush(Color.Black),new Point(0,0),new StringFormat());
			//ShowNoise(size,bmp,NoisePercent);
			return aSrc;
		}

		private void TrainList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pictureBox1.Image=TrainSamples[TrainList.SelectedIndex].Bmp;
		}
		private void StartTraining()
		{
			this.stop=true;
			OCR.Train(this.TrainSamples);
		}
		private void btStartTraining_Click(object sender, System.EventArgs e)
		{
			StartTraining();
		}

		private void btStopTraining_Click(object sender, System.EventArgs e)
		{
			this.stop=false;
		}

		private void MainFrm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.stop=false;
		}

		private void btAddNTS_Click(object sender, System.EventArgs e)
		{
			
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			SaveNetwork();
		}
		private void SaveNetwork()
		{
			SaveFileDialog sfd=new SaveFileDialog();
			if(sfd.ShowDialog()==DialogResult.OK)
			{
				string FileName=sfd.FileName;
				this.OCR.backpropNetwork.SaveToFile(FileName);
			}
			sfd.Dispose();
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			this.StartTraining();
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			this.stop=false;
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			LoadNetwork();
		}
		private void LoadNetwork()
		{
			OpenFileDialog ofd=new OpenFileDialog();
			ofd.Filter="Neural Network(*.net)|*.net|All files (*.*)|*.*";
			if(ofd.ShowDialog()==DialogResult.OK)
			{
				string FileName=ofd.FileName;
				this.OCR.backpropNetwork.LoadFromFile(FileName);
			}
			ofd.Dispose();
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			MessageBox.Show(""+StringList[OCR.RecognizeBitmap((Bitmap)this.pictureBox1.Image)]);
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
			//ArrayList MYSeg=null;
			SegmentImage();
			
		}
		void SegmentImage()
		{
			Bitmap IpPic=(Bitmap)this.pbImage.Image;
			if(this.pbImage.Image!=null)
			{
				int h=(IpPic.Height);
				int w=(IpPic.Width);
				this.statusBar1.Text="Segmenting ..........";
				this.Refresh();
				Segmentor seg=new Segmentor(IpPic);
				this.ImageSegments =seg.GetSegments();
				this.statusBar1.Text="Segmentaion Done "+this.ImageSegments.Count.ToString()+" Letters Found";
				this.SegmentIndex=0;
				SetSegmentView();
				
			}
		}
		private void SetSegmentView()
		{
			Segment seg=(Segment)this.ImageSegments[SegmentIndex];
			this.pbSegment.Image=seg.bmpGlimph;
			this.SegInfo.Text="Line: "+seg.lLineCount+" Word: "+seg.lWordCount;
			
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(this.ImageSegments==null)
			{
				this.gbSegmentView.Enabled=false;
			}
			else
			{
				this.gbSegmentView.Enabled=true;
			}
			this.btCngImage.Enabled=!(TrainList.SelectedIndex==-1);
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			if(SegmentIndex>0)
			{
				SegmentIndex--;
			}
			SetSegmentView();
		}

		private void Next_Click(object sender, System.EventArgs e)
		{
			if(SegmentIndex<(this.ImageSegments.Count-1))
			{
				SegmentIndex++;
			}
			SetSegmentView();
		}

		private void menuItem24_Click(object sender, System.EventArgs e)
		{
			Recognize();
		}
		private void Recognize()
		{
			if(this.ImageSegments==null)
			{
				SegmentImage();
			}
			try
			{
				string str="";
				long pLine=0;
				long pWord=0;
				if(this.ImageSegments[0].GetType()==typeof(Segment))
				{
					if(this.ImageSegments.Count>0)
					{
					
						foreach(Segment seg  in  this.ImageSegments)
						{
							string tempstr=(string)StringList[OCR.RecognizeBitmap(seg.bmpGlimph)];
							if(pLine!=seg.lLineCount)
							{
								str+="\r\n";	
							}
							else if(pWord!=seg.lWordCount)
							{
								str+=" ";
							}
							str+=tempstr;
							pLine=seg.lLineCount;
							pWord=seg.lWordCount;
						}
					}
					this.richTextBox1.Text=str;
					MessageBox.Show("Done");
				}
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message,"Error");
			}
		}

		private void btCngImage_Click(object sender, System.EventArgs e)
		{
			
			
			TrainingSample TS=TrainSamples[TrainList.SelectedIndex];
			ChangeImageDlg ci=new ChangeImageDlg(this,TS);
			if(ci.ShowDialog()==DialogResult.OK)
			{
				TS.Bmp=(Bitmap)ci.pbSelectedImage.Image;
				pictureBox1.Image=TrainSamples[TrainList.SelectedIndex].Bmp;
				
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.txtSegmentText.Text= ""+StringList[OCR.RecognizeBitmap((Bitmap)this.pbSegment.Image)];
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			SaveRecognizedText();
		}
		private void SaveRecognizedText()
		{
			SaveFileDialog sfd=new SaveFileDialog();
			if(sfd.ShowDialog()==DialogResult.OK)
			{
				string FileName=sfd.FileName;
				this.richTextBox1.SaveFile(FileName);
			}
			sfd.Dispose();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void MainToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button.Tag.Equals("OpenNet"))
			{
				LoadNetwork();
			}
			else if(e.Button.Tag.Equals("OpenImg"))
			{
				OpenNewImage();
			}
			else if(e.Button.Tag.Equals("SaveTxt"))
			{
				SaveRecognizedText();
			}
			else if(e.Button.Tag.Equals("SaveNet"))
			{
				SaveNetwork();
			}
			else if(e.Button.Tag.Equals("Segment"))
			{
				SegmentImage();
			}
			else if(e.Button.Tag.Equals("Recognize"))
			{
				Recognize();
			}
			else if(e.Button.Tag.Equals("Binarize"))
			{
				BinarizeImage();
			}
			else if(e.Button.Tag.Equals("Start"))
			{
				StartTraining();
			}
			else if(e.Button.Tag.Equals("Stop"))
			{
				stop=false;
			}
		}


		

		
		
		

		

		

		

		
	}
}
