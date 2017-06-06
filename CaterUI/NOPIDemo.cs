using CaterBll;
using CaterModel;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class NOPIDemo : Form
    {
        public NOPIDemo()
        {
            InitializeComponent();
           // LoadList();
        }
        ManagerInfoBll miBll = new ManagerInfoBll();
        private void LoadList()
        {
            dataGridView1.DataSource = miBll.getManagerInfoList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ManagerInfo> list = miBll.getManagerInfoList();

            HSSFWorkbook workBook = new HSSFWorkbook();
            HSSFCellStyle style = workBook.CreateCellStyle();
            style.Alignment = 2;
            HSSFFont font = workBook.CreateFont();
            font.FontHeightInPoints = 14;
            style.SetFont(font);

            HSSFSheet sheet0 = workBook.CreateSheet("管理员");
            sheet0.AddMergedRegion(new NPOI.HSSF.Util.Region(0, 0, 0, 3));
            HSSFRow row0 = sheet0.CreateRow(0);
            
            HSSFCell cell0 = row0.CreateCell(0);

            cell0.SetCellValue("管理员列表");
            cell0.CellStyle = style;

            HSSFRow row1 = sheet0.CreateRow(1);
            HSSFCell cell = row1.CreateCell(0);
            cell.SetCellValue("编号");
            cell.CellStyle = style;
            HSSFCell cell1= row1.CreateCell(1);
            cell1.SetCellValue("姓名");
            cell1.CellStyle = style;
            HSSFCell cell2 = row1.CreateCell(2);
            cell2.SetCellValue("密码");
            cell2.CellStyle = style;
            HSSFCell cell3 = row1.CreateCell(3);
            cell3.SetCellValue("职位");
            cell3.CellStyle = style;

            int rowIndex = 2;
            foreach (var mi in list)
            {
                HSSFRow row2 = sheet0.CreateRow(rowIndex++);
                HSSFCell cell00 = row2.CreateCell(0);
                cell00.SetCellValue(mi.MId);
                HSSFCell cell01= row2.CreateCell(1);
                cell01.SetCellValue(mi.MName);
                HSSFCell cell02 = row2.CreateCell(2);
                cell02.SetCellValue(mi.MPwd);
                HSSFCell cell03 = row2.CreateCell(3);
                cell03.SetCellValue(mi.MType==0?"经理":"员工");
            }
            using (FileStream stream = new FileStream(@"C:\Users\Administrator\Desktop\t1.xls", FileMode.Create))
            {
                workBook.Write(stream);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ManagerInfo> list = new List<ManagerInfo>();

            using (FileStream stream=new FileStream(@"C:\Users\Administrator\Desktop\t1.xls",FileMode.Open))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(stream);

                HSSFSheet sheet = workbook.GetSheetAt(0);

                int rowIndex = 2;
                HSSFRow row = sheet.GetRow(rowIndex);
                while (row!=null)
                {
                    list.Add(new ManagerInfo()
                    {
                        MId = (int)row.GetCell(0).NumericCellValue,
                        MName=row.GetCell(1).StringCellValue,
                        MPwd=row.GetCell(2).StringCellValue,
                        MType=row.GetCell(3).StringCellValue=="经理"?1:0
                    });
                    rowIndex++;
                    row = sheet.GetRow(rowIndex);
                }
                dataGridView1.DataSource = list;

            }
        }
    }
}
