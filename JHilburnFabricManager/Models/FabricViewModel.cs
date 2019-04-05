using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace JHilburnFabricManager.Models
{
    public class FabricViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a fabric SKU")]
        [Display(Name = "SKU")]
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Please enter fabric description")]
        [Display(Name = "Description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter fabric price")]
        [Display(Name = "Price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Display(Name = "Activate")]
        [JsonProperty("active")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Please enter a fabric category")]
        [Display(Name = "Category")]
        [JsonProperty("category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a fabric image url")]
        [Display(Name = "Image Url")]
        [JsonProperty("imgUrl")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Please enter a fabric count")]
        [Display(Name = "Inventory Count")]
        [JsonProperty("inventory")]
        public int Inventory { get; set; }
    }
}