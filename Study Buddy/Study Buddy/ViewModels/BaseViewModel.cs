﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Study_Buddy.Models;
using Study_Buddy.Services;
using StudyBuddy.Services;
using StudyBuddy.Models.Notes;

namespace Study_Buddy.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ITaskDataStore<Tasks> TaskDataStore => DependencyService.Get<ITaskDataStore<Tasks>>();
        public NoteDataStore NoteStore => DependencyService.Get<NoteDataStore>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string headingText = string.Empty;

        public string HeadingText
        {
            get { return headingText; }
            set { SetProperty(ref headingText, value); }
        }

        string notesButtonText = string.Empty;

        public string NotesButtonText
        {
            get { return notesButtonText; }
            set { SetProperty(ref notesButtonText, value); }
        }

        string tasksButtonText = string.Empty;

        public string TasksButtonText
        {
            get { return tasksButtonText; }
            set { SetProperty(ref tasksButtonText, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
