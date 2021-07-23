using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trial_App.Pages.Cloud_Storage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        FirebaseStorage firebase = new FirebaseStorage("fir-demo-71fa5.appspot.com");
        public Stream Stream;
        public string FileName;

        public Page1()
        {
            InitializeComponent();
        }

        private async Task<PermissionStatus> CheckPermissions()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
            {
                var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // or general UTType values
                    { DevicePlatform.Android, new[] { "*/*" } },
                    { DevicePlatform.UWP, new[] { ".cbr", ".cbz" } },
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // or general UTType values
                });
                var options = new PickOptions
                {
                    PickerTitle = "Please select an image",
                    FileTypes = customFileType,
                };
                await PickAndShow(options);
            }

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }
        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        imageViewer.Source = ImageSource.FromStream(() => stream);
                        Stream = stream;
                        FileName = result.FileName;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }

        public async Task<string> UploadFileFunc(Stream fileStream, string fileName)
        {
            var fileDetails = await firebase.Child("MyUploads").Child(fileName).PutAsync(fileStream);

            return fileDetails;

            //firebase = new
            //FirebaseStorage("fir-demo-71fa5.appspot.com");
            //var imageurl = firebase
            //        .Child("FileUploading")
            //        .Child(fileName)
            //        .PutAsync(fileStream);
            //var data = imageurl;
            //return data.TargetUrl;
        }

        private async void selectFile(object sender, EventArgs e)
        {
            await CheckPermissions();
        }

        private async void uploadFile(object sender, EventArgs e)
        {
            await UploadFileFunc(Stream, FileName);
            await DisplayAlert("", "Upload Successful", "Ok");
        }
    }
}