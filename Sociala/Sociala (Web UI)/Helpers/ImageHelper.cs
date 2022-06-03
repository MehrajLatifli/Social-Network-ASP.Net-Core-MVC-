namespace Sociala__Web_UI_.Helpers
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _webhost;

        public ImageHelper(IWebHostEnvironment webhost)
        {
            _webhost = webhost;
        }

        public async Task<string> SaveFile(string username, IFormFile file)
        {
            string userfile = null;

           
                userfile = username + " " + file.FileName;

                var saveimg = Path.Combine(_webhost.WebRootPath, "images/UserProfileImage", userfile);
                //string imgText = Path.GetExtension(file.FileName);
                using (var img = new FileStream(saveimg, FileMode.Create))
                {
                    await file.CopyToAsync(img);
                }

            

       

            return userfile.ToString();
        }
    }
}

