using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Shopping_Cart.ViewModels
{
    public class CartItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "cartId")]
        public Guid CartId { get; set; }
        [JsonProperty(PropertyName = "bookId")]
        public Guid BookId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantidade deve ser maior do que zero")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "book")]
        public BookViewModel Book { get; set; }
    }
}