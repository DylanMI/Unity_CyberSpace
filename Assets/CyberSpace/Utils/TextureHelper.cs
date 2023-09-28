using UnityEngine;

namespace CyberSpace
{
    public static class TextureHelper
    {
        public static Texture2D ResizeTexture(this Texture2D oldTexture, int targetWidth, int targetHeight)
        {
            RenderTexture rt = new RenderTexture(targetWidth, targetHeight, 24);
            Graphics.Blit(oldTexture, rt);
            Texture2D retVal = new Texture2D(targetWidth, targetHeight);
            retVal.ReadPixels(new Rect(0, 0, targetWidth, targetHeight), 0, 0);
            retVal.Apply();
            return retVal;
        }
    }
}