﻿namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Cars;

    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> WithParts();
    }
}
