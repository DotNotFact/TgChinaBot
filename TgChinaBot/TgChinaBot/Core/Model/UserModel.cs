namespace TgJourneyBot.Core.Model;

public class UserModel
{
    public ResultModel ResultModel { get; set; } = new();

    public State CurrentState { get; set; } = State.Main;

    public bool IsStart { get; set; } = false;

    internal int Node { get; set; }
    internal int Link { get; set; }

    public void Reset()
    {
        CurrentState = State.Main;
        ResultModel = new();
        IsStart = true;
        Node = 0;
        Link = 0;
    }

    public void MoveNext() => Link += 1;

    public void BackMove()
    {
        if (Node > 0 && Link == 0)
        {
            Reset();
            return;
        }
        Link -= 1;
    }

    public void GetCallback(string callback)
    {
        switch (callback)
        {
            case "Главное меню":
                CurrentState = State.Main;
                Node = 0;
                Link = 0;
                break;

            case "Оформить заказ":
                CurrentState = State.Orders;
                Node = 1;
                Link = 0;
                break;

            case "Стоимость товара":
                CurrentState = State.Cost;
                Node = 2;
                Link = 0;
                break;

            case "Поддержка":
                CurrentState = State.Helps;
                Node = 3;
                Link = 0;
                break;

            case "Ответы на популярные вопросы":
                CurrentState = State.FAQs;
                Node = 4;
                Link = 0;
                break;

            case "Назад":
                if (Node == 5)
                {
                    Node = 4;
                    Link = 0;
                }
                else
                    BackMove();
                break;


            case "Сроки доставки":
                Node = 5;
                Link = 0;
                break;

            case "ТК отправки в РФ":
                Node = 5;
                Link = 1;
                break;

            case "Акции и скидки":
                Node = 5;
                Link = 2;
                break;

            case "Проверка статуса заказа":
                Node = 5;
                Link = 3;
                break;

            case "Оплата товара":
                Node = 5;
                Link = 4;
                break;

            case "Дополнительные расходы":
                Node = 5;
                Link = 5;
                break;

            case "Изменение и отмена заказа":
                Node = 5;
                Link = 6;
                break;

            case "Гарантия и возврат товара":
                Node = 5;
                Link = 7;
                break;


            default:
                MoveNext();
                return;
        }
    }
}

public enum State
{
    Main,
    Orders,
    Cost,
    Helps,
    FAQs,
}