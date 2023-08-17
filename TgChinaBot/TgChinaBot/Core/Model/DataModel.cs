using Telegram.Bot.Types.ReplyMarkups;
using TgJourneyBot.Core.Service.Abstract;
using TgJourneyBot.Core.Service.Implement;

namespace TgJourneyBot.Core.Model;

internal class DataModel
{
    public readonly Handler Root = new HandlerImplement
    {
        Successor = new()
        {
            // Основная ветка +-
            new HandlerImplement()
            {
                Successor = new()
                {
                    new HandlerImplement()
                    {
                        Text = "🐲 *Вы в магазине* @TaoBaoRS\n\n" +
                        "Доставка любых товаров из Китая 🇨🇳\n\n" +
                        "👉*МЕНЮ* - выбирай категории 👈",
                        IsCallBack = true,
                        Name = "Name",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "🛍️ Оформить заказ 🧡", callbackData: "Оформить заказ"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "💰 Стоимость товара", callbackData: "Стоимость товара"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "☎️ Поддержка", callbackData: "Поддержка"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "🚚 Быстрая доставка", callbackData: "Быстрая доставка"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "👗 Перейти к товарам", callbackData: "Перейти к товарам"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "📈 Отзывы о нашей работе", callbackData: "Отзывы о нашей работе"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "📚 Ответы на популярные вопросы", callbackData: "Ответы на популярные вопросы"),
                            },
                        })
                    },
                },
            },

            // Оформить заказ +
            new HandlerImplement()
            {
                Successor = new()
                {
                    new HandlerImplement()
                    {
                        Text = "Чтобы отправить посылку нам нужны ваши данные",
                        IsCallBack = true,
                        Name = "Name",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Продолжить", callbackData: "Продолжить"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "☺️ Пожалуйста, введите ФИО",
                        IsCallBack = false,
                        Name = "FIO",
                        ReplyMarkup = new(new[]
                        {
                             new[]
                             {
                                 InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                             },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "📱 Номер телефона в формате 79994447733\n*этот номер будет использован для связи с получателем.",
                        IsCallBack = false,
                        Name = "Phone",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "🚀 Название доставки, которая будет удобна для вас: СДЭК или Boxberry.",
                        IsCallBack = false,
                        Name = "Delivery",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "🏚 Адрес пунта выдачи в формате (Страна, Область, Город, Улица, Номер дома)\n\n* если вы будете использовать курьерскую доставку, достаточно указать город 🏙\n" +
                        "Курьерская доставка (Яндекс)",
                        IsCallBack = false,
                        Name = "DeliveryAdress",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Отправьте ссылку на товар в нужном формате",
                        IsCallBack = false,
                        Name = "Link",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Отправьте размер товара, (актуально для  одежды и обуви) 🙈 например: 39 или XL\n* при заказе других товаров, этот шаг можно пропустить",
                        IsCallBack = false,
                        Name = "ProductSize",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "💰 Пожалуйста, введите итоговую стоимость товара в рублях.\n\n" +
                        "Итоговую стоимость товара в рублях, можно узнать в разделе «💲Стоимость товара»",
                        IsCallBack = false,
                        Name = "FinalCost",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Товар оформлен, продолжить?",
                        IsCallBack = true,
                        Name = "Status",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "😱 Начать сначала", callbackData: "Оформить заказ"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "✅ Оформить", callbackData: "Оформить"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "😍 Ура! Заказ успешно оформлен!\n" +
                        "🙏 Спасибо, что выбрали Tao-BaoRS\n\n" +
                        "После того, как администратор проверит правильность введенных данных, Вам придут реквизиты для оплаты.\n\n" +
                        "Заказы обрабатываются в порядке очереди, с 9 до 23:00 по Москве. 😘 Иногда работаем дольше!\n\n" +
                        "Пожалуйста, не переживайте, Ваш заказ точно в системе, если Вы видите это сообщение. Просто дождитесь ответа администратора 😘\n\n",
                        IsCallBack = true,
                        Name = "Final",
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                        })
                    },
                }
            },

            // Стоимость - ФУЛЛ
            new HandlerImplement()
            {
                Successor = new()
                {
                    new HandlerImplement()
                    {
                        Text = "Чтобы отправить посылку нам нужны ваши данные",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Продолжить", callbackData: "Продолжить"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                }
            },

            // Поддержка +
            new HandlerImplement()
            {
                Successor = new()
                {
                    new HandlerImplement()
                    {
                        Text = "😉Друзья, пожалуйста, пишите в поддержку только, если не смогли найти ответы в часто задаваемых вопросах.\n\n" +
                        "У нас только ОДИН аккаунт поддержки\n\n" +
                        "👇👇👇👇👇👇👇👇👇👇\n" +
                        "👉     @Tao_Bao_official     👈\n" +
                        "👆👆👆👆👆👆👆👆👆👆\n\n" +
                        "‼ВНИМАНИЕ‼\n\n" +
                        "Аккаунт поддержки НИКОГДА не просит перевести оплату за заказы!\n\n" +
                        " Пожалуйста, пользуйтесь только ссылкой что указана в этом сообщении и под постами в группе.\n\n" +
                        "Если Вам пишет аккаунт службы поддержки проверьте соответствие по ссылкам в группе или тут.\n\n" +
                        "Мошенники постоянно пытаются завладеть Вашими денюжками, поэтому будьте бдительны!",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                }
            },

            // Популярные вопросы +
            new HandlerImplement()
            {
                Successor = new()
                {
                    new HandlerImplement()
                    {
                        Text = "Какие вопросы тебя интересуют? 😊",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Сроки доставки", callbackData: "Сроки доставки"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "ТК отправки в РФ", callbackData: "ТК отправки в РФ"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Акции и скидки", callbackData: "Акции и скидки"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Проверка статуса заказа", callbackData: "Проверка статуса заказа"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Оплата товара", callbackData: "Оплата товара"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Дополнительные расходы", callbackData: "Дополнительные расходы"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Изменение и отмена заказа", callbackData: "Изменение и отмена заказа"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Гарантия и возврат товара", callbackData: "Гарантия и возврат товара"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                }
            },

            // Ответы на популярные вопросы +
            new HandlerImplement()
            {
                Successor = new()
                {
                    new HandlerImplement()
                    {
                        Text = "🚚 Сколько времени занимает доставка товара?\n\n" +
                        "Доставка со склада в Китае до склада в России (г. Краснодар) занимает около 30 дней, НО\n\n" +
                        "Стоит понимать, что после заказа товара в боте товар попадает в базу данных. Из-за разницы во времени товар может выкупаться в течении 12-24 часов.\n\n" +
                        "После выкупа товара начинается доставка товара по Китаю на склад. Доставка по Китаю после выкупа может занимать от 1 до 14 дней\n\n" +
                        "Итого весь цикл доставки с в худшем случае может занимать около 40 дней.\n\nДоставка по России в эти диапазоны не входит и зависит от удаленности Вашего региона от г. Краснодар",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "У нас имеется три вида ТК доставки по России:\n\n" +
                        "1. СДЭК\n" +
                        "2. Boxberry\n" +
                        "3. Курьерская доставка (Яндекс)\n\n" +
                        "Вы выбираете более для себя удобную☺️\n\n" +
                        "❗️ВАЖНО \n" +
                        "ДОСТАВКА ПО РОССИИ НЕ ВКЛЮЧЕНА В СТОИМОСТЬ ТОВАРА, ПОЭТОМУ ЕЁ ВЫ ОПЛАЧИВАЕТЕ ОТДЕЛЬНО",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Акции и скидки🎰\n\n" +
                        "Большинство товаров по низкой цене мы будем выкладывать в нашу главную группу:\n\n" +
                        "https://t.me/TaoBaoRS\n\n" +
                        "Самое главное, что мы создали для вас отдельный канал, где будут публиковаться товары по «Быстрой доставке» 😍 " +
                        "и их не нужно будет ждать целый месяц, так-как он уже будет находится в России, поэтому переходи и не упусти свою выгодную покупку🙈:\n\n" +
                        "https://t.me/+oPRJKZnh_oUzYjk1",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Как проверить статус Вашего заказа?😇\n\n" +
                        "После того, как весь заказ будет сформирован и отправлен, администратор сообщит Вам трек-номер посылки, которая будет идти до г.Краснодар📦🚚",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Как оплатить товар? \n\n" +
                        "После того, как Вы оформите заказ или заказЫ😜\n\n" +
                        "Администратор обработает заявку и сразу же свяжется с Вами💚",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Мы всегда стараемся держать наши цены прозрачными и не прибегать к скрытым платежам🔎\n\n" +
                        "Однако, если у нас есть какие-то дополнительные расходы, мы всегда сообщим об этом заранее и детально разъясним, за что мы берем дополнительную оплату.\n\n" +
                        "В данном случае все расходы до России включены в стоимость товара, после того, как посылка прибудет в пункт назначения, Вы доплачиваете только за доставку до своего города или дома 🏠\n\n" +
                        "Если у вас есть конкретные вопросы, и вы не получили ответ на свой вопрос, пожалуйста, сообщите нам о них, написав в поддержку, чтобы мы могли предоставить более точный ответ😌",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Да, вы можете изменить или отменить заказ, если он еще не был оплачен или отправлен. " +
                        "Пожалуйста, обратитесь к нашим условиям и политикам отмены и изменения заказа на нашем сайте или свяжитесь с нашим сервисным центром для получения дополнительной информации. " +
                        "Мы сделаем все возможное, чтобы удовлетворить ваш запрос.",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                    new HandlerImplement()
                    {
                        Text = "Мы гарантируем отличное качество товара, потому что мы лично  выбираем и проверяем его\n" +
                        "на месте☺️\n\n" +
                        "Если товар не соответствует вашим ожиданиям или он дошёл до вас в плохом состоянии, пожалуйста, обратитесь к нашему представителю для решения данного вопроса, мы обязательно всё уладим.\n\n" +
                        "❗️ВАЖНО ❗️\nОбязательно перед покупкой товара, прочтите все условия возврата.\n\n" +
                        "Товар возвращается только в том случае, если есть брак или поломка. Для того, чтобы определить случилась ли поломка из-за некачественной отправки, перед вскрытием товара, " +
                        "Вы заранее делаете видео, чтобы потом смогли показать его нашему администратору, что при вскрытии был обнаружен недочёт, при этом мы увидим,что Вы с этим товаром ничего не сделали.",
                        IsCallBack = true,
                        ReplyMarkup = new(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Главное меню", callbackData: "Главное меню"),
                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData(text: "Назад", callbackData: "Назад"),
                            },
                        })
                    },
                }
            },
        }
    };
}
