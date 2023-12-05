using Xunit;

namespace Acceptance.Api.Test.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<AcceptanceApiBroker>
    {
    }
}
