﻿using CoreDapperCommon.CommonMethod;
using CoreDapperHelp.DapperHelp;
using CoreDapperModel.CommonModel;
using Dapper;
using System;
using System.Collections.Generic;

namespace CoreDapperDAL.BaseDAL
{
    /// <summary>
    /// 公共数据访问层
    /// </summary>
    public class BaseDAL
    {
        DapperHelps dapperHelps = new DapperHelps();

        #region 增

        /// <summary>
        /// 新增操(主键为Int类型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public long InsertModelInt<T>(T model) where T : class
        {
            try
            {
                if (model == null)
                {
                    return 0;
                }
                var id = dapperHelps.ExecuteInsert<T>(model);
                return id;
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                return 0;
            }
        }

        /// <summary>
        /// 新增操作(主键为Guid)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertModelGuid<T>(T model) where T : class
        {
            try
            {
                if (model == null)
                {
                    return String.Empty;
                }
                var id = dapperHelps.ExecuteInsertGuid<T>(model);
                return id;
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                return String.Empty;
            }
        }

        /// <summary>
        /// 添加集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool InsertList<T>(List<T> modelList) where T : class
        {
            try
            {
                if (modelList.Count <= 0)
                {
                    return false;
                }
                dapperHelps.ExecuteInsertList<T>(modelList);
                return true;
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                return false;
            }
        }

        #endregion

        #region 删

        /// <summary>
        /// 根据主键删除(主键为int类型)
        /// </summary>
        /// <param name="array">删除主键数组集合</param>
        /// <returns></returns>
        public bool DeleteIntId<T>(int[] array)
        {
            if (array.Length <= 0)
            {
                return false;
            }

            string sqlstr = string.Format("DELETE {0} WHERE Id in @ID ", typeof(T).Name.ToString());
            var result = dapperHelps.ExecuteSqlInt(sqlstr, new { ID = array });
            return result > 0;
        }

        /// <summary>
        /// 根据主键删除(主键为GUID类型)
        /// </summary>
        /// <param name="array">删除主键数组集合</param>
        /// <returns></returns>
        public bool DeleteStringId<T>(string[] array)
        {
            if (array.Length <= 0)
            {
                return false;
            }
            string sqlstr = string.Format("DELETE {0} WHERE Id in @ID ", typeof(T).Name.ToString());
            var result = dapperHelps.ExecuteSqlInt(sqlstr, new { ID = array });
            return result > 0;
        }

