using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputAssisant
{
    public partial class ADUWords : Form
    {
        public string TreeBtnName = "";
        public string TreefrmName = "";
        string SaveFlag = "";
        public string formName;
        public string buttonName;



        public event EventHandler DelTreeItemEvent;
        public event EventHandler AddTreeItemEvent;
        public event EventHandler UpdateTreeItemEvent;

        public ADUWords(DataTable dt,string mFormname,string mButtonName)
        {
            formName = mFormname;
            buttonName = mButtonName;

            InitializeComponent();
            FillTree(null,dt,"0");

        }

        


        private void FillTree(TreeNode mtn,DataTable dt,string 上级ID)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format(" 窗体名='{0}' and 组件名='{1}' and 上级ID={2}",formName,buttonName, 上级ID);
            TreeNode tn;

            if (mtn == null)
            {
                tn = treeView1.Nodes["root"];
                tn.Text = formName + "/" + buttonName;
            }
            else
            {
                tn = mtn;
            }

            foreach (DataRow dr in dv.Table.Rows)
            {
                TreeNode stn = new TreeNode();
                string tName = dr["标题"].ToString();
                stn.Text = tName;
                stn.Tag = dr;

                tn.Nodes.Add(stn);

                FillTree(stn,dt,dr["上级ID"].ToString());
            }
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addItem_Click(object sender, EventArgs e)
        {
            SaveFlag = "Add";
            edtTitile.Text = "";
            edtCode.Text = "";
            edtContext.Text = "";
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SaveFlag = "Update";

            DBEntity辅助输入 d = e.Node.Tag as DBEntity辅助输入;
            edtTitile.Text = d.标题;
            edtCode.Text = d.编码;
            edtContext.Text = d.内容;

        }

        private void itemDel_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Remove(treeView1.SelectedNode);
            if (DelTreeItemEvent != null)
                DelTreeItemEvent(treeView1.SelectedNode.Tag,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SaveFlag == "Add")
            {


                if (AddTreeItemEvent != null)
                    AddTreeItemEvent(treeView1.SelectedNode.Tag, e);
            }
            if (SaveFlag == "Update")
            {
                DBEntity辅助输入 d = treeView1.SelectedNode.Tag as DBEntity辅助输入;
                d.标题 = edtTitile.Text;
                d.编码 = edtCode.Text;
                d.内容 = edtContext.Text;

                treeView1.SelectedNode.Text = d.标题;

                if (UpdateTreeItemEvent != null)
                    UpdateTreeItemEvent(treeView1.SelectedNode.Tag, e);
            }
        }

        private void ADUWords_Load(object sender, EventArgs e)
        {
            
        }
    }
}
