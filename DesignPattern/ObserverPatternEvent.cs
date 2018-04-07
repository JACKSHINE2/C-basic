using System;

public class ObserverPattern{
    /// <summary>
    /// 2.使用委托事件实现观察者
    /// </summary>
    public delegate void CatCallEventHandler();
    static void Main(string[] args)
    {
        Cat cat = new Cat();
        Mouse mouse = new Mouse(cat);
        Master master = new Master(mouse);
        cat.Call();
    }
}
class Cat
{
    public event CatCallEventHandler catevent;
    public void Call()
    {
        Console.WriteLine("喵喵.....");
        catevent();
    }
}
class Mouse
{
    public event CatCallEventHandler mouseevent;
    public Mouse(Cat cat)
    {
        cat.catevent += new CatCallEventHandler(this.MouseRun);
    }
    public void MouseRun()
    {
        Console.WriteLine("老鼠跑");
        mouseevent();
    }
}
class Master
{
    public Master(Mouse mouse)
    {
        mouse.mouseevent += new CatCallEventHandler(this.JingXing);
    }
    public void JingXing()
    {
        Console.WriteLine("主人被惊醒");
    }
  
}
