using System.Windows.Forms;

namespace ScreenImageOverlay.WindowsFormsApp
{
	public partial class ShortcutsDialog : Form
	{
		public ListView ListView => listView1;
		public ListViewGroup MouseListViewGroup => listView1.Groups[0];
		public ListViewGroup MouseWheelListViewGroup => listView1.Groups[1];
		public ListViewGroup KeyListViewGroup => listView1.Groups[2];

		public ShortcutsDialog()
		{
			InitializeComponent();
		}
	}
}
