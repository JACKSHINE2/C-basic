using System;
using System.Collections.Generic;


/// <summary>
/// 观察者模式：定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主体对象，
/// 这个主题对象在状态发生变化时，会通知所有观察者。当一个对象改变需要同时改变其他对象，
/// 而且他不知道具体有多少对象需要改变的时候，应该考虑使用观察者模式。
/// </summary>
/// 

//猫叫，老鼠跑，主人被惊醒
namespace ObserverPattern
{
    /// <summary>
    /// 1.主题产生变化
    /// </summary>
    interface ISubject
    {
        void Notify();//主题变动时，通知所有观察者   
        void Regiester(IObservable o);//观察者注册   
        void UnRegiester(IObservable o);//观察者取消注册，此时主题发生任何变动，观察者都不会得到通知。   
    }

    /// <summary>
    /// 所有观察者随之受影响
    /// </summary>
    interface IObservable
    {
        void Action();//观察者对主题变动所对应的操作   
    }

    /// <summary>
    /// 观察者，人和老鼠
    /// </summary>
    class Mouse : IObservable
    {
        public void Action()
        {
            Console.WriteLine("鼠跑了!");
        }
    }
    class Master : IObservable
    {
        public void Action()
        {
            Console.WriteLine("主人醒了!");
        }
    }


   /// <summary>
   /// 绑定观察者，将所有观察者放入容器中
   /// </summary>
    class Cat : ISubject
    {
        private IList<IObservable> observers = new List<IObservable>();
        public void Notify()
        {
            foreach (IObservable o in observers) //逐个通知观察者   
            {
                o.Action();
            }
        }
        public void Regiester(IObservable o)
        {
            if (o != null || !observers.Contains(o))
            {
                observers.Add(o);
            }
        }
        public void UnRegiester(IObservable o)
        {
            if (observers != null && observers.Contains(o))
            {
                observers.Remove(o);
            }
        }

        /// <summary>
        /// 主题变化时
        /// </summary>
        public void Cry()
        {
            Console.WriteLine("猫叫了！");
            Notify();
        }

        //主程序
        static void Main(string[] args) {
            Mouse mouse = new Mouse();
            Master master = new Master();
            Cat cat = new Cat();
            cat.Regiester(mouse);
            cat.Regiester(master);
            cat.Cry();
            Console.ReadLine();
        }
    }

    


}
