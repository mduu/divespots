using System;

namespace DiveSpots.DataContracts.Api
{
    public class TranslationDto
    {
        public string IsoCode { get; set; }
        public string Text { get; set; }
        
        public override bool Equals(object obj)
        {
            var translationObj = obj as TranslationDto;
            if (translationObj == null)
            {
                return false;
            }

            return
                translationObj.IsoCode.Equals(IsoCode, StringComparison.InvariantCultureIgnoreCase) &&
                translationObj.Text.Equals(Text);
        }
    }
}