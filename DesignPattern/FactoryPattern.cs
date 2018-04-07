

using System;


/* 参与者  
*  抽象产品角色（Product）  定义产品的接口 
*  具体产品角色（ConcreteProduct）   实现接口Product的具体产品类 
*  抽象工厂角色（Creator）   声明工厂方法（FactoryMethod），返回一个产品 
*  具体的工厂（ConcreteCreator）  实现FactoryMethod工厂方法，由客户调用，返回一个产品的实例
*/

/// <summary>
/// 抽象工厂和产品，抽象工厂类中仅创建此抽象产品类的实例，具体产品实例由具体的工厂类创建
/// </summary>
namespace FactoryPattern
{
    /// <summary>
    /// 抽象工厂类，定义产品的接口
    /// </summary>
    public interface IFactory
    {
        ICoat CreateCoat();
    }


    /// <summary>
    /// 抽象产品类
    /// </summary>
    public interface ICoat
    {
        void ShowCoat();
    }

    /// <summary>
    /// 具体工厂类
    /// </summary>
    public class BusinessFactory : IFactory
    {
      
        public  ICoat CreateCoat()
        {
            return new BusinessCoat();

        }
    }

    public class FashionFactory : IFactory
    {
        public  ICoat CreateCoat()
        {
            return new FashionCoat();
        }
    }


    /// <summary>
    /// 具体产品类
    /// </summary>
    public class FashionCoat : ICoat
    {
        public  void ShowCoat()
        {
            Console.WriteLine("时尚外套");
        }
    }

    public class BusinessCoat : ICoat
    {
        public  void ShowCoat()
        {
            Console.WriteLine("商务外套");
        }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class Client
    {
        static void Main(string[] args)
        {
            IFactory factory = new BusinessFactory();
            ICoat coat = factory.CreateCoat();
            coat.ShowCoat();
        }
    }






}


    


 



