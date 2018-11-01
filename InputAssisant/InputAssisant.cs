using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace InputAssisant
{
    public class InputAssisant
    {
        
        public class InputAssitant
        {
            private readonly ContextMenuStrip popMenu;
            private string tagName = "";
            public event EventHandler ShowAddNewItem;
            public event EventHandler MenuItemClick;
            public DataTable dt;
            public InputAssitant(EventHandler ItemAddClick)
            {
                popMenu = new ContextMenuStrip();
                this.ShowAddNewItem += AssistantInputAddClick;
                MenuItemClick += ItemAddClick;
            }

            private void fillNextLevel(string conidtion, int ID, ToolStripMenuItem ParentMenuItem, DataTable dt,
                EventHandler click, object sander)
            {
                DataRow[] dr;

                dr = dt.Select(conidtion + "' and parentID = '" + ID + "'");

                for (int i = 0; i < dr.Length; i++)
                {
                    var aa = new ToolStripMenuItem();
                    aa.Text = dr[i]["LevelVaule"].ToString();
                    aa.Tag = sander;
                    aa.Click += click;
                    ParentMenuItem.DropDownItems.Add(aa);
                    ParentMenuItem.Click -= click;
                    fillNextLevel(conidtion, Convert.ToInt32(dr[i]["dbBindID"]), aa, dt, click, sander);
                }
            }

            public void FillMenuStripEx(ContextMenuStrip contextMenu,
                DataTable dt, string colName, string condition,
                EventHandler click, EventHandler AddClick, object sander)
            {
                contextMenu.Items.Clear();
                //未找到formName

                DataRow[] dr;

                string str = condition;
                dr = dt.Select(str);

                //ToolStripMenuItem level1 = new ToolStripMenuItem();

                for (int i = 0; i < dr.Length; i++)
                {
                    var level1 = new ToolStripMenuItem();
                    level1.Text = dr[i][colName].ToString();
                    level1.Tag = sander;
                    level1.Click += click;
                    contextMenu.Items.Add(level1);
                }
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="contextMenu"></param>
            /// <param name="dt"></param>
            /// <param name="formName"></param>
            /// <param name="btnName"></param>
            /// <param name="click"></param>
            /// <param name="AddClick"></param>
            /// <param name="sander"></param>
            public void FillMenuStrip(ContextMenuStrip contextMenu,
                DataTable dt, string formName, string btnName, EventHandler click,
                EventHandler AddClick, object sander)
            {
                contextMenu.Items.Clear();
                //未找到formName
                DataRow[] dr;

                string str = "FORMNAME = '" + formName + "' and btnTagName = '" + btnName + "' and parentID = '" + "0" + "'";
                dr = dt.Select(str);

                //ToolStripMenuItem level1 = new ToolStripMenuItem();

                for (int i = 0; i < dr.Length; i++)
                {
                    var level1 = new ToolStripMenuItem();
                    level1.Text = dr[i]["LevelVaule"].ToString();
                    level1.Tag = sander;
                    level1.Click += click;
                    contextMenu.Items.Add(level1);
                    fillNextLevel("formName = '" + formName + "'and btnTagName = '" + btnName,
                        Convert.ToInt32(dr[i]["dbBindID"]), level1, dt, click, sander);
                }

                if (ShowAddNewItem != null)
                {
                    contextMenu.Items.Add("-");
                    var AddNew = new ToolStripMenuItem();
                    AddNew.Tag = sander;
                    AddNew.Text = "添加新项";
                    AddNew.Name = "添加新项";
                    AddNew.Click += AddClick;
                    contextMenu.Items.Add(AddNew);
                }
            }


            private void AssistantInputAddClick(object sender, EventArgs e)
            {
                
                var str = (sender as string);
                if (str != null)
                {
                    string ctlName = str.Split('|')[1];
                    string winName = str.Split('|')[0];
                    ADUWords Add = new ADUWords(dt, winName, ctlName);
                    Add.ShowDialog();
                }
            }

            public void ShowPopMenuAssistantEx(object sender, string colName, string condition,
                DataTable ds, Control menuParent)
            {
                var btn = sender as Control;
                if (btn == null) return;

                FillMenuStripEx(popMenu, ds, colName, condition, MenuItemClick, MenuItemAddClick, btn);

                popMenu.Show(btn, new Point(btn.Width, 0));
            }

            public void ShowPopMenuAssistant(object sender, string formName, string controlTitle, DataTable ds,
                Control menuParent)
            {
                var btn = sender as Control;
                if (btn == null) return;

                tagName = formName + '|' + controlTitle;
                // Point p = new Point(btn.Width + btn.Left, btn.Top);
                //   p = btn.PointToScreen(p);
                FillMenuStrip(popMenu, ds, formName, controlTitle, MenuItemClick, MenuItemAddClick, btn);

                popMenu.Show(btn, new Point(btn.Width, 0));
            }

            //private void MenuItemClick(object sender, EventArgs e)
            //{
            //    var aa = (ToolStripMenuItem) sender;
            //    // DevExpress.XtraEditors.ButtonEdit bb = (DevExpress.XtraEditors.ButtonEdit)aa.Tag;

            //    // bb.Text = aa.Text;
            //}

            private void MenuItemAddClick(object sender, EventArgs e)
            {
                if (ShowAddNewItem != null)
                    ShowAddNewItem(tagName, e);
            }
        }
    }
}
