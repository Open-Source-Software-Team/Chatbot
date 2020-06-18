using Chatbot.Bot.Common;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chatbot.Bot.Bots
{
    public class InitialBot<T> : ActivityHandler where T: Dialog 
    {
        protected readonly Dialog _dialog;
        protected readonly BotState _conversationState;
        protected readonly ILogger _logger;

        public InitialBot(T dialog, ConversationState conversationState, ILogger<InitialBot<T>> logger)
        {
            _dialog = dialog;
            _conversationState = conversationState;
            _logger = logger;
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id) //Id Nuevo Usuario
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"¡Hola! Mi nombre es Pilo y soy parte del equipo de DigitalWare, regalanos tus datos para inicio de sesión"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Mi nombre es Pilo y soy parte del equipo de DigitalWare"), cancellationToken);
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Digite los datos para inicio de sesión"), cancellationToken);
                }
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
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
            else if (vMessage.Equals("cuentas"))
                await turnContext.SendActivityAsync(AttachmentCard.GetAccount(), cancellationToken);
            else if (vMessage.Equals("certificado"))
                try
                {
                    await turnContext.SendActivityAsync(AttachmentCard.GetCertificate1(), cancellationToken);
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }
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
