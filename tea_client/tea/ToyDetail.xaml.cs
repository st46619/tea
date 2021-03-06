﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tea.containers.dtos;
using tea.util;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Dokumentaci k šabloně Prázdná aplikace najdete na adrese https://go.microsoft.com/fwlink/?LinkId=234238

namespace tea
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo se na ni dá přejít v rámci
    /// </summary>
    public sealed partial class ToyDetail : Page
    {
        private Toy toy = null;

        public ToyDetail()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            toy = (Toy)e.Parameter;

            nameTb.Text = toy.Name;
            Img.Source = await Photo.FromBase64(toy.ImageData);
        }
    }
}
