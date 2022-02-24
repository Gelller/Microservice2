using System;

namespace Microservice2.Model
{
    public class DebitCard
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public int money { get; set; }
    }
}
