using System;

/// <summary>
/// 中介者模式，定义了一个中介对象来封装一系列对象之间的交互关系
/// 中介者使各个对象之间不需要显式地相互引用，从而使耦合性降低，而且可以独立地改变它们之间的交互行为
/// </summary>
//英雄联盟中两个玩家之间的相互攻击，会造成双方的HP的改变

namespace Mediator
{
    /// <summary>  
    /// 抽象玩家类  
    /// </summary>  
    public abstract class AbstractPlayer
    {
        /// <summary>  
        /// 玩家生命值  
        /// </summary>  
        public double HP { get; set; }

        /// <summary>  
        /// 遭受攻击时候，生命值减少，对应攻击者的HP增加  
        /// </summary>  
        /// <param name="num"></param>  
        /// <param name="Mediator"></param>  
        public abstract void ChangeHP(int num, AbstractMediator Mediator);
    }

    /// <summary>  
    /// 中介者抽象类  
    /// </summary>  
    public abstract class AbstractMediator
    {
        protected AbstractPlayer A;
        protected AbstractPlayer B;

        public AbstractMediator(AbstractPlayer a, AbstractPlayer b)
        {
            A = a;
            B = b;
        }

        /// <summary>  
        /// A被B攻击  
        /// </summary>  
        /// <param name="num"></param>  
        public abstract void AEmbattled(int num);

        /// <summary>  
        /// B被A攻击  
        /// </summary>  
        /// <param name="num"></param>  
        public abstract void BEmbattled(int num);
    }

    /// <summary>  
    /// 具体中介者  
    /// </summary>  
    public class MediatorPater : AbstractMediator
    {
        private AbstractPlayer a;
        private AbstractPlayer b;

        public MediatorPater(AbstractPlayer a, AbstractPlayer b) : base(a, b) { }


        public override void AEmbattled(int num)
        {
            A.HP -= num;
            B.HP = num * 0.1 + B.HP;
        }

        public override void BEmbattled(int num)
        {
            B.HP -= num + A.HP * 0.01;
            A.HP = A.HP + num * 0.01;
        }
    }

    /// <summary>  
    /// 玩家A adc  
    /// </summary>  
    public class adcPlayerA : AbstractPlayer
    {
        /// <summary>  
        ///  遭受攻击时候，A生命值减少，对应攻击者的HP增加  
        /// </summary>  
        /// <param name="num"></param>  
        /// <param name="mediator"></param>  
        public override void ChangeHP(int num, AbstractMediator mediator)
        {
            mediator.AEmbattled(num);
        }
    }
    
    /// <summary>  
    /// 玩家B ad  
    /// </summary>  
    public class adPlayerB : AbstractPlayer
    {
        /// <summary>  
        /// 遭受攻击时候，b生命值减少，对应攻击者的HP增加  
        /// </summary>  
        /// <param name="num"></param>  
        /// <param name="mediator"></param>  
        public override void ChangeHP(int num, AbstractMediator mediator)
        {
            mediator.BEmbattled(num);
        }
    }

    /// <summary>  
    /// C#设计模式-中介者模式  
    /// </summary>  
    class Program
    {
        static void Main(string[] args)
        {
            AbstractPlayer a = new adcPlayerA();
            a.HP = 200;
            AbstractPlayer b = new adPlayerB();
            b.HP = 500;

            AbstractMediator mediator = new MediatorPater(a, b);

            //a被b攻击  
            Console.WriteLine("a玩家遭受b的20点攻击");
            a.ChangeHP(20, mediator);
            Console.WriteLine("a生命值>" + a.HP);
            Console.WriteLine("b生命值>" + b.HP);

            Console.WriteLine("");
            Console.WriteLine("b玩家遭受a的20点攻击");
            b.ChangeHP(20, mediator);
            Console.WriteLine("a生命值>" + a.HP);
            Console.WriteLine("b生命值>" + b.HP);
        }
    }
 }
