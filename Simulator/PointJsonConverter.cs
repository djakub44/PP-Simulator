using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Simulator;
public class PointConverter : JsonConverter<Point>
{
    public override Point Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var parts = value.Split(',');

        if (parts.Length != 2 ||
            !int.TryParse(parts[0], out int x) ||
            !int.TryParse(parts[1], out int y))
        {
            throw new JsonException($"Invalid Point format: {value}");
        }

        return new Point(x,y);
    }

    public override void Write(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }

    public override Point ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var parts = value.Split(',');

        if (parts.Length != 2 ||
            !int.TryParse(parts[0], out int x) ||
            !int.TryParse(parts[1], out int y))
        {
            throw new JsonException($"Invalid Point format: {value}");
        }

        return new Point(x, y);
    }

    public override void WriteAsPropertyName(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
    {
        writer.WritePropertyName(value.ToString());
    }
}