using System;


/// <summary>
/// 抽象工厂创建多类产品，可将这些产品理解为一套相关的产品，由工厂在创建时一起创建，每类产品有不同的实例
/// </summary>
namespace AbstractFactory
{
    
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class ClothesFactory
    {
        public abstract AbstractCoat CreateCoat();
        public abstract   AbstractPants CreatePants();
    }

    /// <summary>
    /// 抽象上衣外套类
    /// </summary>
    public abstract class AbstractCoat
    {
        public abstract bool isMale { get; }
        public abstract string Style { get; }
    }

    /// <summary>
    /// 抽象裤子类
    /// </summary>
    public abstract class AbstractPants
    {
        public abstract bool isMale { get; }
        public abstract string Style { get; }
    }


    /// <summary>
    /// 具体工厂角色
    /// </summary>
    
     //时尚男装
    public class FashionMaleClothes : ClothesFactory
    {
        public override AbstractCoat CreateCoat()
        {
            return new MaleCoat();
        }

        public override AbstractPants CreatePants()
        {
            return new MalePants();
        }
    }

    //时尚女装
    public class FashionFemaleClothes : ClothesFactory
    {
        public override AbstractCoat CreateCoat()
        {
            return new FemaleCoat();
        }

        public override AbstractPants CreatePants()
        {
            return new FemalePants();
        }
    }
    
    /// <summary>
    /// 具体产品
    /// </summary>
    
    //时尚男上衣
    public class MaleCoat : AbstractCoat
    {
        private bool ismale = true;
        private string style = "fashion";
        public override bool isMale { get { return ismale; } }
        public override string Style { get { return style; } }
    }
    //老旧男酷
    public class MalePants : AbstractPants
    {
        private bool ismale = true;
        private string style = "old";
        public override bool isMale { get { return ismale; } }
        public override string Style { get { return style; } }
    }

    //时尚女上衣
    public class FemaleCoat : AbstractCoat
    {
        private bool ismale = false;
        private string style = "fashion";
        public override bool isMale { get { return ismale; } }
        public override string Style { get { return style; } }
    }

    //老旧女裤
    public class FemalePants : AbstractPants
    {
        private bool ismale = false;
        private string style = "old";
        public override bool isMale { get { return ismale; } }
        public override string Style { get { return style; } }
    }

    /// <summary>
    /// 客户端
    /// </summary>
    public class CreateClothes
    {
        private AbstractCoat myCoat;
        private AbstractPants myPants;
        public CreateClothes(ClothesFactory clothes)
        {
            myCoat = clothes.CreateCoat();
            myPants = clothes.CreatePants();
        }

        public void ShowMyClothes()
        { }

    }

    //具体实现
    public class Client
    {
        static void Main(string[] args)
        {
            ClothesFactory factory = new FashionMaleClothes();
            CreateClothes clothes = new CreateClothes(factory);
            clothes.ShowMyClothes();
        }
    }





}
