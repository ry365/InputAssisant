namespace InputAssisant
{
    public class DBEntity辅助输入
    {
        private int _id;
        /// <summary> 
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }

        }


        private int _上级id;
        /// <summary> 
        /// 
        /// </summary>
        public int 上级id
        {
            get { return _上级id; }
            set { _上级id = value; }

        }


        private string _窗体名;
        /// <summary> 
        /// 
        /// </summary>
        public string 窗体名
        {
            get { return _窗体名; }
            set { _窗体名 = value; }

        }


        private string _窗口中文名;
        /// <summary> 
        /// 
        /// </summary>
        public string 窗口中文名
        {
            get { return _窗口中文名; }
            set { _窗口中文名 = value; }

        }


        private string _组件名;
        /// <summary> 
        /// 
        /// </summary>
        public string 组件名
        {
            get { return _组件名; }
            set { _组件名 = value; }

        }


        private string _组件中文名;
        /// <summary> 
        /// 
        /// </summary>
        public string 组件中文名
        {
            get { return _组件中文名; }
            set { _组件中文名 = value; }

        }


        private string _标题;
        /// <summary> 
        /// 
        /// </summary>
        public string 标题
        {
            get { return _标题; }
            set { _标题 = value; }

        }


        private string _编码;
        /// <summary> 
        /// 
        /// </summary>
        public string 编码
        {
            get { return _编码; }
            set { _编码 = value; }

        }


        private string _内容;
        /// <summary> 
        /// 
        /// </summary>
        public string 内容
        {
            get { return _内容; }
            set { _内容 = value; }

        }


        public string GetInsertString()
        {
            string re = string.Format("insert into  字典_提示信息" +
                                      "(id,上级id,窗体名,窗口中文名,组件名," +
                                      "组件中文名,标题,编码,内容 )  values" +
                                      "('{0}','{1}','{2}','{3}','{4}',      " +
                                      "'{5}','{6}','{7}','{8}' ) ",
                Id, 上级id, 窗体名, 窗口中文名, 组件名,
                组件中文名, 标题, 编码, 内容);
            return re;
        }


        public string GetUpdateString()
        {
            string re = string.Format(

                "UPDATE 字典_提示信息 SET " +
                "ID = '{0}',上级ID = '{1}',窗体名 = '{2}',窗口中文名 = '{3}',组件名 = '{4}'," +
                "组件中文名 = '{5}',标题 = '{6}',编码 = '{7}',内容 = '{8}'",
                Id, 上级id, 窗体名, 窗口中文名, 组件名,
                组件中文名, 标题, 编码, 内容
            );
            return re;
        }

        public string GetInsertString(DBEntity辅助输入 db)
        {
            
            string re = string.Format("insert into  字典_提示信息" +
                                      "(id,上级id,窗体名,窗口中文名,组件名," +
                                      "组件中文名,标题,编码,内容 )  values" +
                                      "('{0}','{1}','{2}','{3}','{4}',      " +
                                      "'{5}','{6}','{7}','{8}' ) ",
                db.Id, db.上级id, db.窗体名, db.窗口中文名, db.组件名,
                db.组件中文名, db.标题, db.编码, db.内容);
            return re;
        }

        public string GetUpdateString(DBEntity辅助输入 db)
        {

            string re = string.Format(

                "UPDATE 字典_提示信息 SET " +
                "ID = '{0}',上级ID = '{1}',窗体名 = '{2}',窗口中文名 = '{3}',组件名 = '{4}'," +
                "组件中文名 = '{5}',标题 = '{6}',编码 = '{7}',内容 = '{8}'",
                db.Id, db.上级id, db.窗体名, db.窗口中文名, db.组件名,
                db.组件中文名, db.标题, db.编码, db.内容
            );
            return re;
        }

    }

    public class DataField
    {
        
    }
}
