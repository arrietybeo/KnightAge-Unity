using System;
using UnityEngine;

public class ItemMapSprite
{
    public int x;

    public int y;

    public int wimg;

    public int himg;

    public int timeRemove;

    public string path;

    public mImage img;

    public bool isShow;

    public bool isLoadOK;

    public bool isPaint(int x1, int xw1, int x2, int xw2, int y1, int yh1, int y2, int yh2)
    {
        x1 *= mGraphics.zoomLevel;
        xw1 *= mGraphics.zoomLevel;
        x2 *= mGraphics.zoomLevel;
        xw2 *= mGraphics.zoomLevel;
        y1 *= mGraphics.zoomLevel;
        yh1 *= mGraphics.zoomLevel;
        y2 *= mGraphics.zoomLevel;
        yh2 *= mGraphics.zoomLevel;
        if (x1 > xw2 || xw1 < x2 || y1 > yh2 || yh1 < y2)
        {
            return false;
        }
        return true;
    }

    public void update()
    {
        if (isPaint(x, x + wimg, MainScreen.cameraMain.xCam, MainScreen.cameraMain.xCam + GameCanvas.w, y, y + himg, MainScreen.cameraMain.yCam, MainScreen.cameraMain.yCam + GameCanvas.h))
        {
            isShow = true;
            timeRemove = (int)(mSystem.currentTimeMillis() / 1000);
        }
        else
        {
            isShow = false;
        }
        if (isLoadOK && mSystem.currentTimeMillis() / 1000 - timeRemove > 360)
        {
            img.image.texture = null;
            img = null;
            isLoadOK = false;
        }
    }

    public byte[] getByteArray(Image img)
    {
        try
        {
            return img.texture.EncodeToPNG();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public void loadImage()
    {
        img = mImage.loadImageRMS(path);
        if (img == null)
        {
            img = LoadMap.me.loadImageMap(this, ref timeRemove, ref isLoadOK);
            byte[] byteArray = getByteArray(img.image);
            Rms.saveRMS(path, ArrayCast.cast(byteArray));
        }
    }

    public void paint(mGraphics g)
    {
        if (isShow)
        {
            if (img == null)
            {
                img = mSystem.loadImageByPNG(path, ref timeRemove, ref isLoadOK);
            }
            else
            {
                g.drawImagaByDrawTexture(img, x, y);
            }
        }
    }
}
