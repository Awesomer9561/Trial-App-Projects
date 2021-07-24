using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
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
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        MediaFile file;
        

        public Page1()
        {
            InitializeComponent();
        }

        private async Task<PermissionStatus> CheckPermissions()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
            {
                PickImage();
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

        private async void PickImage()
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
                imageViewer.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void selectFile(object sender, EventArgs e)
        {
            await CheckPermissions();
            

            //await App.Current.MainPage.DisplayAlert("Success", FileName + " selected", "OK");
        }

        private async void uploadFile(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(fileNameEntry.Text))
            {
                var FileName = Path.GetFileName(file.Path);
                await firebaseStorageHelper.UploadFile(file.GetStream(), FileName);
                await App.Current.MainPage.DisplayAlert("Success", FileName + " uploaded to cloud", "OK");
            }
            else
            {
                var FileName = fileNameEntry.Text;
                await firebaseStorageHelper.UploadFile(file.GetStream(), FileName);
                await App.Current.MainPage.DisplayAlert("Success", FileName + " uploaded to cloud", "OK");
            }

        }

        private async void downloadFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileNameEntry.Text))
            {
                await App.Current.MainPage.DisplayAlert("", "Please enter a file name", "Ok");
                return;
            }
            else
            {
                string path = await firebaseStorageHelper.GetFile(fileNameEntry.Text);
                await App.Current.MainPage.DisplayAlert("File Downloaded : ",path, "Ok");
            }

        }

        private async void deleteFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileNameEntry.Text))
            {
                await App.Current.MainPage.DisplayAlert("", "Please enter a file name", "Ok");
                return;
            }
            else
            {
                await firebaseStorageHelper.DeleteFile(fileNameEntry.Text);
                await App.Current.MainPage.DisplayAlert("File Deteted : ", fileNameEntry.Text, "Ok");
            }

        }
    }
    //Separate function for CRUD operations
    public class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("fir-demo-71fa5.appspot.com");

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
        public async Task DeleteFile(string fileName)
        {
            await firebaseStorage
                 .Child("XamarinMonkeys")
                 .Child(fileName)
                 .DeleteAsync();

        }
    }
}