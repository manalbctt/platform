using PlatformApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlatformApi.Dtos.Request
{
    public class StoreRequestDto
    {
        public DateTime dateCreation { get; set; } = System.DateTime.Now;
        public string nom_store { get; set; }
        public string description { get; set; }
        public string urlstore { get; set; }
        public string UrlLogo { get; set; }
        public int VendeurId { get; set; }
    }
}
