namespace AgileOutlook.Core.Mail
{
    public class ManifestOption
    {
        public ManifestOption()
        {
            ShowInInspectorRead = true;
            ShowInInspectorCompose = true;
            ShowInReadingPane = true;
        }
        public bool ShowInReadingPane { get; set; }

        public bool ShowInInspectorRead { get; set; }

        public bool ShowInInspectorCompose { get; set; }
    }
}