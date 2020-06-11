// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chatbot.Bot.Common;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace Chatbot.Bot
{
    public class EmptyBot<T> : ActivityHandler where T: Dialog
    {
        protected readonly Dialog _dialog;
        protected readonly BotState _conversationState;
        protected readonly ILogger _logger;

        //Constructor
        public EmptyBot(T dialog, ConversationState conversationState, ILogger<EmptyBot<T>> logger)
        {
            _dialog = dialog;
            _conversationState = conversationState;
            _logger = logger;
        }

        //Metodo de Nuevo Usuario
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id) //Id Nuevo Usuario
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hola Mundo!"), cancellationToken);
                }
            }
        }

        //Verifica si se ha recibido una actividad del usuario
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //return base.OnMessageActivityAsync(turnContext, cancellationToken);

            //Demo #1
            //var vMessage = turnContext.Activity.Text;
            //await turnContext.SendActivityAsync($"El Usuario dijo: { vMessage }", cancellationToken: cancellationToken);

            //Demo #2 y 3
            //await _dialog.RunAsync(
            //    turnContext,
            //    _conversationState.CreateProperty<DialogState>(nameof(DialogState)),
            //    cancellationToken);

            //Demo #4
            var vMessage = turnContext.Activity.Text.ToLower();

            if (vMessage.Equals("imagen"))
                await turnContext.SendActivityAsync(AttachmentCard.GetImage(), cancellationToken);
            else if (vMessage.Equals("imagengif"))
                await turnContext.SendActivityAsync(AttachmentCard.GetImageGIF(), cancellationToken);
            else if (vMessage.Equals("video"))
                await turnContext.SendActivityAsync(AttachmentCard.GetVideo(), cancellationToken);
            else if (vMessage.Equals("audio"))
                await turnContext.SendActivityAsync(AttachmentCard.GetAudio(), cancellationToken);
            else if (vMessage.Equals("documento"))
                await turnContext.SendActivityAsync(AttachmentCard.GetDocumento(), cancellationToken);
            else if (vMessage.Equals("texto"))
                await turnContext.SendActivityAsync(MessageFactory.Text(AttachmentCard.GetText()), cancellationToken);
            else
                await turnContext.SendActivityAsync("Opción no válida", cancellationToken: cancellationToken);

        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }
    }
}
