using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EMSsign
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        Android.Widget.Button CaptureButton;
        ImageView imgAddEmployer;

        SqlConnection con = new SqlConnection();
        DB db = new DB();
        Android.Widget.Button btnSave;
        EditText TxtEmployeeId, TxtName, TxtMobileNo, TxtDesignation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SignUp);

            CaptureButton = (Android.Widget.Button)FindViewById(Resource.Id.CaptureButton);
            imgAddEmployer = (ImageView)FindViewById(Resource.Id.imgAddEmployer);

            CaptureButton.Click += CaptureButton_Click1;      


           TxtEmployeeId = FindViewById<EditText>(Resource.Id.TextIdAddEmployer);
            TxtName = FindViewById<EditText>(Resource.Id.TextNameAddEmployer);
            TxtMobileNo = FindViewById<EditText>(Resource.Id.TextMobileNoAddEmployer);
            TxtDesignation = FindViewById<EditText>(Resource.Id.TextDesignationAddEmployer);

            btnSave = FindViewById<Android.Widget.Button>(Resource.Id.ButtonSaveAddEmployer);
            btnSave.Click += BtnSave_Click1;   
        }

        private void BtnSave_Click1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CaptureButton_Click1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            ClassEmployee emp = new ClassEmployee()
            {
                EmployeeId = TxtEmployeeId.Text,
                EmployeeName = TxtName.Text,
                MobileNo = TxtMobileNo.Text,
                Designation = TxtDesignation.Text,
                UserRole = "Employer",
                EmployerId = "Employer"
            };


            db.ExeSQL(@"INSERT INTO Table_Employees (EmployeeId, EmployeeName, MobileNo, Designation, UserRole, UserPassword, EmployerId, IsVerified) VALUES ('" + emp.EmployeeId + "','" + emp.EmployeeName + "','" + emp.MobileNo + "','" + emp.Designation + "','" + emp.UserRole + "','12345678','" + emp.EmployerId + "','false')");

            Android.App.AlertDialog.Builder alertdialog = new Android.App.AlertDialog.Builder(this);
            alertdialog.SetTitle("Message:");
            alertdialog.SetMessage("Now " + emp.EmployeeName + " is an " + emp.UserRole + " \nMay login with default password 12345678 ");
            alertdialog.SetNeutralButton("OK", delegate
            {
                TxtEmployeeId.Text = "";
                TxtName.Text = "";
                TxtMobileNo.Text = "";
                TxtDesignation.Text = "";
                alertdialog.Dispose();
            });
            alertdialog.Show();
        }
    
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            //Bitmap btm = (Bitmap)data.GetByteExtra("data");
            //imgAddEmployer.SetImageBitmap(btm);

        }
        private async  void CaptureButton_Click(object sender, System.EventArgs e)
        {
            //Intent intent = new Intent(MediaStore.ActionImageCapture);
            //StartActivityForResult(intent, 0);
            var pickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an Image"

            });
            if (pickImage != null)
            {
                var stream = await pickImage.OpenReadAsync();
                //imgAddEmployer.Source = ImageSource.FromStream(() => stream);
                //fileName.Text = pickImage.FileName;
                //string imgfile = Path.GetFileName(pickImage.FullPath);
                string fileName = pickImage.FileName;
                //string folderPath = Server.MapPath("~/Images");
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}