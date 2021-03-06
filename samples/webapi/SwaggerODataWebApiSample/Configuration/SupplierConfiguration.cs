namespace Microsoft.Examples.Configuration
{
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.Examples.Models;
    using Microsoft.Web.Http;

    /// <summary>
    /// Represents the model configuration for suppliers.
    /// </summary>
    public class SupplierConfiguration : IModelConfiguration
    {
        /// <inheritdoc />
        public void Apply( ODataModelBuilder builder, ApiVersion apiVersion, string routePrefix )
        {
            if ( apiVersion < ApiVersions.V3 )
            {
                return;
            }

            builder.EntitySet<Supplier>( "Suppliers" ).EntityType.HasKey( p => p.Id );
            builder.Singleton<Supplier>( "Acme" );
        }
    }
}