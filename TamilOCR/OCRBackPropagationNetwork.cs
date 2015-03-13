using System;
using System.Windows.Forms;
using xpidea.neuro.net.patterns;
using xpidea.neuro.net.backprop;
using xpidea.neuro.net;
namespace TamilOCR
{
	/// <summary>
	/// Summary description for OCRBackPropagationNetwork.
	/// </summary>
	public class OCRBackPropagationNetwork: BackPropagationRPROPNetwork
	{
		
		private MainFrm owner;
		int NoiseLevel;
		public OCRBackPropagationNetwork (MainFrm paramowner,int NL,int[] nodesInEachLayer):base(nodesInEachLayer)
		{
			NoiseLevel=NL;
			owner=paramowner;
			//this.owner = owner;
		}
		public OCRBackPropagationNetwork (string filename):base(filename)
		{
			NoiseLevel=0;
			//this.owner = owner;
		}
		private int OutputPatternIndex(Pattern pattern)
		{
			for (int i = 0; i<pattern.OutputsCount;i++)
				if (pattern.Output[i] == 1 )
					return i;
			return -1;
		}

		public void AddNoiseToInputPattern(int levelPercent)
		{
			int i = ((NodesInLayer(0) - 1) * levelPercent)/100;
			while (i > 0) 
			{
				nodes[(int)(BackPropagationNetwork.Random(0, NodesInLayer(0) - 1))].Value = BackPropagationNetwork.Random(0, 100);
				i--;
			}

		}

		public int BestNodeIndex 
		{ 
			get 
			{
				int result = -1;
				double aMaxNodeValue = 0;
				double aMinError = double.PositiveInfinity;
				for (int i = 0; i< this.OutputNodesCount;i++)
				{
					NeuroNode node = OutputNode(i);
					
					if ((node.Value > aMaxNodeValue)||((node.Value >= aMaxNodeValue)&&(node.Error < aMinError))) 
					{
						aMaxNodeValue = node.Value;
						aMinError = node.Error;
						result = i;
					}

				}
				return result;
			}
		}
		public override void Train(PatternsCollection patterns)
		{
							
			int  iteration = 0;
			if (patterns != null) 
			{
				double error = 0;
				int good = 0;
				while (good < patterns.Count) // Train until all patterns are correct
				{
					if (!owner.stop) return;
					error = 0;
					
					owner.progressBar1.Value = (good * 100)/owner.progressBar1.Maximum;
					owner.lblStatus.Text = "Training progress: " + ((good * 100)/owner.progressBar1.Maximum).ToString() + "%";					
					good = 0;
					for (int i = 0; i<patterns.Count; i++)
					{
						for (int k = 0; k<NodesInLayer(0); k++)	
							nodes[k].Value = patterns[i].Input[k];
						this.Run();
						for (int k = 0;k< this.OutputNodesCount;k++) 
						{
							error += Math.Abs(this.OutputNode(k).Error);
							this.OutputNode(k).Error = patterns[i].Output[k];
						}
						this.Learn();
						if (BestNodeIndex == OutputPatternIndex(patterns[i]))
							good++;							
						iteration ++;						
						Application.DoEvents();

					}
					foreach (NeuroLink link in links) ((EpochBackPropagationLink)link).Epoch(patterns.Count);					//if ((iteration%2) == 0)
					owner.lblerror.Text = "AVG Error: " + (error / OutputNodesCount).ToString() + "  Iteration: " + iteration.ToString();					
				}
				MessageBox.Show("Done");
			}
		}
	}
}
