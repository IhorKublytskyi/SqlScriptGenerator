using Microsoft.Extensions.FileProviders;

namespace Service.Models
{
    public class ScriptResult
    {
        IFileInfo ScriptFile { get; set; } = null!;
    }
}
