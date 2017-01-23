﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Shopping_Cart.ViewModels
{
    public class BookViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "isbn")]
        public string Isbn { get; set; }
        [JsonProperty(PropertyName = "synopsis")]
        public string Synopsis { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "listPrice")]
        public decimal ListPrice { get; set; }
        [JsonProperty(PropertyName = "salePrice")]
        public decimal SalePrice { get; set; }
        [JsonProperty(PropertyName = "featured")]
        public bool Featured { get; set; }

        [JsonProperty(PropertyName = "savePercentage")]
        public int SavePercentage => (int) (100 - SalePrice/ListPrice*100);
        [JsonProperty(PropertyName = "author")]
        public virtual AuthorViewModel Author { get; set; }
        [JsonProperty(PropertyName = "category")]
        public virtual CategoryViewModel Category { get; set; }
    }
}