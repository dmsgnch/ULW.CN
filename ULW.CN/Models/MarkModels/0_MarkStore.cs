namespace ULW.CN.Models.MarkModels;

/// <summary>
/// Stores all mark objects. By default they can be null!
/// </summary>
internal static class MarkStore
{
    internal static HardRewriteText HardRewriteText { get; set; }
    internal static Paraphraser Paraphraser { get; set; }
    internal static TeacherInfo TeacherInfo { get; set; }
    internal static UserInfo UserInfo { get; set; }
    internal static ContentHandler ContentHandler { get; set; }

    static MarkStore()
    {
        HardRewriteText = new HardRewriteText();
        Paraphraser = new Paraphraser();
        ContentHandler = new ContentHandler();
    }
}