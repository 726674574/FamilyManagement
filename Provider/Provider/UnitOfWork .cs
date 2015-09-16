﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Provider.Util;
using System.Data;
using System.Data.Entity;


namespace Provider.Provider
{
   public  class UnitOfWork:IUnitOfWork
    {

       private AccountContext Content;
       public UnitOfWork(AccountContext content)
       {
           this.Content = content;
       }


        /// <summary>
        /// 启动标识
        /// </summary>
       public bool IsStart
       {
           get;
           set;
       }



       /// <summary>
       /// 启动
       /// </summary>
       public void Start()
       {
           IsStart = true;
       }

       /// <summary>
       /// 提交更新
       /// </summary>
       public void Save()
       {

           try
           {
              Content.SaveChanges();
           }
           finally
           {
               IsStart = false;
           }
       }


       /// <summary>
       /// 通过启动标识执行提交，如果已启动，则不提交
       /// </summary>
       public void SaveByStart()
       {
           if (IsStart)
               return;
           Save();
       }
    }
}
