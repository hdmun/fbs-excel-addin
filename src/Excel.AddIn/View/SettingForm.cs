using Excel.AddIn.ViewModel;
using Flatbuffer.Serializer;
using System;
using System.Windows.Forms;

namespace Excel.AddIn.View
{
    public partial class SettingForm : Form
    {
        private readonly ConfigViewModel _viewModel;
        private bool _loaded = false;

        public SettingForm(ConfigViewModel viewModel)
        {
            InitializeComponent();

            // checkbox 태그 설정
            checkBoxFlatcCpp.Tag = CompileLanguage.cpp;
            checkBoxFlatcCsharp.Tag = CompileLanguage.csharp;
            checkBoxFlatcJava.Tag = CompileLanguage.java;
            checkBoxFlatcKotlin.Tag = CompileLanguage.kotlin;
            checkBoxFlatcRust.Tag = CompileLanguage.rust;
            checkBoxFlatcGo.Tag = CompileLanguage.go;
            checkBoxFlatcPy.Tag = CompileLanguage.python;

            _viewModel = viewModel;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            listBoxClassOutput.DataSource = _viewModel.ClassOutputPaths;
            listBoxBinaryOutput.DataSource = _viewModel.BinaryOutputPaths;

            // 데이터 바인딩해야 하는데 귀찮다
            checkBoxFlatcCpp.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.cpp, out var result)
                ? result
                : false;
            checkBoxFlatcCsharp.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.csharp, out result)
                ? result
                : false;
            checkBoxFlatcJava.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.java, out result)
                ? result
                : false;
            checkBoxFlatcKotlin.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.kotlin, out result)
                ? result
                : false;
            checkBoxFlatcRust.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.rust, out result)
                ? result
                : false;
            checkBoxFlatcGo.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.go, out result)
                ? result
                : false;
            checkBoxFlatcPy.Checked = _viewModel.Lanaguage.TryGetValue(CompileLanguage.python, out result)
                ? result
                : false;

            _loaded = true;
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

        private void checkBoxFlatc_CheckedChanged(object sender, EventArgs e)
        {
            if (false == _loaded)
                return;

            var checkBox = sender as CheckBox;
            if (checkBox is null)
                return;

            if (false == checkBox.Tag is CompileLanguage)
                return;

            var language = (CompileLanguage)checkBox.Tag;

            _viewModel.UpdateCompileOption(language, checkBox.Checked);
            _viewModel.Save();
        }
    }
}
