using Stylet;
using System.Diagnostics;
using System.IO;

namespace FlowTools.ViewModels
{
    public class RootViewModel : PropertyChangedBase
    {
        public BindableCollection<LinkData> Links { get; set; } = new();

        public void AddLink()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog() { Multiselect = true };
            bool? fileDialogResult = dialog.ShowDialog();
            if (fileDialogResult ?? false)
            {
                foreach (string fileName in dialog.FileNames)
                {
                    var path = Path.GetFullPath(fileName);
                    Links.Add(new LinkData()
                    {
                        Path = path,
                        Name = Path.GetFileNameWithoutExtension(path)
                    });
                }
            }
        }

        public void OpenLink(LinkData linkData)
        {
            Debug.WriteLine($"Opening {linkData.Name}");
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(linkData.Path)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }

        public void RemoveLink(LinkData linkData)
        {
            Debug.WriteLine($"Removing {linkData.Name}");
            Links.Remove(linkData);
        }
        public RootViewModel()
        {

        }
    }
}
