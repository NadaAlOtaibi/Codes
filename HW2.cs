
using System;

namespace wajep

{
    public interface MobileBuilder
    {
        void SetModel();
        void SetSerialNumber();
        void SetColor();
        void SetMobileSize();
        MOBILE GetMobile();
    }

    // This is the product class for Toy.

    public class MOBILE
    {
        public string Model
        { get; set; }
        public string SerialNumber
        { get; set; }
        public string Color
        { get; set; }
        public string MobileSize
        { get; set; }
    }

        //Mobile A

        public class MubileABuilder : MobileBuilder
        {
            MOBILE mobile = new MOBILE();
            public void SetModel()
            {
                mobile.Model = "Mobile A 13124322 ";
            }
            public void SetSerialNumber()
            {
                mobile.SerialNumber = "54646454";
            }
            public void SetColor()
            {
                mobile.Color = "Red";
            }
            public void SetMobileSize()
            {
                mobile.MobileSize = "small";
            }

            public MOBILE GetMobile()
            {
                return mobile;
            }

            //Mobile B

            public class MobileBBuilder : MobileBuilder
            {
                MOBILE mobile = new MOBILE();
                public void SetModel()
                {
                    mobile.Model = "Mobile B 31433323";
                }
                public void SetSerialNumber()
                {
                    mobile.SerialNumber = "423322323";
                }
                public void SetColor()
                {
                    mobile.Color = "Blue";
                }
                public void SetMobileSize()
                {
                    mobile.MobileSize = "Large";
                }
                public MOBILE GetMobile()
                {
                    return mobile;
                }
            }
            // using the Builder Interface.

            public class MobileCreator
            {
                private MobileBuilder mobileBuilder;
                public MobileCreator(MobileBuilder MobileBuilder)
                {
                    mobileBuilder = MobileBuilder;
                }
                public void CreateMobile()
                {
                    mobileBuilder.SetModel();
                    mobileBuilder.SetSerialNumber();
                    mobileBuilder.SetColor();
                    mobileBuilder.SetMobileSize();
                }
                public MOBILE GetMobile()
                {
                    return mobileBuilder.GetMobile();
                }
            }


            static void Main(string[]args)
            {
                Console.WriteLine("List Of Mobiles");
                var MA = new MobileCreator(new MubileABuilder());
                MA.CreateMobile();
              Console.WriteLine(MA.GetMobile());
                var MB = new MobileCreator(new MobileBBuilder());
                MB.CreateMobile();
                Console.WriteLine(MB.GetMobile());
            }
        }
    
}
