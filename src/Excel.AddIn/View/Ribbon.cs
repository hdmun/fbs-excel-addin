using Excel.AddIn.View;
using Flatbuffer.Serializer;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Excel.AddIn
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnCreateClassFile_Click(object sender, RibbonControlEventArgs e)
        {
            var classOutputPath = Globals.ThisAddIn.ConfigViewModel.ClassOutputPaths;
            if (false == classOutputPath.Any())
            {
                MessageBox.Show("클래스 파일 출력 경로를 설정해주세요");
                return;
            }

            var workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            var worksheet = workbook.ActiveSheet as Worksheet;

            var reader = new SchemaReader(worksheet);
            // 테이블 스키마 정보 읽기
            var flatbuffTable = reader.ReadColumns();

            // 플랫버퍼 스키마 파일 만들고 클래스 파일 생성
            // 단순하게 루프 돌리자
            foreach (var path in classOutputPath)
            {
                var writer = new SchemaWriter()
                {
                    WorkingDirectory = Globals.ThisAddIn.MyLocation,
                    OutputDirectory = path,
                };
                writer.Write(flatbuffTable, CompileLanguage.csharp);
            }
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            var form = new SettingForm(Globals.ThisAddIn.ConfigViewModel);
            form.ShowDialog();
        }
    }
}
