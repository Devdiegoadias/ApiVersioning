namespace given_a_versioned_ODataController
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData;
    using Microsoft.AspNetCore.OData.Basic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    using static System.Net.HttpStatusCode;

    [Trait( "Routing", "Classic" )]
    [Collection( nameof( BasicODataCollection ) )]
    public class when_using_a_url_segment : BasicAcceptanceTest
    {
        [Theory]
        [InlineData( "v1/orders" )]
        [InlineData( "v1/orders/42" )]
        public async Task then_get_should_return_200( string requestUrl )
        {
            // arrange


            // act
            var response = await GetAsync( requestUrl ).EnsureSuccessStatusCode();

            // assert
            response.Headers.GetValues( "api-supported-versions" ).Single().Should().Be( "1.0" );
        }

        [Fact]
        public async Task then_get_should_return_400_for_an_unsupported_version()
        {
            // arrange


            // act
            var response = await GetAsync( "v2/orders" );
            var content = await response.Content.ReadAsAsync<OneApiErrorResponse>();

            // assert
            response.StatusCode.Should().Be( BadRequest );
            content.Error.Code.Should().Be( "UnsupportedApiVersion" );
        }

        public when_using_a_url_segment( BasicFixture fixture ) : base( fixture ) { }

        protected when_using_a_url_segment( ODataFixture fixture ) : base( fixture ) { }
    }

    [Trait( "Routing", "Endpoint" )]
    [Collection( nameof( BasicODataEndpointCollection ) )]
    public class when_using_a_url_segment_ : when_using_a_url_segment
    {
        public when_using_a_url_segment_( BasicEndpointFixture fixture ) : base( fixture ) { }
    }
}