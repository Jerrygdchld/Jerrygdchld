using MediatR;

namespace caapp.www.Server.Commands
{
    public record GetImageCommand(string Name) : IRequest<(byte[] ImageData, string MimeType)>;
    public class GetImageCommandHandler : IRequestHandler<GetImageCommand, (byte[] ImageData, string MimeType)>
    {
        public async Task<(byte[] ImageData, string MimeType)> Handle(GetImageCommand request, CancellationToken cancellationToken)
        {
            var di = new DirectoryInfo("./images");
            var image = di.GetFiles().FirstOrDefault(x => x.Name.Contains(request.Name));
            if (image != null)
            {
                var imageData = await File.ReadAllBytesAsync(image.FullName);
                var mimeType = GetMimeType(image.Extension);
                return new(imageData, mimeType);
            }
            return await ImageNotFound();
        }

        private static string GetMimeType(string ext)
        {
            return ext switch
            {
                ".png" => "image/png",
                _ => "image/jpeg"
            };
        }

        private async Task<(byte[] ImageData, string MimeType)> ImageNotFound()
        {
            var di = new DirectoryInfo("./images");
            var image = di.GetFiles().FirstOrDefault(x => x.Name.Contains("ImageComing"));
            if (image != null)
            {
                var imageData = await File.ReadAllBytesAsync(image.FullName);
                var mimeType = GetMimeType(image.Extension);
                return new(imageData, mimeType);
            }
            return new(Array.Empty<byte>(), GetMimeType(""));
        }
    }
}
