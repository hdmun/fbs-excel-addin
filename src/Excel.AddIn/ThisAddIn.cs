using Excel.AddIn.ViewModel;
using Flatbuffer.Serializer;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Excel.AddIn
{
    public partial class ThisAddIn
    {
        public string MyLocation { get; private set; }

        public ConfigViewModel ConfigViewModel { get; set; } = new ConfigViewModel();

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.WorkbookBeforeSave += Application_WorkbookBeforeSave;

            //Get the assembly information
            var assemblyInfo = Assembly.GetExecutingAssembly();

            // CodeBase is the location of the ClickOnce deployment files
            Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);
            MyLocation = Path.GetDirectoryName(uriCodeBase.LocalPath.ToString());

            // ini 로드
            ConfigViewModel.Load(MyLocation);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_WorkbookBeforeSave(Workbook workbook, bool saveAsUI, ref bool cancel)
        {
            var outputPath = ConfigViewModel.BinaryOutputPaths;
            if (false == outputPath.Any())
            {
                MessageBox.Show("저장 경로가 세팅되어있지 않아 저장하지 않습니다.");
                return;
            }

            var worksheet = workbook.ActiveSheet as Worksheet;

            var reader = new SchemaReader(worksheet);

            // 테이블 스키마 정보 읽기
            var flatbuffTable = reader.ReadColumns();

            // 임시 폴더에 플랫버퍼 스키마 파일 만들고 클래스 파일 생성
            var tempPath = Path.GetTempPath();
            var writer = new SchemaWriter()
            {
                WorkingDirectory = MyLocation,
                OutputDirectory = tempPath,
            };
            var (tablePath, itemPath) = writer.Write(flatbuffTable, CompileLanguage.csharp);

            // 직렬화를 위한 준비
            var compiler = new RuntimeCompiler(MyLocation);
            var files = new string[]
            {
                $"{itemPath}.cs",
                $"{tablePath}.cs",
            };
            compiler.Compile(files);

            var tableType = compiler.GetType(flatbuffTable.Name);
            var itemType = compiler.GetType($"{flatbuffTable.Name}_item");

            // 전체 행 데이터 읽기
            var tableRows = reader.ReadRowAll();

            // 직렬화
            foreach (var path in outputPath)
            {
                var serializer = new Serializer(tableType, itemType);
                serializer.OutputDirectory = path;
                serializer.Serialize(tableRows.ToArray());
            }
        }

        #region VSTO에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
