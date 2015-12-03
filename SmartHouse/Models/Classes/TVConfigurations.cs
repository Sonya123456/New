using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    [Serializable]
    public  class TVConfigurations
    {
        private int intensity;
        private int contrast;
        private ImageModes imageMode;
        private ColorModes colorMode;
        private static readonly int MAX_INTENSITY = 100;
        private static readonly int MIN_INTENSITY = 1;
        private static readonly int MAX_CONTRAST = 50;
        private static readonly int MIN_CONTRAST = 1;

        public TVConfigurations() { ImageMode = ImageModes.Standart; ColorMode = ColorModes.Standart; }

        public int Intensity 
        {
            get { return intensity; }
            set { if (value >= MIN_INTENSITY && value <= MAX_INTENSITY) intensity = value;  }
        }
        public int Contrast
        {
            get { return contrast; }
            set { if (value >= MIN_CONTRAST && value <= MAX_CONTRAST) contrast = value;  }
        }
        public ImageModes ImageMode 
        {
            get { return imageMode; }
            set
            {
                switch (value)
                {
                    case (ImageModes.Dynamic): Intensity = 95;
                        break;
                    case (ImageModes.Movie): Intensity = 55;
                        break;
                    case (ImageModes.Standart): Intensity = 75;
                        break;
                } 
                imageMode = value;
            }
        }

        public ColorModes ColorMode 
       {
           get { return colorMode; }
           set
           {
               switch (value)
               {
                   case (ColorModes.Cold): Contrast = 25;
                       break;
                   case (ColorModes.Standart): Contrast = 40;
                       break;
                   case (ColorModes.Warm): Contrast = 50;
                       break;
               }
               colorMode = value;
           }
        }

        public void IncreaseIntensity()
        { 
            Intensity++;
            if(Intensity!=MAX_INTENSITY)
            if (ImageMode!= ImageModes.Custom)
            ImageMode = ImageModes.Custom;
        }
        public void DecreaseIntensity() 
        { 
            Intensity--;
            if (Intensity != MIN_INTENSITY)
                if (ImageMode != ImageModes.Custom)
                ImageMode = ImageModes.Custom;
        }
        public void IncreaseContrast()
        { 
            Contrast++;
            if(Contrast!=MAX_CONTRAST)
            if (ColorMode != ColorModes.Custom)
                ColorMode = ColorModes.Custom;
        }

        public void DecreaseContrast()
        {
            Contrast--;
            if (Contrast != MIN_CONTRAST)
                if (ColorMode != ColorModes.Custom)
                ColorMode = ColorModes.Custom; 
        }
        public void ChangeImageMode()
        {

            if ((int)ImageMode + 1 == Enum.GetValues(typeof(ImageModes)).Length)
                ImageMode = (ImageModes)Enum.GetValues(typeof(ImageModes)).GetValue(0);
            else
                ImageMode++;

        }

        public void ChangeColorMode()
        {
            if ((int)ColorMode + 1 == Enum.GetValues(typeof(ColorModes)).Length)
                ColorMode = (ColorModes)Enum.GetValues(typeof(ColorModes)).GetValue(0);
            else
                ColorMode++;
        }
    }
}
