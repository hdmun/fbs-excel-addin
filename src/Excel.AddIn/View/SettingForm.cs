using Excel.AddIn.ViewModel;
using System;
using System.Windows.Forms;

namespace Excel.AddIn.View
{
    public partial class SettingForm : Form
    {
        private readonly ConfigViewModel _viewModel;

        public SettingForm(ConfigViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            listBoxClassOutput.DataSource = _viewModel.ClassOutputPaths;
            listBoxBinaryOutput.DataSource = _viewModel.BinaryOutputPaths;
        }

        private void btnClassOutputAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var added = _viewModel.AddClassOutputPath(dialog.SelectedPath);
                    if (added)
                    {
                        // ui refresh
                        listBoxClassOutput.DataSource = null;
                        listBoxClassOutput.DataSource = _viewModel.ClassOutputPaths;

                        _viewModel.Save();
                    }
                }
            }
        }

        private void btnBinaryOutputAdd_Click(object sender, EventArgs e)
        {

            using (var dialog = new FolderBrowserDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    var added = _viewModel.AddBinaryOutputPath(dialog.SelectedPath);
                    if (added)
                    {
                        // ui refresh
                        listBoxBinaryOutput.DataSource = null;
                        listBoxBinaryOutput.DataSource = _viewModel.BinaryOutputPaths;

                        _viewModel.Save();
                    }
                }
            }
        }

        private void listBoxClassOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var index = listBoxClassOutput.SelectedIndex;
                var removed = _viewModel.RemoveClassOutputPath(index);
                if (removed)
                {
                    // ui refresh
                    listBoxClassOutput.DataSource = null;
                    listBoxClassOutput.DataSource = _viewModel.ClassOutputPaths;
                    if (_viewModel.ClassOutputPaths.Count > 0)
                        listBoxClassOutput.SelectedIndex = Math.Max(index - 1, 0);

                    _viewModel.Save();
                }
            }
        }

        private void listBoxBinaryOutput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var index = listBoxBinaryOutput.SelectedIndex;
                var removed = _viewModel.RemoveBinaryOutputPath(index);
                if (removed)
                {
                    // ui refresh
                    listBoxBinaryOutput.DataSource = null;
                    listBoxBinaryOutput.DataSource = _viewModel.BinaryOutputPaths;
                    if (_viewModel.BinaryOutputPaths.Count > 0)
                        listBoxBinaryOutput.SelectedIndex = Math.Max(index - 1, 0);

                    _viewModel.Save();
                }
            }
        }
    }
}
