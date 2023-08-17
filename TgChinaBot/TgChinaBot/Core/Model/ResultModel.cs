using System.Text;

namespace TgJourneyBot.Core.Model;

public class ResultModel
{
    private Dictionary<string, string> _results { get; set; } = new();

    public void AddResult(string key, string value)
    {
        _results[key] = value;
    }

    public string GetResult(string key)
    {
        return _results.TryGetValue(key, out var value) ? value : "";
    }

    public string ToResult()
    {
        var fields = new[]
        {
            ("👤 Имя Пользователя", "Name"),
            ("🥲 ФИО", "FIO"),
            (" Номер телефона", "Phone"),
            ("🏠 Доставка", "Delivery"),
            (" Адрес Доставка", "DeliveryAdress"),
            (" Ссылка на товар", "Link"),
            (" Размер товара", "ProductSize"),
            (" Итоговая стоимость", "FinalCost"),
            ("", "Status"),
            ("", "Final"),
        };

        var resultBuilder = new StringBuilder();

        foreach (var (label, key) in fields)
            if (key == "Name")
                resultBuilder.AppendLine($"{label}\n@{GetResult(key)}\n");
            else
                resultBuilder.AppendLine($"{label}\n{GetResult(key)}\n");

        return resultBuilder.ToString();
    }
}