﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tea.containers.dtos;
using tea.util;
using tea.utils;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Dokumentaci k šabloně Prázdná aplikace najdete na adrese https://go.microsoft.com/fwlink/?LinkId=234238

namespace tea
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo se na ni dá přejít v rámci
    /// </summary>
    public sealed partial class NewToy : Page
    {
        private string username = "";

        public NewToy()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            username = (string)e.Parameter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameTb.Text.Length > 0)
            {
                try
                {
                    Query.NewToy(new NewToyDtoOut { name = nameTb.Text, username = username, imageData = Photo.ToBase64(null, new Guid("15926159-3412-1461-4651-172852621358")).Result});
                    this.Frame.Navigate(typeof(Blank));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
                nameTb.PlaceholderForeground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        private void ImgBtn_Click(object sender, RoutedEventArgs e)
        {
            SoftwareBitmap softwareBitmap = Photo.CaptureAsync().Result;
            
            // Use the image.
            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Premultiplied);

            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

            Img.Source = bitmapSource;
        }
    }
}
