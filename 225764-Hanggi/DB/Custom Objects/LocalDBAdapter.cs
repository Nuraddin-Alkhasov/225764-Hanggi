using System;
using System.Data;
using System.Data.SQLite;
using HMI.Views.MessageBoxRegion;

namespace HMI.Module
{
    class LocalDBAdapter
    {
        SQLiteConnection Con {get;set;}
        SQLiteCommand Cmd { get; set; }
        SQLiteDataAdapter DA { get; set; }

        string Sql { get; set; }

        public LocalDBAdapter(string _sql)
        {
            Con = new SQLiteConnection("data source=" + (new Resources.LocalResources()).Paths.LocalDB);
            Sql = _sql;
        }
       public bool DB_Input()
        {

            try
            {
                Con.Open();
                Cmd = Con.CreateCommand();
                Cmd.CommandText = Sql;
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception e)
            {
                new MessageBoxTask(e.ToString(), "@DB.Text1",  MessageBoxIcon.Error);
                return false;
            }

        }

        public DataTable DB_Output()
        {
            DataTable DT = new DataTable();
            try
            {
                Con.Open();
                Cmd = Con.CreateCommand();

                DA = new SQLiteDataAdapter(Sql, Con);
                DA.Fill(DT);
                Con.Close();
            }
            catch (Exception e)
            {
                new MessageBoxTask(Sql + Environment.NewLine + "   -   -   -   -" + Environment.NewLine + e.ToString(), "Error", MessageBoxIcon.Error);
            }
            return DT;
        }
    }
}
