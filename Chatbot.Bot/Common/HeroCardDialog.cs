﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chatbot.Bot.Common
{
    public class HeroCardDialog
    {
        public static async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = await stepContext.PromptAsync(
                nameof(TextPrompt),
                new PromptOptions
                {
                    Prompt = CreateThumbnailCard()
                },
                cancellationToken
            );
            return option;
        }

        private static Activity CreateThumbnailCard()
        {
            var thumbnailCard = new ThumbnailCard
            {
                Title = "Bot Framework",
                Subtitle = "Microsoft Bot Framework V4",
                Images = new List<CardImage> { new CardImage("https://image.ibb.co/gLUyn9/Chat_Bot_Bot_Framework.png") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){ Title = "Documentation", Value = "Documentation", Type = ActionTypes.ImBack },
                    new CardAction(){ Title = "Report", Value = "Report", Type = ActionTypes.ImBack },
                    new CardAction(){ Title = "Ir a la Web", Value = "https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.attachment?view=netcore-3.1", Type = ActionTypes.OpenUrl }
                }
            };
            return MessageFactory.Attachment(thumbnailCard.ToAttachment()) as Activity;
        }

        private static Activity CreateHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "Bot Framework",
                Subtitle = "Microsoft Bot Framework V4",
                Images = new List<CardImage> { new CardImage("https://image.ibb.co/gLUyn9/Chat_Bot_Bot_Framework.png") },
                Buttons = new List<CardAction>()
                { 
                    new CardAction(){ Title = "Documentation", Value = "Documentation", Type = ActionTypes.ImBack },
                    new CardAction(){ Title = "Report", Value = "Report", Type = ActionTypes.ImBack },
                    new CardAction(){ Title = "Ir a la Web", Value = "https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.attachment?view=netcore-3.1", Type = ActionTypes.OpenUrl }
                }
            };
            return MessageFactory.Attachment(heroCard.ToAttachment()) as Activity;
        }
    }
}
