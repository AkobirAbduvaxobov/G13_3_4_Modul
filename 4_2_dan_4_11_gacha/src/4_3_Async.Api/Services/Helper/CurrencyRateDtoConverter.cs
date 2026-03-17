namespace _4_3_Async.Api.Services.Helper;

using _4_3_Async.Api.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CurrencyRateDtoConverter : JsonConverter<CurrencyRateDto>
{
    public override CurrencyRateDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;

        return new CurrencyRateDto
        {
            CurrencyRateId = root.GetProperty("id").GetInt32(),
            Code = root.GetProperty("Code").GetString()!,
            Ccy = root.GetProperty("Ccy").GetString()!,

            NameRu = root.GetProperty("CcyNm_RU").GetString()!,
            NameUz = root.GetProperty("CcyNm_UZ").GetString()!,
            NameUzCyrillic = root.GetProperty("CcyNm_UZC").GetString()!,
            NameEn = root.GetProperty("CcyNm_EN").GetString()!,

            Nominal = root.GetProperty("Nominal").GetString()!,
            Rate = root.GetProperty("Rate").GetString()!,
            Diff = root.GetProperty("Diff").GetString()!
        };
    }

    public override void Write(Utf8JsonWriter writer, CurrencyRateDto value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