        /// <summary>
        /// 根据主键删除(主键为GUID类型)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteStringId<T>(string Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                return false;
            }
            string sqlstr = string.Format("DELETE {0} WHERE Id = @ID ", typeof(T).Name.ToString());
            var result = dapperHelps.ExecuteSqlInt(sqlstr, new { ID = Id });
            return result > 0;
        }

        #endregion

        #region 改

        /// <summary>
        /// 修改单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateModel<T>(T model) where T : class
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                return dapperHelps.UpdateModel<T>(model);
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                return false;
            }
        }

        /// <summary>
        /// 批量更新实体,返回更新状态
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <returns></returns>
        public bool UpdateList<T>(List<T> List) where T : class
        {
            try
            {
                if (List.Count <= 0)
                {
                    return false;
                }
                return dapperHelps.ExecuteUpdateList<T>(List);
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                return false;
            }
        }

        /// <summary>
        /// 批量修改返回成功和失败的条数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <param name="ErrorCount"></param>
        /// <returns></returns>
        public int UpdateList<T>(List<T> List, out int ErrorCount) where T : class
        {
            try
            {
                if (List.Count <= 0)
                {
                    ErrorCount = 0;
                    return 0;
                }
                return dapperHelps.ExecuteUpdateList<T>(List, out ErrorCount);
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                ErrorCount = 0;
                return 0;
            }
        }

        /// <summary>
        /// 修改功能(sql语句修改)
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public int Update(string sqlStr)
        {
            try
            {
                return dapperHelps.ExecuteSqlInt(sqlStr);
            }
            catch (Exception ex)
            {
                WriteLogMethod.WriteLogs(ex);
                return 0;
            }
        }

        #endregion

        #region 查

        /// <summary>
        /// 通过主键查询实体(int类型主键)
        /// </summary>
        /// <typeparam name="T">泛型实体类</typeparam>
        /// <param name="Id">主键id</param>
        /// <returns></returns>
        public T GetModelById<T>(int Id) where T : class
        {
            string sqlstr = string.Format("select * from {0} where Id=@ID", typeof(T).Name.ToString());
            return dapperHelps.ExecuteReaderReturnT<T>(sqlstr, new { ID = Id });
        }

        /// <summary>
        /// 通过主键查询实体(GUID类型主键)
        /// </summary>
        /// <typeparam name="T">泛型实体类</typeparam>
        /// <param name="Id">主键id</param>
        /// <returns></returns>
        /// 
        public T GetModelById<T>(string Id) where T : class
        {
            string sqlstr = string.Format("select * from {0} where Id=@ID", typeof(T).Name.ToString());
            return dapperHelps.ExecuteReaderReturnT<T>(sqlstr, new { ID = Id });
        }

        /// <summary>
        /// 获取单个实体(sql语句查)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public T GetModel<T>(string sqlStr, string orderbystr = null, object parameter = null)
        {
            if (!String.IsNullOrEmpty(orderbystr))
            {
                sqlStr += orderbystr;
            }
            return dapperHelps.ExecuteReaderReturnT<T>(sqlStr, parameter);
        }

        /// <summary>
        /// 获取单个实体(所有字段)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereStr"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public T GetModelAll<T>(string whereStr, object parameter)
        {
            string sqlstr = string.Format("select * from {0} where {1}", typeof(T).Name.ToString(), whereStr);

            return dapperHelps.ExecuteReaderReturnT<T>(sqlstr, parameter);
        }

        /// <summary>
        /// 获取集合对象(in查询方式,根据业务需要使用必要时需要手动分页查询)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereArry"></param>
        /// <returns></returns>
        public List<T> GetListByIn<T>(string[] whereArry)
        {
            string sqlstr = string.Format("select * from {0} where GuId in @Arry", typeof(T).Name.ToString());
            return dapperHelps.ExecuteReaderReturnList<T>(sqlstr, new { Arry = whereArry });
        }

        /// <summary>
        /// 获取集合对象(sql语句查询)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string sqlStr, string orderbystr = null, object parameter = null)
        {
            if (!String.IsNullOrEmpty(orderbystr))
            {
                sqlStr = "order by" + orderbystr;
            }
            return dapperHelps.ExecuteReaderReturnList<T>(sqlStr, parameter);
        }

        /// <summary>
        /// 获取集合对象(所有字段)
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="whereStr">查询条件</param>
        /// <param name="orderByStr">排序条件</param>
        /// <returns></returns>
        public List<T> GetListAll<T>(string whereStr, string orderbystr = null, object parameter = null)
        {
            string sqlstr = string.Format("select * from {0} where {1} order by {2}", typeof(T).Name.ToString(), whereStr, orderbystr == null ? "Id" : orderbystr);

            return dapperHelps.ExecuteReaderReturnList<T>(sqlstr, parameter);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="wherestr">查询条件</param>
        /// <param name="orderbystr">排序条件</param>
        /// <param name="parametersp">参数</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="curPage">第几页</param>
        /// <param name="count">总行数</param>
        /// <returns></returns>
        public List<T> GetPageList<T>(string wherestr, PageModel pageModel, string orderbystr = null)
        {
            DynamicParameters parametersp = new DynamicParameters();
            string orderby = String.Empty;
            if (String.IsNullOrEmpty(orderbystr))
            {
                orderby = " ORDER BY AddTime DESC ";
            }
            else
            {
                orderby = $@" ORDER BY {orderbystr} DESC ";
            }

            string sqlpage = "SELECT * FROM (SELECT A.*, ROW_NUMBER() OVER ({0}) rownum FROM {2} as A  where {1} ) Z WHERE Z.rownum > @start AND Z.rownum<= @end ORDER BY Z.rownum";
            string countSql = "select count(1) from {0} where {1}";

            parametersp.Add("@start", (pageModel.curPage - 1) * pageModel.pageSize);
            parametersp.Add("@end", pageModel.curPage * pageModel.pageSize);

            pageModel.count = dapperHelps.ExecuteReaderReturnT<int>(string.Format(countSql, typeof(T).Name.ToString(), wherestr), parametersp);

            string sql = string.Format(sqlpage, orderby, wherestr, typeof(T).Name.ToString());
            var list = dapperHelps.ExecuteReaderReturnList<T>(sql, parametersp);
            return list;
        }

        /// <summary>
        /// 连接查询分页方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlstr"></param>
        /// <param name="pageModel"></param>
        /// <param name="orderbystr">排序条件需要带表名</param>
        /// <returns></returns>
        public List<T> GetPageJoinList<T>(string sqlstr, PageModel pageModel, string orderbystr = null)
        {
            DynamicParameters parametersp = new DynamicParameters();
            List<T> List = new List<T>();
            string numberStr = String.Empty;

            pageModel.count = dapperHelps.ExecuteReaderReturnList<T>(sqlstr, pageModel).Count;

            string sqlpage = string.Format("SELECT * FROM ( {0}) Z WHERE Z.rownum > @start AND Z.rownum<= @end ORDER BY Z.rownum", sqlstr);

            pageModel.start = (pageModel.curPage - 1) * pageModel.pageSize;
            pageModel.end = pageModel.curPage * pageModel.pageSize;

            List = dapperHelps.ExecuteReaderReturnList<T>(sqlpage, pageModel);
            return List;
        }

        #endregion

    }
}
