﻿namespace Client.DTOS
{
    using Domain;

    public class ClientDTO: IMapFrom<Customer>
    {
        public string Name { get; set; }
        public  int OrdersCount { get; set; }
    }
}
