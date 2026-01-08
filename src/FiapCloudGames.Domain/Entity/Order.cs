namespace Domain.Entity
{
    public class Order : EntityBase
    {
        public int CustomerId { get; set; }
        public int GameId { get; set; }

        //Propriedades de naveção para o EF poder gerar os relacionamentos.(Foreign Keys).
        public Customer Customer { get; set; }
        public Games Game { get; set; }
    }
}
