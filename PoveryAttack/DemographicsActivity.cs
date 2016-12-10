using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PoveryAttack
{
    [Activity(Label = "DemographicsActivity")]
    public class DemographicsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Demo);

            //this is the need information from the button they clicked on the previous activity
            string need = Intent.GetStringExtra("Need") ?? "Data not available";

            Button nextButton = FindViewById<Button>(Resource.Id.nextButton);
            nextButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CuratedListActivity));
                //need to get all of the checkboxes and pass them over to the list so they can be used
                //in the query
                CheckBox male = FindViewById<CheckBox>(Resource.Id.checkMale);
                if(male.Checked)
                {
                    intent.PutExtra("Male", true);
                }
                CheckBox female = FindViewById<CheckBox>(Resource.Id.checkFemale);
                if (female.Checked)
                {
                    intent.PutExtra("Female", true);
                }
                CheckBox trans = FindViewById<CheckBox>(Resource.Id.checkTrans);
                if (trans.Checked)
                {
                    intent.PutExtra("Trans", true);
                }
                CheckBox senior = FindViewById<CheckBox>(Resource.Id.checkSenior);
                if (senior.Checked)
                {
                    intent.PutExtra("Senior", true);
                }
                CheckBox minor = FindViewById<CheckBox>(Resource.Id.checkMinor);
                if (minor.Checked)
                {
                    intent.PutExtra("Minor", true);
                }
                CheckBox pregnant = FindViewById<CheckBox>(Resource.Id.checkPregnant);
                if (pregnant.Checked)
                {
                    intent.PutExtra("Pregnant", true);
                }
                CheckBox children = FindViewById<CheckBox>(Resource.Id.checkMinorChild);
                if (children.Checked)
                {
                    intent.PutExtra("Children", true);
                }
                CheckBox vet = FindViewById<CheckBox>(Resource.Id.checkVeteran);
                if (vet.Checked)
                {
                    intent.PutExtra("Vet", true);
                }
                CheckBox disabled = FindViewById<CheckBox>(Resource.Id.checkDisabled);
                if (disabled.Checked)
                {
                    intent.PutExtra("Disabled", true);
                }
                CheckBox uninsured = FindViewById<CheckBox>(Resource.Id.checkUninsured);
                if (uninsured.Checked)
                {
                    intent.PutExtra("Uninsured", true);
                }
                CheckBox lgbt = FindViewById<CheckBox>(Resource.Id.checkLGBT);
                if (lgbt.Checked)
                {
                    intent.PutExtra("LGBT", true);
                }
                CheckBox homeless = FindViewById<CheckBox>(Resource.Id.checkHomeless);
                if (homeless.Checked)
                {
                    intent.PutExtra("Homeless", true);
                }
                StartActivity(intent);
            };
        }
    }
}