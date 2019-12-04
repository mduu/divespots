using System;

namespace DiveSpots.Application.Core
{
    public class TranslationData
    {
        public TranslationData(string isoCode, string text)
        {
            IsoCode = isoCode;
            Text = text;
        }

        public string IsoCode { get; }
        public string Text { get; }
        
        public override bool Equals(object obj)
        {
            var translationObj = obj as TranslationData;
            if (translationObj == null)
            {
                return false;
            }

            return
                translationObj.IsoCode.Equals(IsoCode, StringComparison.InvariantCultureIgnoreCase) &&
                translationObj.Text.Equals(Text);
        }

        protected bool Equals(TranslationData other)
        {
            return
                IsoCode.Equals(other.IsoCode, StringComparison.InvariantCultureIgnoreCase) && 
                Text == other.Text;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((IsoCode != null ? IsoCode.GetHashCode() : 0) * 397) ^ (Text != null ? Text.GetHashCode() : 0);
            }
        }
    }
}