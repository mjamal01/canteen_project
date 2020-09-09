using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace DellyShopApp.Extensions {
    public static class AppExtensions {

        public static ImageSource GetImageSource(this MediaFile mediaFile) {

            var imageSource = ImageSource.FromStream( () => {
                var stream = mediaFile.GetStream();
                return stream;
            } );

            return imageSource;

        }

        public static byte[] GetByteArray(this MediaFile mediaFile) {

            using ( MemoryStream ms = new MemoryStream() ) {

                var stream = mediaFile.GetStream();
                stream.CopyTo( ms );
                return ms.ToArray();
            }

        }

    }
}
