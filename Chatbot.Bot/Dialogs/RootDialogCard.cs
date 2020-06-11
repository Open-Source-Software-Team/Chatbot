using Chatbot.Bot.Common;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chatbot.Bot.Dialogs
{
    public class RootDialogCard : ComponentDialog
    {
        public RootDialogCard()
        {
            var waterfallStep = new WaterfallStep[]
            {
                ShowHeroCardOptions,
                ResponseOptions
            };

            //Tipos de Dialogos
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }

        private async Task<DialogTurnResult> ResponseOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var option = stepContext.Context.Activity.Text;
            await stepContext.Context.SendActivityAsync($"Seleccionaste : { option }", cancellationToken: cancellationToken);
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }

        private async Task<DialogTurnResult> ShowHeroCardOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //MOSTRAR TARJETAS
            //throw new NotImplementedException();

            return await HeroCardDialog.ShowOptions(stepContext, cancellationToken);
        }
    }
}
