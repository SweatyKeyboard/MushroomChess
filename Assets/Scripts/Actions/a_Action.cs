using System.Collections;

public abstract class a_Action
{
    public a_BoardElement Target { get; set; }
    public abstract IEnumerator Courutine { get; }
    public a_Action(a_BoardElement target)
    {
        Target = target;
    }
}