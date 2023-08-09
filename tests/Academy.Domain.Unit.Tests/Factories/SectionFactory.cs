namespace Academy.Domain.Unit.Tests.Factories;

public class SectionFactory
{
    public static Section Create()
    {
        return new Section(11, "Tdd");
    }
}