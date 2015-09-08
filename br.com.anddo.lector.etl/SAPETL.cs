using br.com.anddo.lector.domain;
using System;

namespace br.com.anddo.lector.etl
{
    public class SAPETL : IETL
    {
        public Product GetProduct(string code)
        {
            //TODO: Lê da fonte do cliente

            Product p = new Product();
            p.Category = new ProductCategory() { Name = "Vinho" };
            p.Code = "7793440702940";
            p.Facts = new NutritionFacts() { };
            p.FullName = "Benjamin Nieto Senetiner Malbec - 2014";
            p.FullWeightValue = "30,12";
            p.Name = "Benjamin Malbec";
            p.Offer = new SpecialOffer() { Description = "2º garrafa com 10% de desconto." };
            p.Type = WeightType.ml;
            p.Value = "22,59";
            p.Weight = "750";

            return p;
        }
    }
}