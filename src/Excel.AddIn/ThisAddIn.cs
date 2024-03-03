using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;

namespace Excel.AddIn
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.WorkbookBeforeSave += Application_WorkbookBeforeSave;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_WorkbookBeforeSave(Workbook workbook, bool saveAsUI, ref bool cancel)
        {
            // 엑셀 문서가 저장되기 전에 실행되는 코드
            // 여기에 원하는 작업을 추가할 수 있습니다.
            // 예: 특정 데이터 검증, 추가 정보 입력 등

            var worksheet = workbook.ActiveSheet as Worksheet;

            var reader = new SchemaReader(worksheet);

            // 테이블 스키마 정보 읽기
            var flatbuffTable = reader.ReadColumns();

            // 전체 행 데이터 읽기
            var tableRows = reader.ReadRowAll();

            // TODO : 직렬화
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
