using System;

public class SaveImageRMS
{
	public static mVector vecSaveImage = new mVector("SaveImageRMS vecSaveImage");

	public static mVector vecSaveCharPart = new mVector("SaveImageRMS vecSaveCharPart");

	public void run()
	{
		while (true)
		{
			bool flag = false;
			while (vecSaveCharPart.size() > 0)
			{
				flag = true;
				MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)vecSaveCharPart.elementAt(0);
				try
				{
					CRes.saveRMS("img_data_char_" + mainImageDataPartChar.type + "_" + mainImageDataPartChar.id, mainImageDataPartChar.getSaveData().toByteArray());
				}
				catch (Exception)
				{
				}
				vecSaveCharPart.removeElementAt(0);
			}
			if (flag)
			{
				DataOutputStream dataOutputStream = new DataOutputStream();
				try
				{
					dataOutputStream.writeShort(GameCanvas.IndexCharPar);
					CRes.saveRMS("isIndexPart", dataOutputStream.toByteArray());
					dataOutputStream.close();
				}
				catch (Exception)
				{
				}
			}
			if (vecSaveImage.size() > 0)
			{
				try
				{
					idSaveImage idSaveImage2 = (idSaveImage)vecSaveImage.elementAt(0);
					ObjectData.setToRms(idSaveImage2.mbytImage, idSaveImage2.id);
					vecSaveImage.removeElementAt(0);
				}
				catch (Exception)
				{
				}
				continue;
			}
			break;
		}
	}

	public void start()
	{
	}
}
