using OdeToFood.Models;
using Postal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace OdeToFood
{
    public class NewComment
    {
        public static void NotifyNewComment(int commentId)
        {
            // Prepare Postal classes to work outside of ASP.NET request
            var viewsPath = Path.GetFullPath(HostingEnvironment.MapPath(@"~/Views/Emails"));
            var engines = new ViewEngineCollection();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            var emailService = new EmailService(engines);

            // Get comment and send a notification.
            using (var db = new OdeToFoodDb())
            {
                var comments = db.Comments.Find(commentId);

                var email = new NewCommentEmail
                {
                    To = comments.Email,
                    UserName = comments.UserName,
                    Comment = comments.Comment
                };

                emailService.Send(email);
            }
        }
    }
}



