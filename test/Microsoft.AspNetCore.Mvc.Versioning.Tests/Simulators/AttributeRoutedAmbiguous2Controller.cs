namespace Microsoft.AspNetCore.Mvc.Simulators
{
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [ApiVersion( "1.0" )]
    [Route( "api/attributed/ambiguous" )]
    public sealed class AttributeRoutedAmbiguous2Controller : ControllerBase
    {
        [HttpGet]
        public Task<string> Get() => Task.FromResult( "Test" );
    }
}