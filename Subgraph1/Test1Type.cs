using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace Subgraph1;

[ObjectType<Test1>]
public static partial class Test1Type
{
    static partial void Configure(IObjectTypeDescriptor<Test1> descriptor)
    {
        descriptor.Field(x => x.TestProperty);
    }

    [Query]
    public static IEnumerable<Test1> GetTest1() => [new Test1()];
}