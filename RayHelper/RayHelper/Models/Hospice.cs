﻿namespace RayHelper.Models
{
    public class Hospice
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Metro { get; set; }

        public string Address => string.IsNullOrWhiteSpace(Metro)
            ? $"{City}, {Street}, {HouseNumber}"
            : $"{City}, {Street}, {HouseNumber}, {Metro}";
    }
}