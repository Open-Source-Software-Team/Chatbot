// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EmptyBot v4.6.2

using Chatbot.Bot.Dialogs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chatbot.Bot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); //Compatividad MVC

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>(); //Clase o Servicio para inyeccion de Dependencias
            services.AddSingleton<IStorage, MemoryStorage>(); //Guardar datos en memoria
            services.AddSingleton<ConversationState>(); //Estado de la Conversacion
            services.AddSingleton<RootDialog>(); //Registrar mi dialogo
            services.AddSingleton<RootDialogButton>(); //Registrar mi dialogo
            services.AddSingleton<RootDialogCard>(); //Registrar mi dialogo

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, EmptyBot<RootDialog>>(); //Clase del Bot
            //services.AddTransient<IBot, EmptyBot<RootDialogButton>>();
            //services.AddTransient<IBot, EmptyBot<RootDialogCard>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseMvc();
        }
    }
}
