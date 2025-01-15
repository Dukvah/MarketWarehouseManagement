namespace Core.Utilities.Helpers.FileHelper
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            //return Guid.NewGuid().ToString();
            return "ProductImage" + DateTime.Now.Date.ToString("dd-MM-yyyy");
        }
    }
}