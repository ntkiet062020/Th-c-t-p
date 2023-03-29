﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Entity.Danh_Muc;

namespace TKS_Thuc_Tap_Controller.Danh_Muc
{
    public class CDM_Mau_Column_Controller
    {
        private void MapDM_Mau_Column(DataRow p_row, CDM_Mau_Column p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Field_Name"))
                p_objDes.Field_Name = CUtility.Convert_To_String(p_row["Field_Name"]);

            if (p_dt.Columns.Contains("Ma_So_Mau"))
                p_objDes.Ma_So_Mau = CUtility.Convert_To_String(p_row["Ma_So_Mau"]);

            if (p_dt.Columns.Contains("deleted"))
                p_objDes.deleted = CUtility.Convert_To_Int32(p_row["deleted"]);

            if (p_dt.Columns.Contains("Created"))
                p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            if (p_dt.Columns.Contains("Created_By"))
                p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);
        }

        public IList<CDM_Mau_Column> List_DM_Mau_Column()
        {
            IList<CDM_Mau_Column> v_arrRes = new List<CDM_Mau_Column>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_List_DM_Mau_Column");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CDM_Mau_Column v_objRes = new CDM_Mau_Column();
                    MapDM_Mau_Column(v_row, v_objRes);
                    v_arrRes.Add(v_objRes);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                v_dt.Dispose();
            }

            return v_arrRes;
        }

        public CDM_Mau_Column Get_DM_Mau_Column_By_ID(int p_iID)
        {
            CDM_Mau_Column v_objRes = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_Get_DM_Mau_Column_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objRes = new CDM_Mau_Column();
                    MapDM_Mau_Column(v_dt.Rows[0], v_objRes);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                v_dt.Dispose();
            }

            return v_objRes;
        }

        public int Insert_DM_Mau_Column(CDM_Mau_Column p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_ins_DM_Mau_Column",
                    p_objData.Field_Name, p_objData.Ma_So_Mau, p_objData.Last_Updated_By));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return v_iRes;
        }

        public void Update_DM_Mau_Column(CDM_Mau_Column p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_upd_DM_Mau_Column", p_objData.Auto_ID,
                    p_objData.Field_Name, p_objData.Ma_So_Mau, p_objData.Last_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_DM_Mau_Column(int p_iAuto_ID, string p_strLast_Updated_By)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_del_DM_Mau_Column", p_iAuto_ID, p_strLast_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
