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
    public class CDM_Don_Vi_Tinh_Controller
    {
        private void MapDM_Don_Vi_Tinh(DataRow p_row, CDM_Don_Vi_Tinh p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ten_Don_Vi_Tinh"))
                p_objDes.Ten_Don_Vi_Tinh = CUtility.Convert_To_String(p_row["Ten_Don_Vi_Tinh"]);

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

        public IList<CDM_Don_Vi_Tinh> List_DM_Don_Vi_Tinh()
        {
            IList<CDM_Don_Vi_Tinh> v_arrRes = new List<CDM_Don_Vi_Tinh>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_List_DM_Don_Vi_Tinh");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CDM_Don_Vi_Tinh v_objRes = new CDM_Don_Vi_Tinh();
                    MapDM_Don_Vi_Tinh(v_row, v_objRes);
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

        public CDM_Don_Vi_Tinh Get_DM_Don_Vi_Tinh_By_ID(int p_iID)
        {
            CDM_Don_Vi_Tinh v_objRes = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_Get_DM_Don_Vi_Tinh_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objRes = new CDM_Don_Vi_Tinh();
                    MapDM_Don_Vi_Tinh(v_dt.Rows[0], v_objRes);
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

        public int Insert_DM_Don_Vi_Tinh(CDM_Don_Vi_Tinh p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_ins_DM_Don_Vi_Tinh",
                    p_objData.Ten_Don_Vi_Tinh, p_objData.Last_Updated_By));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return v_iRes;
        }

        public void Update_DM_Don_Vi_Tinh(CDM_Don_Vi_Tinh p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_upd_DM_Don_Vi_Tinh", p_objData.Auto_ID,
                    p_objData.Ten_Don_Vi_Tinh, p_objData.Last_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_DM_Don_Vi_Tinh(int p_iAuto_ID, string p_strLast_Updated_By)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_del_DM_Don_Vi_Tinh", p_iAuto_ID, p_strLast_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
