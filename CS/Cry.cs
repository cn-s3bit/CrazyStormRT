// CrazyStorm_1._03.Cry
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;

internal class Cry
{
	private static byte[] Keys = new byte[16]
	{
		79,
		14,
		42,
		91,
		9,
		12,
		143,
		221,
		62,
		193,
		178,
		163,
		byte.MaxValue,
		162,
		5,
		7
	};

	private static byte[] Keys2 = new byte[16]
	{
		28,
		91,
		61,
		0,
		5,
		4,
		127,
		187,
		204,
		45,
		195,
		212,
		170,
		241,
		242,
		248
	};

	public static string Decry(string strString, string Keys)
	{
		TripleDESCryptoServiceProvider btx = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider bty = new MD5CryptoServiceProvider();
		btx.Key = bty.ComputeHash(Encoding.Default.GetBytes(Keys));
		btx.Mode = CipherMode.ECB;
		ICryptoTransform bpx = btx.CreateDecryptor();
		string bpy = "";
		byte[] i = Convert.FromBase64String(strString);
		return Encoding.Default.GetString(bpx.TransformFinalBlock(i, 0, i.Length));
	}

	public static Stream Decry(string FileName)
	{
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Keys);
		tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
		ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
		byte[] array = new byte[0];
		byte[] array2 = new byte[0];
        foreach (var item in Assembly.GetExecutingAssembly ().GetManifestResourceNames()) {
            if (!item.EndsWith (FileName))
                continue;
            using (Stream stream = Assembly.GetExecutingAssembly ().GetManifestResourceStream (item)) {
                array2 = new byte[stream.Length];
                stream.Read (array2, 0, array2.Length);
                array = array2;
                array = cryptoTransform.TransformFinalBlock (array, 0, array.Length);
            }
        }
		return new MemoryStream(array);
	}
}
