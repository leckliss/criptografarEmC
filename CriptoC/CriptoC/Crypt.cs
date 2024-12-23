
/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/08/2023
 * Time: 13:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace CriptoC
{
	/// <summary>
	/// Description of Crypt.
	/// </summary>
	public class Crypt
	{
		string chave = "12345678";
		string chaveReversa ="87654321";
			
		public string Criptografa(string pDado)
		{
			
			string Retorno = "";
			string pKey = chave;
			string sKey = chaveReversa;
			byte[] secretkeyByte = { };
			secretkeyByte = System.Text.Encoding.UTF8.GetBytes(sKey);
			byte[] publickeybyte = { };
			publickeybyte = System.Text.Encoding.UTF8.GetBytes(pKey);
			MemoryStream ms = null;
			CryptoStream cs = null;
			byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(pDado);
			using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
			{
				ms = new MemoryStream();
				cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte , secretkeyByte), CryptoStreamMode.Write);
				cs.Write(inputbyteArray, 0, inputbyteArray.Length);
				cs.FlushFinalBlock();
				Retorno = Convert.ToBase64String(ms.ToArray());
			}
			return Retorno;
		}
		
		public string Descriptografa(string pDado)
		{
			string Retorno = "";
			string pKey = chave;
			string sKey = chaveReversa;
			byte[] privatekeyByte = { };
			privatekeyByte = System.Text.Encoding.UTF8.GetBytes(sKey);
			byte[] publickeybyte = { };
			publickeybyte = System.Text.Encoding.UTF8.GetBytes(pKey);
			MemoryStream ms = null;
			CryptoStream cs = null;
			byte[] inputbyteArray = new byte[pDado.Replace(" ", "+").Length];
			inputbyteArray = Convert.FromBase64String(pDado.Replace(" ", "+"));
			using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
			{
				ms = new MemoryStream();
				cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
				cs.Write(inputbyteArray, 0, inputbyteArray.Length);
				cs.FlushFinalBlock();
				Encoding encoding = Encoding.UTF8;
				Retorno = encoding.GetString(ms.ToArray());
			}
		
			return Retorno;
		}

	}
}
