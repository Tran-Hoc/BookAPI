﻿using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class BookModels
    {
     
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
        public string Author { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 1000)]
        public int Quantity { get; set; }
    }
}
