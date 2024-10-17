using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace Subgraph2;

[ObjectType<Test2>]
public static partial class Test2Type
{
    static partial void Configure(IObjectTypeDescriptor<Test2> descriptor)
    {
        descriptor.Field(x => x.TestProperty);
    }

    [Query]
    public static IEnumerable<Test2> GetTest2() => [new Test2()];
}