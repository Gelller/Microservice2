using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice2.Model;

namespace Microservice2.Domain.Aggregates.DebitCardAggregate
{
    public class DebitCardAggregate : DebitCard
    {
        private DebitCardAggregate() { }
        public static DebitCardAggregate Create(string name, string surname, int money)
        {
            return new DebitCardAggregate()
            {
                id = Guid.NewGuid(),
                name = name,
                surname = surname,
                money = money
            };
        }
        public static DebitCardAggregate Update(Guid id, DebitCard debitCard)
        {
            return new DebitCardAggregate()
            {
                id = id,
                name = debitCard.name,
                surname = debitCard.surname,
                money = debitCard.money

            };
        }
    }
}
