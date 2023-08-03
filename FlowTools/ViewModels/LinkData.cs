using Stylet;
using System.Windows.Media.Imaging;

namespace FlowTools.ViewModels
{
    public class LinkData : PropertyChangedBase
    {
        public BitmapImage Icon
        {
            get
            {
                var img = System.Drawing.Icon.ExtractAssociatedIcon(Path).ToBitmap();
                return Tools.ImageUtility.BitmapToBitmapImage(img);
            }
        }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}
