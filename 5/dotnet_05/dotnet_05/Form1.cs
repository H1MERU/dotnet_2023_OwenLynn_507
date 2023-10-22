using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_05
{
    public partial class Form1 : Form
    {

        private readonly List<string> linksToOpen = new List<string>();
        private readonly object linksLock = new object();
        private bool cellClickHandlerAttached = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Search_Click(object sender, EventArgs e)
        {
            Result.Instance().Reset();
            Filter.Instance().Refresh(checkFileTypes);
            string keyword = searchBox.Text.Trim();
            CrawlerCore gutern = new Crawler_guternburg(keyword);
            CrawlerCore.Run(gutern);
            Display();
        }

        public void Display()
        {
            InitializeColumns();
            SetupCellFormatting();

            if (!cellClickHandlerAttached)
            {
                SetupCellClickHandling();
                cellClickHandlerAttached = true;
            }

            StartLinkOpeningThread();
            PopulateData();
        }

        private void InitializeColumns()
        {
            bookResult.Columns.Clear();

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "书名";
            bookResult.Columns.Add(column1);

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "作者";
            bookResult.Columns.Add(column2);

            List<List<string>> list = new List<List<string>>();
            int col = 0;

            foreach (string type in Filter.Instance().types)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = type;
                bookResult.Columns.Add(column);
                list.Add(Result.Instance().GetListByName(type));
                col++;
            }
        }

        private void SetupCellFormatting()
        {
            bookResult.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex > 1)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                    e.CellStyle.Font = new System.Drawing.Font(bookResult.Font, System.Drawing.FontStyle.Underline);
                }
            };
        }

        private void SetupCellClickHandling()
        {
            bookResult.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 1)
                {
                    DataGridViewCell selectedCell = bookResult.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (selectedCell.Value != null)
                    {
                        string cellValue = selectedCell.Value.ToString();
                        HandleLinkClick(cellValue);
                    }
                }
            };
        }

        private void HandleLinkClick(string link)
        {
            lock (linksLock)
            {
                linksToOpen.Add(link);
            }
        }

        private void StartLinkOpeningThread()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    string linkToOpen = null;
                    lock (linksLock)
                    {
                        if (linksToOpen.Count > 0)
                        {
                            linkToOpen = linksToOpen[0];
                            linksToOpen.RemoveAt(0);
                        }
                    }

                    if (linkToOpen != null)
                    {
                        System.Diagnostics.Process.Start(linkToOpen);
                    }
                }
            });
        }

        private void PopulateData()
        {
            int col = Filter.Instance().types.Count;
            List<List<string>> typeLists = Filter.Instance().types.Select(type => Result.Instance().GetListByName(type)).ToList();

            for (int i = 0; i < Result.Instance().GetListByName("names").Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(bookResult);
                row.Cells[0].Value = Result.Instance().GetEleByNameIndex("names", i);
                row.Cells[1].Value = Result.Instance().GetEleByNameIndex("authors", i);

                for (int j = 0; j < col; j++)
                {
                    row.Cells[j + 2].Value = typeLists[j][i];
                }

                bookResult.Rows.Add(row);
            }
        }

    }
}
