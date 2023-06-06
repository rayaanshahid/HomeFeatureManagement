namespace HomeFeatureManagement.Models;

using System.ComponentModel.DataAnnotations;

public class Unit
{
    [Required]
    public string PropertyId { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public int Floors { get; set; }

    [Required]
    [EnumDataType(typeof(UnitTypeEnumeration))]
    public string Type { get; set; }

    [Required]
    //[EnumDataType(typeof(List<FeatureEnumeration>))]
    public List<string> Features { get; set; }
}
