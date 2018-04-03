using System;

public interface IWord
{
    void Print();
}

public interface IWord2 : IWord
{
    new void Print();
}

public abstract class Base
{
    protected static string msg = "send ";

    public Base()
    {
        Console.Write(this.GetString());
    }

    static Base()
    {
        Console.Write("Never "); //instantiation --> "Never"
    }

    public virtual void Print()
    {
        Console.Write("to ");
    }

    protected virtual string GetString()
    {
        return "llama ";
    }
}

public class Derived : Base, IWord
{

    static Derived()
    {
        Console.Write(Derived.msg); //instantiation --> "send"
    }

    public new virtual void Print()
    {
        Console.Write("do ");
    }

    protected override string GetString() 
    {
        return "a ";
    }
}

public sealed class MoreDerived : Derived, IWord
{
    public override void Print()
    {
        Console.Write("mach");
    }

    void IWord.Print()
    {
        Console.Write("a ");
    }

    protected override string GetString()
    {
        return "do ";
    }
}

public sealed class MoreDerived2 : Derived, IWord2
{

    static MoreDerived2()
    {
        Console.Write("ine");
    }

    public new void Print()
    {
        Console.Write("job. ");
    }

    void IWord2.Print()
    {
        Console.Write("job.");
    }

    protected override string GetString()
    {
        return "'s ";
    }
}

public abstract class Unfinished : Base
{
    protected new void Print()
    {
        Console.Write("camel ");
    }

    protected override string GetString()
    {
        return "human ";
    }
}

public class Finished : Unfinished
{
	static Finished(){
			
	}
	public string printHuman(){
		return base.GetString();
	}
}

public class AgentSmith
{
    //Never send a human to do a machine's job.
    public static void Main()
    {
      
		Derived start = new Derived();
		Finished humanGetter = new Finished();
		start.ToString();
		humanGetter.printHuman();
		humanGetter.Print();
		MoreDerived morestart = new MoreDerived();
		IWord test = (IWord)morestart;
		test.Print();
		morestart.Print();
		MoreDerived2 morestart2 = new MoreDerived2();
		morestart2.Print();
      
        Console.ReadLine();

    }

}