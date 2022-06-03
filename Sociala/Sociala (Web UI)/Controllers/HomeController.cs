using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Sociala__Web_UI_.Entities;
using Sociala__Web_UI_.Helpers;
using Sociala__Web_UI_.Models;
using Sociala__Web_UI_.Services;
using Sociala_Business.Abstract;
using Sociala_Entities.Concrete.DatabaseFirst;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;


namespace Sociala__Web_UI_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private Microsoft.AspNetCore.Identity.UserManager<CustomIdentityUser> _userManager;

        private ICommentService _commentService;
        private INotificationService _notificationService;
        private INotificationSessionService _notificationSessionService;
        private IPostandTagService _postandTagService;
        private ITagService _tagService;
        private IPostService _postService;
        private IReactionService _reactionService;
        private IUserService _userService;
        private IMessageService _messageService;
        private IFriendService _friendService;

        private IHttpContextAccessor _httpContextAccessor;

        private CustomIdentityDbContext _customdbContextforSociala;
        private SocialadbContext _socialadbContext;

        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(ICommentService commentService, INotificationService notificationService, INotificationSessionService notificationSessionService, IPostandTagService postandTagService, IPostService postService, IReactionService reactionService, IUserService userService, CustomIdentityDbContext customdbContextforSociala, SocialadbContext socialadbContext, Microsoft.AspNetCore.Identity.UserManager<CustomIdentityUser> userManager, IWebHostEnvironment webHostEnvironment, ITagService tagService, IHttpContextAccessor httpContextAccessor, IMessageService messageService, IFriendService friendService)
        {
            _commentService = commentService;
            _notificationService = notificationService;
            _notificationSessionService = notificationSessionService;
            _postandTagService = postandTagService;
            _postService = postService;
            _reactionService = reactionService;
            _userService = userService;
            _customdbContextforSociala = customdbContextforSociala;
            _socialadbContext = socialadbContext;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _tagService = tagService;
            _httpContextAccessor = httpContextAccessor;
            _messageService = messageService;
            _friendService = friendService;
        }


        Stopwatch stopwatch = Stopwatch.StartNew();

        Stopwatch stopwatch2 = Stopwatch.StartNew();

        int count;

        int count2;

        int count3;

        long ReactionCount_1 = 0;
        long ReactionCount_2 = 0;
        long ReactionCount_3 = 0;
        long ReactionCount_4 = 0;
        long ReactionCount_5 = 0;
        long ReactionCount_6 = 0;
        long ReactionCount_7 = 0;
        long ReactionCount_8 = 0;


        [HttpGet]
        public async Task<IActionResult> Index(PostViewModel postViewModel)
        {
            stopwatch.Start();


            int id = 0;

            var user = await _userManager.GetUserAsync(HttpContext.User);
            UserHelper.CurrentUser = user;
            ViewBag.User = user;
            var users = _userManager.Users.Where(u => u.Id != user.Id).ToList();
            foreach (var item in users)
            {
                var onlineUser = UserHelper.ActiveUsers.FirstOrDefault(u => u.Id == item.Id);
                if (onlineUser != null)
                {
                    item.IsOnline = true;
                }
            }

            postViewModel.AllUsers = users;
            postViewModel.ActiveUsers = UserHelper.ActiveUsers;

            var currentusername2 = _userManager.GetUserName(User);

            foreach (var item in _userService.GetAll().ToList())
            {
                if (currentusername2 == item.Username)
                {

                    ViewBag.orginaluserid = item.Id;


                }

            }


            using (var context = _customdbContextforSociala)
            {


                foreach (var item in context.Users)
                {

                    postViewModel.user_ = new User
                    {
                        UserOnlineDate = DateTime.Now.ToString(),
                        Username = item.UserName,
                        EmailAddress = item.Email,
                        Password = item.PasswordHash,
                        ConfirmPassword = item.PasswordHash,
                        UserFilepath = item.ProfilePicture

                    };

                    _userService.Add(postViewModel.user_);
                }





                count = _userService.GetAll().Select(x => x.Id).Count();
                count2 = _customdbContextforSociala.Users.ToList().Select(x => x.Id).Count();

                Debug.WriteLine(count2);


                try
                {
                    if (count2 == 0)
                    {
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.[User]");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Post");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Tag");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.PostandTag");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Reaction");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Comment");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.[NotificationSender]");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.[NotificationReceiver]");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.[Notification]");



                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.[User]', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Post', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Tag', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.PostandTag', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Reaction', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Comment', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.[Notification]', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.[NotificationSender]', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.[NotificationReceiver]', RESEED, 0)");

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }



                //if (count2 > count || count >= 0)
                //{
                //    _userService.Add(postViewModel.user_);

                //}





                //  _userService.GetAll().ToList().ForEach(x=>ViewBag.IdUser = x.Id);


                //ViewBag.IdUser = HttpContext.User.Identity.Name;


                var currentusername = _userManager.GetUserName(User);

                foreach (var item in _userService.GetAll().ToList())
                {
                    if (currentusername == item.Username)
                    {
                        ViewBag.IdUser = item.Id;
                        ViewBag.UserImage = item.UserFilepath;
                        ViewBag.Username = item.Username;
                        id = item.Id;


                    }

                }




                foreach (var item in _postService.GetAll().ToList())
                {
                    ViewBag.PostImage = item.PostImage;
                    ViewBag.PostVideo = item.PostVideo;
                    ViewBag.PostDate = item.PostDate;
                }








                if (count > 0)
                {

                    // var d = _userService.GetAll().ToList().Where(m => m.IdUser == 5).First();

                    // if (d.IdUser == null)
                    // {
                    //     throw new Exception();
                    // }

                    //// d.Username = "3423";

                    // // _userService.Update(d);

                    // //Debug.WriteLine(d.Username);

                    //  _userService.Delete(d);

                }




                stopwatch.Stop();

                //var task = Task.Delay((int)stopwatch.ElapsedMilliseconds).ContinueWith(t => _userService.Delete(user));

                //task.Wait();


                //_userService.GetAll().ForEach(x =>
                //ViewData["message"] = stopwatch.ElapsedMilliseconds.ToString() + " Millisecond \t \t Welcome " + x.Username);

                ViewData["message"] = stopwatch.ElapsedMilliseconds.ToString() + " Millisecond \t \t Welcome " + currentusername;

                //foreach (var item in _userService.GetAll())
                //{
                //    ViewData["message"] = item.Username.ToString();


                //    Debug.Write(item.Username+" ");

            }


            using (var context = _socialadbContext)
            {


                //ViewBag.IdPost = _postService.GetAll().ToList().ElementAt(_postService.GetAll().ToList().Count - 1).Id;

                //ViewBag.IdTag = _tagService.GetAll().ToList().ElementAt(_tagService.GetAll().ToList().Count - 1).Id;

                count3 = _socialadbContext.Post.ToList().Select(x => x.Id).Count();

                ViewBag.Count3 = count3;

                try
                {
                    if (count3 == 0)
                    {

                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Post");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Tag");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.PostandTag");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Reaction");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.Comment");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.[Notification]");
                        context.Database.ExecuteSqlRaw(@"  delete from SocialaDb.dbo.[NotificationLine]");




                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Post', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Tag', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.PostandTag', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Reaction', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.Comment', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.[Notification]', RESEED, 0)");
                        context.Database.ExecuteSqlRaw(@"  DBCC CHECKIDENT ('SocialaDb.dbo.[NotificationLine]', RESEED, 0)");

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }



                postViewModel.tags = _tagService.GetAll().ToList();

                postViewModel.posts = _postService.GetAll().ToList();

                postViewModel.postandTags = _postandTagService.GetAll().ToList();

                postViewModel.reactions = _reactionService.GetAll().ToList();

                postViewModel.comments = _commentService.GetAll().ToList();

                postViewModel.messages = _messageService.GetAll().ToList();

                postViewModel.friends = _friendService.GetAll().ToList();




                postViewModel.postandTags = context.PostandTag.Include(t => t.TagIdForPostandTagNavigation).ToList();

                postViewModel.posts = context.Post.Include(t => t.UserIdForPostNavigation).ToList().OrderByDescending(i => i.PostDate).ToList();

                postViewModel.reactions = context.Reaction.Include(r => r.PostIdForReactionNavigation).Include(r => r.UserIdForReactionNavigation).ToList();

                postViewModel.comments = context.Comment.Include(r => r.PostIdForCommentNavigation).Include(r => r.UserIdForCommentNavigation).ToList();


                postViewModel.messages = context.Message.Include(b => b.ReceiverUser).Include(b => b.SenderUser).ToList();


                postViewModel.friends = context.Friend.Include(b => b.UserIdForFriendNavigation).ToList();


                ReactionCount_1 = context.Reaction.Where(i => i.Reaction1 != null).Select(x => x.Reaction1).Count();
                ReactionCount_2 = context.Reaction.Where(i => i.Reaction2 != null).Select(x => x.Reaction2).Count();
                ReactionCount_3 = context.Reaction.Where(i => i.Reaction3 != null).Select(x => x.Reaction3).Count();
                ReactionCount_4 = context.Reaction.Where(i => i.Reaction4 != null).Select(x => x.Reaction4).Count();
                ReactionCount_5 = context.Reaction.Where(i => i.Reaction5 != null).Select(x => x.Reaction5).Count();
                ReactionCount_6 = context.Reaction.Where(i => i.Reaction6 != null).Select(x => x.Reaction6).Count();
                ReactionCount_7 = context.Reaction.Where(i => i.Reaction7 != null).Select(x => x.Reaction7).Count();
                ReactionCount_8 = context.Reaction.Where(i => i.Reaction8 != null).Select(x => x.Reaction8).Count();

                ViewBag.ReactionCount_1 = ReactionCount_1;
                ViewBag.ReactionCount_2 = ReactionCount_2;
                ViewBag.ReactionCount_3 = ReactionCount_3;
                ViewBag.ReactionCount_4 = ReactionCount_4;
                ViewBag.ReactionCount_5 = ReactionCount_5;
                ViewBag.ReactionCount_6 = ReactionCount_6;
                ViewBag.ReactionCount_7 = ReactionCount_7;
                ViewBag.ReactionCount_8 = ReactionCount_8;

                Debug.WriteLine(ReactionCount_1 + " likes");

                postViewModel.comment = new Comment();
                postViewModel.tag = new Tag();
                postViewModel.postandTag = new PostandTag();
                postViewModel.post = new Post();
                postViewModel.reaction = new Reaction();
                postViewModel.message = new Message();
                postViewModel.friend = new Friend();

                //postViewModel.notification = new Notification();



                context.Database.ExecuteSqlRaw($@"Delete PostandTag where Id in(    
                          Select s.Id From PostandTag s Inner Join PostandTag s1     
                          On s.PostId_forPostandTag=s1.PostId_forPostandTag And s.TagId_forPostandTag=s1.TagId_forPostandTag   
                          Where s.Id>s1.Id)");

                context.Database.ExecuteSqlRaw($@"Delete [User] where Id in(    
                          Select s.Id From [User] s Inner Join [User] s1     
                          On s.Username=s1.Username And s.Username=s1.Username   
                          Where s.Id>s1.Id)");
            }





            return View(postViewModel);
        }



        //[HttpPut]
        //public IActionResult Updatecurrentuserdate([FromBody] User user)
        //{

        //    try
        //    {

        //        var currentusername = _userManager.GetUserName(User);

        //        using (var context = _socialadbContext)
        //        {



        //            foreach (var item in _userService.GetAll().ToList())
        //            {
        //                if (currentusername == item.Username)
        //                {
        //                    // item.UserFilepath.Replace("/images/UserProfileImage/images/UserProfileImage", "/images/UserProfileImage");

        //                    user.Username = item.Username;
        //                    user.EmailAddress = item.EmailAddress;
        //                    user.Password = item.Password;
        //                    user.UserFilepath = item.UserFilepath;
        //                    user.ConfirmPassword = item.ConfirmPassword;


        //                }

        //            }

        //            _userService.Update(user);
        //        }



        //    }
        //    catch (DbUpdateException EX)
        //    {


        //    }

        //    return StatusCode(StatusCodes.Status204NoContent);
        //}

        public async Task<IActionResult> GetAllActiveUsers()
        {
            return Ok(UserHelper.ActiveUsers.DistinctBy(u => u.Id));
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var users = _userManager.Users.Where(u => u.UserName != user.UserName).ToList();

            foreach (var item in users)
            {
                var onlineUser = UserHelper.ActiveUsers.FirstOrDefault(u => u.Id == item.Id);
                if (onlineUser != null)
                {
                    item.IsOnline = true;
                }
            }
            return Ok(users);
        }





        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {


            var currentusername = _userManager.GetUserName(User);

            int id = 0;

            using (var context = _socialadbContext)
            {

                foreach (var item in _userService.GetAll().ToList())
                {
                    if (currentusername == item.Username)
                    {
                        id = item.Id;
                    }

                }

                var postandTags = context.PostandTag.Where(i => i.Id == id).Include(b => b.TagIdForPostandTagNavigation).ToList();

                var postreactions = context.Reaction.Where(i => i.Id == id).Include(r => r.PostIdForReactionNavigation).Include(r => r.UserIdForReactionNavigation).ToList();

                var postuser = context.User.Where(i => i.Id == id).FirstOrDefault();

                post.UserIdForPost = postuser.Id;




                //post = new Post
                //{
                //    PostMessage = "1",
                //    PostDate = "Null",
                //    UserIdForPost = 1,
                //};

                _postService.Add(post);
            }









            return NoContent();



        }






        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
        [RequestSizeLimit(2147483648)]
        public async Task<IActionResult> UploadFiles(IList<IFormFile> files)
        {
            stopwatch2.Start();


            long size = files.Sum(f => f.Length);

            string fileName = null;

            string fullPath = null;


            foreach (IFormFile source in files)
            {
                if (source.Length > 0)
                {
                    // Get original file name to get the extension from it.
                    string orgFileName = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Value;

                    // Create a new file name to avoid existing files on the server with the same names.
                    fileName = orgFileName;

                    fullPath = GetFullPathOfFile(fileName);

                    // Create the directory.
                    Directory.CreateDirectory(Directory.GetParent(fullPath).FullName);

                    // Save the file to the server.
                    await using FileStream output = System.IO.File.Create(fullPath);
                    await source.CopyToAsync(output);
                }
            }

            var response = new { count = files.Count, size, fullPath };

            stopwatch2.Stop();

            ViewBag.Timer = stopwatch2.ElapsedMilliseconds;

            Debug.WriteLine("Timer: " + stopwatch2.ElapsedMilliseconds.ToString());

            return Ok(response);
        }


        private string GetFullPathOfFile(string fileName)
        {
            return $"{_webHostEnvironment.WebRootPath}\\uploads\\{fileName}";
        }



        [HttpGet]
        public IActionResult GetPost()
        {

            return Ok(_postService.GetAll().ToList().OrderBy(i => i.PostDate));

        }


        [HttpPost]
        public IActionResult AddTag([FromBody] Tag tag)
        {




            using (var context = _socialadbContext)
            {
                _tagService.Add(tag);
            }

            return NoContent();

        }


        [HttpGet]
        public IActionResult GetTag()
        {


            return Ok(_tagService.GetAll().ToList());

        }

        [HttpPost]
        public IActionResult AddPostandTag([FromBody] PostandTag postandTag)
        {
            using (var context = _socialadbContext)
            {
                try
                {

                    for (int k = 0; k < _postService.GetAll().ToList().Count; k++)
                    {


                        if (_postService.GetAll().ToList().ElementAt(k).Id >= 0)
                        {
                            var id = _postService.GetAll().ToList().ElementAt(_postService.GetAll().ToList().Count - 1).Id;
                            postandTag.PostIdForPostandTag = id;

                        }

                        if (_tagService.GetAll().ToList().ElementAt(k).Id >= 0)
                        {
                            var id2 = _tagService.GetAll().ToList().ElementAt(_tagService.GetAll().ToList().Count - 1).Id;
                            postandTag.TagIdForPostandTag = id2;

                        }


                        context.Database.ExecuteSqlRaw($@"Delete PostandTag where Id in(    
                          Select s.Id From PostandTag s Inner Join PostandTag s1     
                          On s.PostId_forPostandTag=s1.PostId_forPostandTag And s.TagId_forPostandTag=s1.TagId_forPostandTag   
                          Where s.Id>s1.Id)");

                    }



                    //var id = _postService.GetAll().ToList().ElementAt(_postService.GetAll().ToList().Count - 1).Id;
                    //postandTag.PostIdForPostandTag = id;




                    //var id2 = _tagService.GetAll().ToList().ElementAt(_tagService.GetAll().ToList().Count - 1).Id;
                    //postandTag.TagIdForPostandTag = id2;





                    _postandTagService.Add(postandTag);

                }
                catch (Exception ex)
                {
                    throw ex;
                }




            }



            return NoContent();

        }


        public IActionResult GetCurrentPost(string ReactionPostId)
        {


            //Debug.WriteLine(rpi + " ReactionPostId");

            FileWriteandRead.writetextfile(ReactionPostId);


            return NoContent();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReaction([FromForm] Reaction reaction)
        {
            var currentusername = string.Empty;

            using (var context = _customdbContextforSociala)
            {

                currentusername = _userManager.GetUserName(User);
            }

            using (var context = _socialadbContext)
            {

                try
                {

                    Debug.WriteLine(FileWriteandRead.readtextfile() + " ReactionPostId");



                    try
                    {
                        var id = _postService.GetAll().ToList().Where(i => i.Id == Convert.ToInt32(FileWriteandRead.readtextfile())).FirstOrDefault();

                        reaction.PostIdForReaction = id.Id;
                    }
                    catch (Exception)
                    {


                    }


                    //ViewBag.PostIdForReaction = id;

                    var currentuser = _userService.GetAll().ToList().Where(u => u.Username == currentusername).FirstOrDefault();
                    reaction.UserIdForReaction = currentuser.Id;


                    //ViewBag.UserIdForReaction = id2;

                    var count = _reactionService.GetAll().Where(r => r.Reaction1 != null).Select(x => x.Id).Count();





                    _reactionService.Add(reaction);

                    context.Database.ExecuteSqlRaw($@"Delete Reaction where Id in(    
                          Select s.Id From Reaction s Inner Join Reaction s1     
                          On s.PostId_forReaction=s1.PostId_forReaction And s.UserId_forReaction=s1.UserId_forReaction   
                          Where s1.Id>s.Id)");

                }
                catch (Exception ex)
                {
                    throw ex;
                }




            }


            return Json(new { success = true });


        }






        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            using (var context = _socialadbContext)
            {
                try
                {

                    var currentusername = _userManager.GetUserName(User);

                    int curid = 0;


                    foreach (var item in _userService.GetAll().ToList())
                    {
                        if (currentusername == item.Username)
                        {
                            curid = item.Id;
                        }

                    }




                    var post = _postService.GetAll().ToList().Where(i => i.Id == Convert.ToInt32(FileWriteandRead.readtextfile())).FirstOrDefault();
                    comment.PostIdForComment = post.Id;

                    ViewBag.PostIdForComment = post.Id;




                    var commentuser = context.User.Where(i => i.Id == curid).FirstOrDefault();

                    comment.UserIdForComment = commentuser.Id;

                    ViewBag.UserIdForComment = commentuser.Id;

                    //comment.CommentDate=DateTime.Now.ToShortDateString();



                    //int curid = 0;

                    //var currentusername = _userManager.GetUserName(User);

                    //foreach (var item in _userService.GetAll().ToList())
                    //{
                    //    if (currentusername == item.Username)
                    //    {
                    //        curid = item.Id;
                    //    }

                    //}

                    //var comments = context.Comment.Where(i => i.Id == curid).Include(r => r.PostIdForCommentNavigation).Include(r => r.UserIdForCommentNavigation).ToList();


                    var comments = context.Comment.Include(r => r.PostIdForCommentNavigation).Include(r => r.UserIdForCommentNavigation).ToList();

                    _commentService.Add(comment);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return NoContent();

        }



      static  int receiveruserId = 0;

        static int senderid = 0;

        
            static string image = string.Empty;

        static List<Message> receiverusermessage = new List<Message>();

        [HttpGet("FindCurrentUser/{id?}")]
        public IActionResult FindCurrentUser(string id)
        {


            UserHelper.ReceiverUser = _userManager.Users.FirstOrDefault(u => u.Id == id);

            receiveruserId = _userService.GetAll().Where(i => i.Username == UserHelper.ReceiverUser.UserName).ToList().FirstOrDefault().Id;

            ViewBag.RecId = receiveruserId;

            var receiverimage = _userService.GetAll().Where(i => i.Username == UserHelper.ReceiverUser.UserName).ToList().FirstOrDefault();

            ViewBag.Receiverimage = receiverimage.UserFilepath;


            var currentusername = _userManager.GetUserName(User);


            foreach (var item in _userService.GetAll().ToList())
            {
                if (currentusername == item.Username)
                {

                    senderid = item.Id;

                    image = item.UserFilepath;
                }

            }

            Debug.WriteLine(" receiveruserId: " + receiveruserId + " senderid: " + senderid);

            ViewBag.senderid = senderid;

            //Microsoft.Data.SqlClient.SqlParameter[] parameters = {
            //new Microsoft.Data.SqlClient.SqlParameter("receiveruserId", receiveruserId),
            //new Microsoft.Data.SqlClient.SqlParameter("senderuserId", senderid)
            //    };

            //var r = _socialadbContext.Message.FromSqlRaw($"EXECUTE SocialaDb.dbo.currentchat @receiveruserId, @senderuserId", parameters).AsEnumerable().Select(a => new Message
            //{
            //    Id = a.Id,
            //    MessageText = a.MessageText,
            //    MessageDate = a.MessageDate,
            //    ReceiverUser = a.ReceiverUser,
            //    ReceiverUserId = a.ReceiverUserId,
            //    SenderUser = a.SenderUser,
            //    SenderUserId = a.SenderUserId
            //}).ToList();

            //var r = _socialadbContext.Message.FromSqlRaw($"EXECUTE SocialaDb.dbo.currentchat {receiveruserId} {senderid}").Include(b => b.ReceiverUser).Include(b => b.SenderUser).Where(x => x != null).AsEnumerable();




            //  receiverusermessage = (from user in _userService.GetAll().ToList() join mesg in _messageService.GetAll().ToList() on user.Id equals mesg.ReceiverUserId where mesg.ReceiverUserId == receiveruserId && mesg.SenderUserId == senderid select new { mesg.MessageText, mesg.MessageDate, mesg.SenderUserId, mesg.ReceiverUserId }).Select(o => new Message { MessageDate = o.MessageDate, MessageText = o.MessageText, SenderUserId = o.SenderUserId, ReceiverUserId = o.ReceiverUserId }).ToList();

            // var a = _messageService.GetAll().ToList().Join(_userService.GetAll().ToList(), m => m.ReceiverUserId, u => u.Id, (m, u) => new { m, u }).Where(sc => sc.m.ReceiverUserId == receiveruserId && sc.m.SenderUserId == senderid).ToList();


          //  receiverusermessage = _messageService.GetAll().ToList().Join(_userService.GetAll().ToList(), m => m.ReceiverUserId, u => u.Id, (m, u) => new { m, u }).Where(sc => sc.m.ReceiverUserId == receiveruserId && sc.m.SenderUserId == senderid).ToList().Select(x => new Message { Id = x.m.Id, MessageDate = x.m.MessageDate, MessageText = x.m.MessageText, SenderUserId = x.m.SenderUserId, ReceiverUserId = x.m.ReceiverUserId }).ToList();


            receiverusermessage = _messageService.GetAll().ToList().Join(_userService.GetAll().ToList(), m => m.ReceiverUserId, u => u.Id, (m, u) => new { m, u }).Where(sc => sc.m.ReceiverUserId == receiveruserId && sc.m.SenderUserId == senderid || sc.m.SenderUserId == receiveruserId && sc.m.ReceiverUserId == senderid).ToList().Select(x => new Message { Id = x.m.Id, MessageDate = x.m.MessageDate, MessageText = x.m.MessageText, SenderUserId = x.m.SenderUserId, ReceiverUserId = x.m.ReceiverUserId }).ToList();


            return Json(UserHelper.ReceiverUser);
        }


        [HttpPost]
        public async Task <IActionResult> AddMessage([FromForm] Message message)
        {

            var currentusername = _userManager.GetUserName(User);

            int id = 0;

            using (var context = _socialadbContext)
            {

                foreach (var item in _userService.GetAll().ToList())
                {
                    if (currentusername == item.Username)
                    {
                        id = item.Id;
                    }

                }

                var messages = context.Message.Where(i => i.Id == id).Include(b => b.ReceiverUser).Include(b => b.SenderUser).ToList();


                //var messagesender = context.User.Where(i => i.Id == id).FirstOrDefault();

                message.SenderUserId = id;



                ViewBag.SenderId = id;

                message.ReceiverUserId = _userService.GetAll().Where(i => i.Username == UserHelper.ReceiverUser.UserName).ToList().FirstOrDefault().Id;

                ViewBag.ReceiverId = message.ReceiverUserId;

                if (message.ReceiverUserId != message.SenderUserId)
                {
                    receiverusermessage.Add(message);
                    _messageService.Add(message);
                } 


            }




            //  context.Database.ExecuteSqlRaw("currentchat @receiveruserId, @senderuserId", parameters: new[] { receiveruserId, senderid });

            //var r= _socialadbContext.Message.FromSqlRaw($"EXECUTE SocialaDb.dbo.currentchat {receiveruserId} {senderid}").Include(b => b.ReceiverUser).Include(b => b.SenderUser).ToList().Where(x=>x !=null);





            return Json(message);



        }


        public static List<T> CreateList<T>(params T[] elements)
        {
            return new List<T>(elements);
        }

        static int sid = 0;
        static int rid = 0;
        public List<Message> result { get; set; }



        public async Task<IActionResult> GetMessage(string imag, string username)
        {


  
            using (var context = _socialadbContext)
            {

                //    var receiverusermessage = from user in context.User join mesg in context.Message on user.Id equals mesg.ReceiverUserId where mesg.ReceiverUserId == receiveruserId && mesg.SenderUserId==fromid select new { mesg.MessageText, mesg.MessageDate, mesg.SenderUserId, mesg.ReceiverUserId };


                //    receiverusermessage.ToList();

                //    foreach (var item in receiverusermessage.ToList())
                //    {
                //        Debug.WriteLine(item.MessageText + " text");
                //    }


                //var result = context.User.Join(context.Message, user => user.Id, msg => msg.ReceiverUserId, (user, msg) => new { user.Id}).ToList();


                //context.Database.ExecuteSqlRaw($@"select
                //SocialaDb.dbo.[Message].MessageText,
                //SocialaDb.dbo.[Message].MessageDate,
                //SocialaDb.dbo.[Message].SenderUserId,
                //SocialaDb.dbo.[Message].ReceiverUserId
                //from SocialaDb.dbo.[Message]
                //INNER JOIN SocialaDb.dbo.[User]
                //ON SocialaDb.dbo.[Message].ReceiverUserId = SocialaDb.dbo.[User].Id
                //where
                //SocialaDb.dbo.[Message].ReceiverUserId={toid}
                //and
                //SocialaDb.dbo.[Message].SenderUserId={fromid}");

                //result = new List<Message>(r);
            }



            //var receiverusermessage = (from user in _userService.GetAll().ToList() join mesg in _messageService.GetAll().ToList() on user.Id equals mesg.ReceiverUserId where mesg.ReceiverUserId == toid && mesg.SenderUserId == fromid select new { mesg.MessageText, mesg.MessageDate, mesg.SenderUserId, mesg.ReceiverUserId }).Select(o=> new Message { MessageDate=o.MessageDate, MessageText=o.MessageText, SenderUserId=o.SenderUserId, ReceiverUserId=o.ReceiverUserId });

            //List<Message> messages = new List<Message>();

            //messages.AddRange(receiverusermessage);


            //var a=   _messageService.GetAll().ToList().Join(_userService.GetAll().ToList(),m => m.ReceiverUserId,u => u.Id,(m, u) => new { m, u }).Where(sc => sc.m.ReceiverUserId == toid && sc.m.SenderUserId == fromid).ToList();

               



            var currentusername = _userManager.GetUserName(User);


            using (var context = _socialadbContext)
            {

                foreach (var item in _userService.GetAll().ToList())
                {
                    if (currentusername == item.Username)
                    {
                        sid = item.Id;
                    }

                }

            }

            if (UserHelper.ReceiverUser != null)
            {
                rid = _userService.GetAll().Where(i => i.Username == UserHelper.ReceiverUser.UserName).ToList().FirstOrDefault().Id;
            }

            if(rid == receiveruserId && sid== senderid)
            {
                receiverusermessage.OrderBy(i => i.MessageDate);
            }

            return Ok(receiverusermessage);

            //return Ok(result);
        }




        [HttpPost]
        public async Task<IActionResult> AddFriend([FromBody] Friend friend)
        {

            var currentusername = _userManager.GetUserName(User);

            int id = 0;

            using (var context = _socialadbContext)
            {

                foreach (var item in _userService.GetAll().ToList())
                {
                    if (currentusername == item.Username)
                    {
                        id = item.Id;
                    }

                }



                friend = new Friend()
                {
                    UserIdForFriend = senderid,
                    FriendName = currentusername
                };

               





                    _friendService.Add(friend);
                


            }




            //  context.Database.ExecuteSqlRaw("currentchat @receiveruserId, @senderuserId", parameters: new[] { receiveruserId, senderid });

            //var r= _socialadbContext.Message.FromSqlRaw($"EXECUTE SocialaDb.dbo.currentchat {receiveruserId} {senderid}").Include(b => b.ReceiverUser).Include(b => b.SenderUser).ToList().Where(x=>x !=null);





            return Ok(friend);



        }




        public async Task<IActionResult> GetFriend()
        {
            foreach (var item in _friendService.GetAll())
            {
                Debug.WriteLine(item.FriendName);
            }


            return Ok(_friendService.GetAll().ToString());

            //return Ok(result);
        }


        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
    }
}
