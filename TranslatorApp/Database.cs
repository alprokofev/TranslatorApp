using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TranslatorApp
{
    class Database
    {
        private SQLiteConnection m_dbConn;

        public Database(string dbFileName)
        {
            if (!File.Exists(dbFileName))
                return;

            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
        }

        private bool Open()
        {
            try
            {
                if (m_dbConn != null && m_dbConn.State != ConnectionState.Open)
                    m_dbConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void Close()
        {
            try
            {
                if (m_dbConn != null && m_dbConn.State == ConnectionState.Open)
                    m_dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public List<Language> GetLanguages()
        {
            try
            {
                if (!Open())
                    return null;

                DataTable dTable = new DataTable();
                string sqlQuery = "select * from tblLanguages";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                List<Language> list = new List<Language>();
                if (dTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dTable.Rows.Count; i++)
                        list.Add(new Language(dTable.Rows[i].ItemArray[0].ToString(),
                            dTable.Rows[i].ItemArray[1].ToString()));
                }                
                return list;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Close();
            }
            return null;
        }
    }
}