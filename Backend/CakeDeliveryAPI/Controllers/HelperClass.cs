namespace CakeDeliveryAPI.Controllers
{
    public class HelperClass
    {
      //  private readonly static string _uploadsFolderPath = Path.Combine("wwwroot", "uploads", "cakes");
        public static async Task<string> SaveImageAsync(IFormFile imageFile , string entity)
        {
            if (imageFile == null || imageFile.Length == 0) return null;
            if (imageFile.ContentType != "image/jpeg" && imageFile.ContentType != "image/png")
                return null;

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
            var fullImagePath = Path.Combine(Path.Combine("wwwroot", "uploads", entity), fileName);

            try
            {
                await using var stream = new FileStream(fullImagePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                return $"/uploads/{entity}/{fileName}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
                return null;
            }
        }
    }
}
