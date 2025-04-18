﻿using System;
using System.ComponentModel.DataAnnotations;

namespace br.com.anddo.lector.domain
{
    [Serializable]
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Imagepath { get; set; }
        public string Weight { get; set; }
        public WeightType Type { get; set; }
        public SpecialOffer Offer { get; set; }
        public ProductCategory Category { get; set; }
        public NutritionFacts Facts { get; set; }
        public string Value { get; set; }
        public string FullWeightValue { get; set; }
    }
}
