using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using FluentNHibernate.Mapping;

namespace Tzj.Domain.Core.Map
{
    /// <summary>
    /// 表的映射基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseMap<T> : ClassMap<T> where T : class
    {
        protected BaseMap()
        {
            DynamicInsert();
            DynamicUpdate();
        }
    }

    /// <summary>
    /// 带OMS.前缀
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OmsBaseMap<T> : ClassMap<T> where T : class
    {
        protected OmsBaseMap()
        {
            Schema("OMS");
            DynamicInsert();
            DynamicUpdate();
        }
    }


    /// <summary>
    /// 视图的映射基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewBaseMap<T> : ClassMap<T> where T : class
    {
        protected ViewBaseMap()
        {
            ReadOnly();
        }
    }

    /// <summary>
    /// 带OMS.前缀
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OmsViewBaseMap<T> : ClassMap<T> where T : class
    {
        protected OmsViewBaseMap()
        {
            Schema("OMS");
            ReadOnly();
        }
    }



}
