

//子类个数稳定,列如：性别稳定的分为男和女
//若要使用此模式，一定要考虑清楚
public abstract class Element 
{
    public abstract void Accept(Visitor visitor);
}
