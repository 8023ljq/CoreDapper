/*
*┌────────────────────────────────────────────────┐
*│　描    述：TextBLL                                                    
*│　作    者：GeekLiu                                              
*│　版    本：1.0                                              
*│　创建时间：2020/6/8 17:42:09                        
*└────────────────────────────────────────────────┘
*/

using CoreDapperCommon.CommonMethod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CoreDapperModel.CommonModel;
using CoreDapperModel.DBModel;
using CoreDapperCommon.CommonEnum;

namespace CoreDapperBLL.TextBLL
{
    public class TextBLL : BaseBLL
    {
        #region 测试操作

        /// <summary>
        /// 获取菜单分页列表
        /// </summary>
        /// <returns></returns>
        public ResultMsg GetMenuPageList()
        {
            PageModel pageModel = new PageModel();
            pageModel.pageSize = 10;
            pageModel.curPage = 1;

            List<Sys_Menu> menuList = baseDAL.GetPageList<Sys_Menu>("1=1", pageModel);

            return ReturnHelpMethod.ReturnSuccess((int)HttpCodeEnum.Http_1001, menuList, pageModel.count);
        }

        /// <summary>
        /// 测试单表添加5000条数据
        /// </summary>
        /// <returns></returns>
        public ResultMsg AddListAct(int Count)
        {
            List<Sys_Menu> MenuList = new List<Sys_Menu>();

            Stopwatch sw = new Stopwatch();

            // 开始测量代码运行时间
            sw.Start();

            for (int i = 0; i < Count; i++)
            {
                MenuList.Add(new Sys_Menu
                {
                    GuId = Guid.NewGuid().ToString(),
                    ParentId = "0",
                    FullName = "测试菜单数据" + i.ToString(),
                    Layers = 1 + i,
                    IconUrl = "",
                    Sort = 100 + i,
                    IsShow = false,
                    IsDefault = false,
                    AddTime = DateTime.Now,
                    AddUserId = Guid.NewGuid().ToString(),
                    UpdateTime = DateTime.Now,
                    IsDelete = false,
                });
            }

            // 结束测量
            sw.Stop();

            Stopwatch sws = new Stopwatch();

            // 开始测量代码运行时间
            sws.Start();

            bool bo = baseDAL.InsertList(MenuList);

            // 结束测量
            sws.Stop();

            return ReturnHelpMethod.ReturnSuccess((int)HttpCodeEnum.Http_200, new { bo = bo, A = sw.Elapsed, B = sws.Elapsed });

            //Sys_Menu menuModel = new Sys_Menu
            //{
            //    GuId = Guid.NewGuid().ToString(),
            //    ParentId = "0",
            //    FullName = "测试菜单数据",
            //    Layers = 1,
            //    IconUrl = "",
            //    Sort = 100,
            //    IsShow = false,
            //    IsDefault = false,
            //    AddTime = DateTime.Now,
            //    AddUserId= Guid.NewGuid().ToString(),
            //    UpdateTime = DateTime.Now,
            //    IsDelete = false,
            //};

            //var bo = baseDAL.InsertModelInt(menuModel);

            //return ReturnHelpMethod.ReturnSuccess((int)HttpCodeEnum.Http_200, new { bo = bo });

        }

        #endregion
    }
}
