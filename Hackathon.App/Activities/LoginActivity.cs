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
using Proxy.App;

namespace Hackathon.App.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private ServiceClient serviceClient;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_layout);

            serviceClient = new ServiceClient();

            var btLogin = FindViewById<Button>(Resource.Id.BtLogin);
            btLogin.Click += BtLogin_Click;
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            //TODO Login 
            serviceClient.Login("user1","12345");
        }
    }
}