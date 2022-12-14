using System.Collections.Generic;
using System.ComponentModel;

namespace ScreenImageOverlay.WindowsFormsApp
{
	public class Playlist : INotifyPropertyChanged
	{
		#region Events

		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		#endregion

		#region Fields

		private readonly List<string> fileNames = new List<string>();

		private int selectedIndex = -1;
		private bool allowWrap = true;

		#endregion

		#region Properties

		public IReadOnlyList<string> FileNames => fileNames;

		public bool AllowWrap
		{
			get => allowWrap;
			set
			{
				if (allowWrap != value)
				{
					allowWrap = value;
					PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(AllowWrap)));
				}
			}
		}

		public int SelectedIndex
		{
			get => selectedIndex;
			set
			{
				if (selectedIndex != value)
				{
					selectedIndex = value;
					PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
				}
			}
		}

		public string SelectedItem
			=> selectedIndex < 0
			|| selectedIndex > FileNames.Count - 1
				? null
				: FileNames[selectedIndex];

		#endregion

		#region Methods

		public void BeginUpdate()
		{
		}

		public void EndUpdate()
		{
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FileNames)));
		}

		public void Add(string source)
		{
			fileNames.Add(source);
		}

		public void AddRange(IEnumerable<string> source)
		{
			fileNames.AddRange(source);
		}

		public void Clear()
		{
			Deselect();
			fileNames.Clear();
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(FileNames)));
		}

		public void SelectFirst()
			=> SelectedIndex = 0;

		public void SelectLast()
			=> SelectedIndex = fileNames.Count - 1;

		public void SelectPrevious()
		{
			if (allowWrap && SelectedIndex == 0)
			{
				SelectLast();
			}
			else
			{
				SelectPreviousNoWrap();
			}
		}

		public void SelectPreviousNoWrap()
			=> --SelectedIndex;

		public void SelectNext()
		{
			if (allowWrap && SelectedIndex == fileNames.Count - 1)
			{
				SelectFirst();
			}
			else
			{
				SelectNextNoWrap();
			}
		}

		public void SelectNextNoWrap()
			=> ++SelectedIndex;

		public void Deselect()
			=> SelectedIndex = -1;

		public bool CanSelectFirst()
			=> fileNames.Count > 0 && SelectedIndex != 0;

		public bool CanSelectLast()
			=> fileNames.Count > 0 && SelectedIndex != fileNames.Count - 1;

		public bool CanSelectPrevious()
			=> fileNames.Count > 1 && (allowWrap || SelectedIndex > 0);

		public bool CanSelectNext()
			=> fileNames.Count > 1 && (allowWrap || SelectedIndex < fileNames.Count - 1);

		public bool CanDeselect()
			=> SelectedIndex != -1;

		public bool CanClear()
			=> fileNames.Count > 0;

		#endregion
	}
}
