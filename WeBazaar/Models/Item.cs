﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeBazaar.Data.Base;
using WeBazaar.Data.Enums;

namespace WeBazaar.Models
{
    public class Item:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ItemCategory ItemCategory { get; set; }

        //Relationship with product
        /// <summary>
        /// public  int ProductId { get; set; }
        /// </summary>
        public List<Product_Item> Products_Items { get; set; }


        //Company
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }


        //Producer
        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

    }
}
