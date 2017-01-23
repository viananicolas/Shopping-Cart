using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shopping_Cart.ViewModels
{
    public class CartViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "cartItems")]
        public virtual ICollection<CartItemViewModel> CartItems { get; set; }
    }
}