using System.Windows.Forms;

namespace ScreenImageOverlay.WindowsFormsApp
{
	public partial class SlideshowDialog : Form
	{
		public NumericUpDown NumericUpDown => numericUpDown1;
		public CheckBox CheckBox => checkBox1;

		public SlideshowDialog()
		{
			InitializeComponent();
		}
	}
}
