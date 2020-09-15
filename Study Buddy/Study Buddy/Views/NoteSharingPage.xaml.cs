using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace Study_Buddy.Views
{
    public partial class NoteSharingPage : ContentPage
    {
        public NoteSharingPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            return;
        }
    }

    public class Note
    {
        public string subject;
        public string title;
        public string content;
        public Note(string Subject, string Title, string Content)
        {
            subject = Subject;
            title = Title;
            content = Content;
        }
    }
}