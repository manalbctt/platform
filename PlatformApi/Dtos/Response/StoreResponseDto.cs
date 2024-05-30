using PlatformApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlatformApi.Dtos.Response
{
    public class StoreResponseDto
    {
        [Key]
        public int id_store { get; set; }
        public DateTime dateCreation { get; set; }
        public string nom_store { get; set; }
        public string description { get; set; }
        public string UrlLogo { get; set; }
        public int VendeurId { get; set; }
    }
}
