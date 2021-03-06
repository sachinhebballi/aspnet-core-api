﻿namespace Api.Services.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }

        public string UnitNumber { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public int Postcode { get; set; }
    }
}
