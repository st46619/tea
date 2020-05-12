﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using tea.util;
using Windows.UI.Xaml.Media;

namespace tea.containers.dtos
{
    class OfferDtoIn
    {
        public long OfferId { get; set; }
        public string NameOfPerson { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public long? Winner { get; set; }
        public List<Toy> Toys { get; set; }
        public string Username { get; set; }
        public ImageSource Image { get; set; }

        public async Task BuildImage()
        {
            if (Toys != null)
                if (Toys.Count > 0)
                    Image = await Photo.FromBase64(Toys[0].ImageData);
        }
    }
}
