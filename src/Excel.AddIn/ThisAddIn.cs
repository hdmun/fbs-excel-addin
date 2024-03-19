﻿using Excel.AddIn.ViewModel;
using Flatbuffer.Serializer;
using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Excel.AddIn
{
    public partial class ThisAddIn
    {
        public ConfigViewModel ConfigViewModel { get; set; } = new ConfigViewModel();

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.WorkbookBeforeSave += Application_WorkbookBeforeSave;

            ConfigViewModel.Load();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_WorkbookBeforeSave(Workbook workbook, bool saveAsUI, ref bool cancel)
        {
            var worksheet = workbook.ActiveSheet as Worksheet;

            var myPath = this.Application.Path;
            var reader = new SchemaReader(worksheet);

            // 테이블 스키마 정보 읽기
            var flatbuffTable = reader.ReadColumns();

            // 플랫버퍼 스키마 파일 만들고 클래스 파일 생성
            var (tablePath, itemPath) = SchemaWriter.Write(flatbuffTable, CompileLanguage.csharp);

            // 직렬화를 위한 준비
            var compiler = new RuntimeCompiler();
            var files = new string[] { $"{itemPath}.cs", $"{tablePath}.cs" };
            var (tableType, itemType) = compiler.Compile(files, $"{flatbuffTable.Name}", $"{flatbuffTable.Name}_item");

            // 전체 행 데이터 읽기
            var tableRows = reader.ReadRowAll();

            // 직렬화
            var serializer = new Serializer(tableType, itemType);
            serializer.Serialize(tableRows.ToArray());
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
