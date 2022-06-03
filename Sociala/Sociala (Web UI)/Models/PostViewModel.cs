using Sociala__Web_UI_.Entities;
using Sociala_Entities.Concrete.DatabaseFirst;

namespace Sociala__Web_UI_.Models
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            users = new List<User>();

        }
        public User user_ { get; set; }
        public List<User> users { get; set; }

        public List<Post> posts { get; set; }

        public Post post { get; set; }

        public List<Tag> tags { get; set; }

        public Tag tag { get; set; }

        public List<PostandTag> postandTags { get; set; }

        public PostandTag postandTag { get; set; }

        public List<Reaction> reactions { get; set; }

        public Reaction reaction { get; set; }

        public List<Comment> comments { get; set; }

        public Comment comment { get; set; }

        public List<Notification> notifications { get; set; }

        public Notification notification { get; set; }

        public List<NotificationReceiver> notificationReceivers { get; set; }

        public NotificationReceiver notificationReceiver { get; set; }

        public List<NotificationSender> notificationSenders { get; set; }

        public NotificationSender notificationSender { get; set; }

        public List<Message> messages { get; set; }
        public Message message { get; set; }

        public List<Friend> friends { get; set; }
        public Friend friend { get; set; }

        public IList<IFormFile> files { get; set; }

        public List<CustomIdentityUser> AllUsers { get; set; }
        public List<CustomIdentityUser> ActiveUsers { get; set; }

        public CustomIdentityUser customIdentityUser { get; set; }

        public Microsoft.AspNetCore.Identity.UserManager<CustomIdentityUser> _userManager { get; set; }

        public CustomIdentityUser ReceiverUser { get; set; }
        public CustomIdentityUser SenderUser { get; set; }

        

    }
}
