using Graphql_CURD.Data;
using HotChocolate.Data.Sorting;

namespace Graphql_CURD.Shema.Sorting
{
    public class SortingTypes: SortInputType<Cakes>
    {
        protected override void Configure(ISortInputTypeDescriptor<Cakes> descriptor)
        {
            descriptor.Ignore(c => c.Id);
            descriptor.Field(c => c.Name).Name("CakeName");

            base.Configure(descriptor);
        }
    }
}
