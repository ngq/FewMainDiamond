using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace FewMainDiamond.App_Start
{
    /// <summary>
    /// autofac进行依赖注入
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 1、负责注册仓储层的所有实现的类对象到业务逻辑层中
        /// 2、负责注册业务逻辑层中的所有类的对象到控制器中
        /// </summary>
        public static void Register()
        {
            try
            {
                //1.0 创建一个autofac的容器对象
                var bulider = new ContainerBuilder();
                //1.0.1 获取程序集载入到Assembly对象中
                Assembly controllerDll = Assembly.Load("FewMainDiamond");
                //1.0.1 告诉autofac对象将来实例化的控制器所存在的程序集是Study.CRM.Site.dll
                bulider.RegisterControllers(controllerDll);//可以添加程序集数组

                #region 2.0 仓储的注册
                //2.0 利用bulider对象开始创建仓储的实现类与对应的仓储接口的对应关系
                //注意：如果加了InstancePerHttpRequest() 每次都是的新的实体进行注入操作

                //注册当个仓储来到其对应的接口
                //bulider.RegisterType(typeof(sysFunctionRepository)).As(typeof(IsysFunctionRepository)).InstancePerHttpRequest();

                //注册程序中所有的类到其实现接口
                //Assembly repositoryAss = Assembly.Load("FewMain.Repository");//获取当前程序集下面的所类型
                //2.1 实例化业务逻辑层的所有类的对象赋值给父接口变量
                bulider.RegisterTypes(Assembly.Load("FewMain.Repository").GetTypes()).AsImplementedInterfaces();

                #endregion

                #region 3.0 业务逻辑层的注册
                //3.0 利用bulider对象开始创建业务逻辑实现类与对应的业务逻辑接口的对象关系
                //单个注册业务逻辑类到其对应的接口
                //bulider.RegisterType(typeof(sysFunctionServices)).As(typeof(IsysFunctionServices)).InstancePerHttpRequest(); 
                //bulider.RegisterType(typeof(sysUserInfoServices)).As(typeof(IsysUserInfoServices)).InstancePerHttpRequest();

                //注册业务逻辑程序中的所有类到其实现的接口(AsImplementedInterfaces() 此方法：就是用来自动转成接口的)
                //4.0 实例化业务逻辑层的所有类的对象赋值给父接口变量
                //Assembly servicesAss = Assembly.Load("FewMain.Service");
                bulider.RegisterTypes(Assembly.Load("FewMain.Service").GetTypes()).AsImplementedInterfaces();

                //注册当前程序中类型名称的前缀为sysFunction 的所对应类的实例
                //bulider.RegisterTypes(servicesAss.GetTypes().Where(c => c.Name.StartsWith("sysFunction")).ToArray()).AsImplementedInterfaces();

                #endregion

                //4.0 告诉MVC框架将来所有控制器的对象的创建工作交给autofac.dll中的控制器工厂来完成
                //特点：会利用控制器中的有参数构造函数创建其对象，同时在创建的过程中，会根据构造函数中的
                //接口参数，将此接口的具体实现类的对象注入
                //4.0.1  根据已经注册好的组建创建此容器对象中所有的映射关系的具体实现
                var container = bulider.Build();

                // 4.0.2 将MVC的控制器对象实例 交由autofac来创建
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
            catch (Exception ex)
            {
                
                throw;
            }
            

        }
    }
}
