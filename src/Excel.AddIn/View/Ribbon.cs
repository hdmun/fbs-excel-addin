﻿using Excel.AddIn.View;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace Excel.AddIn
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnCreateClassFile_Click(object sender, RibbonControlEventArgs e)
        {
            var workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            var worksheet = workbook.ActiveSheet as Worksheet;

            var reader = new SchemaReader(worksheet);
            // 테이블 스키마 정보 읽기
            var flatbuffTable = reader.ReadColumns();

            // 플랫버퍼 스키마 파일 만들고 클래스 파일 생성
            SchemaWriter.Write(flatbuffTable);
        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            var form = new SettingForm(Globals.ThisAddIn.ConfigViewModel);
            form.ShowDialog();
        }
    }
}
