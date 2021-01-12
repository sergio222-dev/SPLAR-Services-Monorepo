#region Imports

using Microsoft.Data.SqlClient;
using SPLAR.Shared.Infrastructure.EntityFramework;
using SPLAR.Wiki.Shared.Infrastructure.Persistence.EntityFramework;

#endregion

namespace Wiki.Core.Shared.Infrastructure.EntityFramework
{
    public sealed class WikiEntityFrameworkEntityManagerFactory
    {
        public static EntityFrameworkEntityManager Create(string sDataSource, string sCatalog, string sUser, string sPassword)
        {
            var sConnection = new SqlConnectionStringBuilder()
            {
                DataSource = sDataSource,
                InitialCatalog = sCatalog,
                UserID = sUser,
                Password = sPassword,
            }.ConnectionString;

            var oContext = new WikiContext(sConnection);

            return EntityFrameworkEntityManager.Create(oContext);
        }
    }
}