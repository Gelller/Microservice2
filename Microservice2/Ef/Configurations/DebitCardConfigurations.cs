using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservice2.Model;

namespace Microservice2.Ef.Configurations
{
    public class DebitCardConfigurations : IEntityTypeConfiguration<DebitCard>
    {
        public void Configure(EntityTypeBuilder<DebitCard> builder)
        {
            builder.ToTable("debitcard");         
        }
    }
}
