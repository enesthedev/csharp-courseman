namespace Courseman.Common.Attributes;

public class FillableAttribute : Attribute
{
    public FillableAttribute(string friendlyName = "")
    {
        FriendlyName = friendlyName;
    }

    public string FriendlyName { get; set; }
}