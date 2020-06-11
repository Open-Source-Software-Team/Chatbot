using Microsoft.AspNetCore.Http;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Chatbot.Bot.Common
{
    public class AttachmentCard
    {
        public static Activity GetImage()
        {
            var imageCard = new Attachment();
            imageCard.Name = "image";
            imageCard.ContentType = "image/png";
            imageCard.ContentUrl = "http://www.sunsmartglobal.com/wp-content/uploads/2018/08/chatbot.png";

            var reply = MessageFactory.Attachment(imageCard);
            return reply as Activity;
        }

        public static Activity GetImageGIF()
        {
            var imageCard = new Attachment();
            imageCard.Name = "image";
            imageCard.ContentType = "image/gif";
            imageCard.ContentUrl = "http://www.smartbots.ai/wp-content/uploads/2019/04/bot-new.gif";

            var reply = MessageFactory.Attachment(imageCard);
            return reply as Activity;
        }

        public static Activity GetVideo()
        {
            var videoCard = new Attachment();
            videoCard.Name = "video";
            videoCard.ContentType = "video/mp4";
            videoCard.ContentUrl = "https://adaptivecardsblob.blob.core.windows.net/assets/AdaptiveCardsOverviewVideo.mp4";

            var reply = MessageFactory.Attachment(videoCard);
            return reply as Activity;
        }

        public static Activity GetAudio()
        {
            var audioCard = new Attachment();
            audioCard.Name = "audio";
            audioCard.ContentType = "audio/mp3";
            //audioCard.ContentUrl = "https://bestringtoness.com/sounds/mp3/crash-team-racing-nitro-fueled.ringtone.mp3";
            audioCard.ContentUrl = "https://bestringtoness.com/sounds/mp3/thy-will-ringtone.mp3";

            var reply = MessageFactory.Attachment(audioCard);
            return reply as Activity;
        }

        public static Activity GetDocumento()
        {

            var documentoCard = new Attachment();
            documentoCard.Name = "documento";
            documentoCard.ContentType = "text/plain";
            documentoCard.ContentUrl = "";

            var reply = MessageFactory.Attachment(documentoCard);
            return reply as Activity;
        }

        public static string GetText()
        {
            ApiConsumption xx = new ApiConsumption();
            var response = xx.ApiFactory("", "");

            return response;
        }
    }
}
