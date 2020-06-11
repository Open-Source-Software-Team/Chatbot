using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chatbot.Bot.Dialogs
{
    public class RootDialog : ComponentDialog
    {
        public RootDialog() 
        {
            var waterfallStep = new WaterfallStep[]
            {
                SetName,
                SetAge,
                ShowData
            };

            //Tipos de Dialogos
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new NumberPrompt<int>(nameof(NumberPrompt<int>), ValdiateAge));
        }

        private async Task<bool> ValdiateAge(PromptValidatorContext<int> promptContext, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                promptContext.Recognized.Succeeded &&
                promptContext.Recognized.Value > 0 &&
                promptContext.Recognized.Value < 150
                );
        }

        private async Task<DialogTurnResult> ShowData(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Genial, gracias por ingresar tus datos.", cancellationToken: cancellationToken);
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }

        private async Task<DialogTurnResult> SetAge(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var name = stepContext.Context.Activity.Text;
            return await stepContext.PromptAsync(
                nameof(NumberPrompt<int>),
                new PromptOptions 
                { 
                    Prompt = MessageFactory.Text($"Bien {name}, ahora necesito tu edad"),
                    RetryPrompt = MessageFactory.Text($"{name}, por favor ingrese una edad valida")
                },
                cancellationToken
                );
        }

        private async Task<DialogTurnResult> SetName(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {            
            await stepContext.Context.SendActivityAsync("Para iniciar una conversación necesitos algunos datos.", cancellationToken: cancellationToken);
            await Task.Delay(1000);
            return await stepContext.PromptAsync(
                nameof(TextPrompt),
                new PromptOptions { Prompt = MessageFactory.Text("Por favor ingrese tu nombre") },
                cancellationToken
                );
        }
    }
}
