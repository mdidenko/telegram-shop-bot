using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace TelegramShopBot.Utils;

internal static class JsonUtils
{
    public static string Serialize<TModel>(in TModel model, in JsonTypeInfo<TModel>? jsonTypeInfo = null)
    {
        try
        {
            if (jsonTypeInfo != null)
            {
                return JsonSerializer.Serialize(model, jsonTypeInfo);
            }
            else
            {
                return JsonSerializer.Serialize(model);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("JSON serialization exception.", ex)
                .AddParameter(nameof(model), typeof(TModel).Name)
                .AddParameter(nameof(jsonTypeInfo), $"{jsonTypeInfo}");
        }
    }

    public static TModel Deserialize<TModel>(in string json, in JsonTypeInfo<TModel>? jsonTypeInfo = null)
    {
        TModel? model;
        try
        {
            if (jsonTypeInfo != null)
            {
                model = JsonSerializer.Deserialize(json, jsonTypeInfo);
            }
            else
            {
                model = JsonSerializer.Deserialize<TModel>(json);
            }
            ArgumentNullException.ThrowIfNull(model);
            return model;
        }
        catch (Exception ex)
        {
            throw new Exception("JSON deserialization exception.", ex)
                .AddParameter(nameof(TModel), typeof(TModel).Name)
                .AddParameter(nameof(json), json)
                .AddParameter(nameof(jsonTypeInfo), $"{jsonTypeInfo}");
        }
    }

    public static T GetKeyValue<T>(in string json, in string keyPath, in char pathBranchesSeparator = '.')
    {
        JsonDocument jsonDocument = Deserialize<JsonDocument>(json);
        JsonElement jsonElement = jsonDocument.RootElement;
        string[] pathBranches = keyPath.Split(pathBranchesSeparator);
        string rawKeyValue;

        try
        {
            foreach(var pathBranch in pathBranches)
            {
                jsonElement = jsonElement.GetProperty(pathBranch);
            }
            rawKeyValue = jsonElement.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("Exception while getting key value from JSON.", ex)
                .AddParameter(nameof(keyPath), keyPath)
                .AddParameter(nameof(pathBranchesSeparator), pathBranchesSeparator.ToString())
                .AddParameter(nameof(json), json);
        }
        finally
        {
            jsonDocument.Dispose();
        }

        return TypeCastHelper.ConvertType<T>(rawKeyValue);
    }
}
