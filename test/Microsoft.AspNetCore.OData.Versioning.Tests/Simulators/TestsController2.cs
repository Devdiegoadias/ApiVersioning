﻿namespace Microsoft.Simulators
{
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion( "2.0" )]
    [ControllerName( "Tests" )]
    [ODataRoutePrefix( "Tests" )]
    public class TestsController2 : ODataController
    {
        [ODataRoute]
        public IActionResult Get() => Ok( new [] { new TestEntity() { Id = 1 }, new TestEntity() { Id = 2 }, new TestEntity() { Id = 3 } } );

        [ODataRoute( "{id}" )]
        public IActionResult Get( int id ) => Ok( new TestEntity() { Id = id } );
    }
}