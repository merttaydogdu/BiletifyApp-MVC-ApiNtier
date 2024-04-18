namespace BiletifyUI.Areas.Admin.Helpers
{
    public static class MyUrlHelper
    {
        /// <summary>
        /// Bu metot kendisine gönderilen text'i url haline dönüştürür.
        /// </summary>
        /// <param name="text">Url'e dönüştürülecek metinsel ifade</param>
        /// <returns>Geriye yasak karakterlerden arındırılmış metin halinde bir url bilgisi döndürür.</returns>
        public static string GetUrl(string text)
        {
            #region Gereksiz Boşluklar Kaldırılıyor
            text = text.Trim();
            #endregion
            #region Sorunlu Harfler Dönüştürülüyor
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");
            #endregion
            #region Küçük Harfe Dönüştürülüyor
            text = text.ToLower();
            #endregion
            #region Türkçe Karakterler Dönüştürülüyor
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ç", "c");
            text = text.Replace("ğ", "g");
            #endregion
            #region Boşluklar Tireye Dönüştürülüyor
            text = text.Replace(" ", "-");
            #endregion
            #region Yasak Karakterler Kaldırılıyor
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.Replace(":", "");
            text = text.Replace(";", "");
            text = text.Replace("/", "");
            text = text.Replace("\\", "");
            text = text.Replace("'", "");
            text = text.Replace("\"", "");
            text = text.Replace("`", "");
            text = text.Replace("~", "");
            text = text.Replace("é", "");
            text = text.Replace("!", "");
            text = text.Replace("+", "");
            text = text.Replace("^", "");
            text = text.Replace("%", "");
            text = text.Replace("&", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("=", "");
            text = text.Replace("?", "");
            text = text.Replace(">", "");
            text = text.Replace("<", "");
            text = text.Replace("£", "");
            text = text.Replace("#", "");
            text = text.Replace("$", "");
            text = text.Replace("{", "");
            text = text.Replace("}", "");
            text = text.Replace("[", "");
            text = text.Replace("]", "");
            text = text.Replace("*", "");
            text = text.Replace("_", "");
            text = text.Replace("|", "");
            #endregion
            return text;
        }
    }
}
