Arrow userArrow = GetArrow();

Console.WriteLine($"That arrow costs {userArrow.GetCost()} gold.");
Arrow GetArrow()
{
    ArrowHead arrowHead = GetArrowHead();
    Fletching fletching = GetFletching();
    float length = GetShaftLength();

    return new Arrow(arrowHead, fletching, length);
}

ArrowHead GetArrowHead()
{
    Console.Write("Choose arrow head type: steel, wood, obsidian ");
    string? input = Console.ReadLine();

    return input switch
    {
        "steel" => ArrowHead.steel,
        "wood" => ArrowHead.wood,
        "obsidian" => ArrowHead.obsidian,
        _ => ArrowHead.steel
    };
}
Fletching GetFletching()
{
    Console.Write("Choose arrow fletching type: plastic, turkey feathers, goose feathers ");
    string? input = Console.ReadLine();

    return input switch
    {
        "plastic" => Fletching.plastic,
        "turkey feathers" => Fletching.turkeyFeathers,
        "goose feathers" => Fletching.gooseFeathers,
        _ => Fletching.plastic
    };
}
float GetShaftLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

class Arrow
{
    public ArrowHead _arrowHead;
    public Fletching _arrowFletching;
    public float _shaftLength;

    public Arrow(ArrowHead arrowHead, Fletching arrowFletching, float shaftLength)
    {
        _arrowHead = arrowHead;
        _arrowFletching = arrowFletching;
        _shaftLength = shaftLength;
    }

    public float GetCost()
    {
        float arrowHeadCost = _arrowHead switch
        {
            ArrowHead.steel => 10,
            ArrowHead.wood => 3,
            ArrowHead.obsidian => 5,
            _ => 0
        };
        float fletchingCost = _arrowFletching switch
        {
            Fletching.plastic => 10,
            Fletching.turkeyFeathers => 5,
            Fletching.gooseFeathers => 3,
            _ => 0
        };

        float price = arrowHeadCost + fletchingCost + (_shaftLength * 0.05f);
        return price;
    }


}
public enum ArrowHead { steel, wood, obsidian };
public enum Fletching { plastic, turkeyFeathers, gooseFeathers };