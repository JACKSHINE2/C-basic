using System;


/// <summary>
/// 一个简单具体工厂
/// </summary>
namespace Simple_Factory_Pattern
{
    
    //抽象产品类
    public interface ICoat
    {
        void GetYourCoat();
    }

    //具体产品类
    public class BusinessCoat : ICoat
    {
        void GetYourCoat()
        {
            Console.WriteLine("商务外套");
        }
    }

    //具体产品类
    public class FashionCoat : ICoat
    {
        void GetYourCoat()
        {
            Console.WriteLine("时尚外套");
        }
    }

    //一个具体工厂类，返回具体产品
    public class Factory
    {
        public ICoat CreateCoat(string styleName) {
            switch (styleName.Trim().ToLower())
            {
                case "business":
                    {
                        return new BusinessCoat();
                    }
                case "fashion":
                    {
                        return new FashionCoat();
                    }
                default:
                    throw new Exception("还没有你要的那种衣服");
            }
        }
    }

    //客户类 
    public class Client
    {
        static void Main(string[] args)
        {
            ICoat food;
            Factory factory = new Factory();
            food = factory.CreateCoat("fashion");
            food.GetYourCoat();



        }
    }

}
