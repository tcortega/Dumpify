using System.Text;

namespace Dumpify.Tests.Generators;

[TestClass]
public class SingleValueDescriptorTests
{
    [TestMethod]
    [DataRow(typeof(int))]
    [DataRow(typeof(string))]
    [DataRow(typeof(bool))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(short))]
    [DataRow(typeof(ushort))]
    [DataRow(typeof(uint))]
    [DataRow(typeof(long))]
    [DataRow(typeof(ulong))]
    [DataRow(typeof(float))]
    [DataRow(typeof(double))]
    [DataRow(typeof(decimal))]
    [DataRow(typeof(Half))]
    public void ShouldBeSingleValueDescriptor(Type type)
    {
        var generator = new CompositeDescriptorGenerator();
        var descriptor = generator.Generate(type, null);

        descriptor.Should().BeOfType<SingleValueDescriptor>($"{type.FullName} is a single value", descriptor);
    }

    [TestMethod]
    [DataRow(typeof(StringBuilder))]
    [DataRow(typeof(Person))]
    [DataRow(typeof(List<int>))]
    [DataRow(typeof(string[]))]
    [DataRow(typeof(int[]))]
    public void ShouldNotBeSingleValueDescriptor(Type type)
    {
        var generator = new CompositeDescriptorGenerator();
        var descriptor = generator.Generate(type, null);

        descriptor.Should().NotBeOfType<SingleValueDescriptor>($"{type.FullName} is not a single value", descriptor);
    }
}