namespace Romain.Services;

public class RomainConverterService : IRomainConverterService
{
    private static readonly List<KeyValuePair<int, string>> RomainDico =
        new()
        {
            new(1000, "M"),
            new(900, "CM"),
            new(500, "D"),
            new(400, "CD"),
            new(100, "C"),
            new(90, "XC"),
            new(50, "L"),
            new(40, "XL"),
            new(10, "X"),
            new(9, "IX"),
            new(5, "V"),
            new(4, "IV"),
            new(1, "I"),
        };

    public ConvertResult ToRoman(int arabeNumber)
    {
        if (arabeNumber <= 0 || arabeNumber >= 5000)
        {
            return new ConvertResult
            {
                IsSuccess = false,
                Error = new ArgumentOutOfRangeException(
                    nameof(arabeNumber),
                    "Le nombre doit être compris entre 1 et 5000.")
            };
        }

        string result = "";

        foreach (var kv in RomainDico)
        {
            while (arabeNumber >= kv.Key)
            {
                result += kv.Value;
                arabeNumber -= kv.Key;
            }
        }

        return new ConvertResult
        {
            IsSuccess = true,
            Result = result
        };
    }
}

public class ConvertResult
{
    public bool IsSuccess { get; set; }
    public object? Result { get; set; } = default;
    public Exception? Error { get; set; }
}
