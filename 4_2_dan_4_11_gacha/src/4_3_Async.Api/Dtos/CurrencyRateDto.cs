namespace _4_3_Async.Api.Dtos;

public class CurrencyRateDto
{
    public int CurrencyRateId { get; set; }
    public string Code { get; set; }      
    public string Ccy { get; set; }       

    public string NameRu { get; set; }
    public string NameUz { get; set; } 
    public string NameUzCyrillic { get; set; }
    public string NameEn { get; set; }

    public string Nominal { get; set; }                 
    public string Rate { get; set; }                
    public string Diff { get; set; }                
}
