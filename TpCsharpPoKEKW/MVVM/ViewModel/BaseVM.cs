﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using TpCsharpPoKEKW.Model;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    /*Commande qui marche avec tous les VM*/
    public class BaseVM : ObservableObject
    {

        //Route





       protected ExerciceMonsterContext context = new ExerciceMonsterContext();
        public static void BackHome()
        {
            MainWindowVM.OnRequestVMChange?.Invoke(new MainViewVM());
        }

  
        public static class Session 
        {
            public static List<SpellWithMonsters> SpellList;
            private static bool _isLoggedIn = false;

            public static int Id {  get; set; } = 0;
            public static bool IsLoggedIn 
            {
                get => _isLoggedIn;
                set
                {
                    _isLoggedIn = value;
                    OnStaticPropertyChanged(nameof(IsLoggedIn));
                }
            }

            private static string? _loggedInUsername = null;
            public static string? LoggedInUsername
            {
                get => _loggedInUsername;
                set
                {
                    _loggedInUsername = value;
                    OnStaticPropertyChanged(nameof(LoggedInUsername));
                }
            }

            public static event PropertyChangedEventHandler? StaticPropertyChanged;

            private static void OnStaticPropertyChanged(string propertyName)
            {
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static void LogOut()
        {
            Session.IsLoggedIn = false;
            Session.LoggedInUsername = null;
            Session.Id = 0;
            MainWindowVM.OnRequestVMChange?.Invoke(new MainViewVM());
            BackHome();
        }
    }
}
