/**********************************************************************
* 命名空间：NMS.RTIS.Core.Tools
*
* 功  能：RSA2加密解密
* 类  名：RSA2Helper
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System.Security.Cryptography;
using System.Text;
using XC.RSAUtil;

namespace NMS.RTIS.Core.Tools
{
    public static class RSA2Helper
    {
        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="text">要加密的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static string Encrypt(string text, Encoding encoding, string publicKey, string privateKey)
        {
            RSAUtilBase rsaUtil = new RsaPkcs1Util(encoding, publicKey, privateKey);
            return rsaUtil.Encrypt(text, RSAEncryptionPadding.Pkcs1);
        }
        /// <summary>
        ///  RSA解密
        /// </summary>
        /// <param name="cipherText">要解密的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="publicKey">公钥</param>
        /// <param name="privateKey">私钥</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, Encoding encoding, string publicKey, string privateKey)
        {
            RSAUtilBase rsaUtil = new RsaPkcs1Util(encoding, publicKey, privateKey);
            return rsaUtil.Decrypt(cipherText, RSAEncryptionPadding.Pkcs1);
        }
    }
    public class RSAConfig
    {
        /// <summary>
        /// 私钥
        /// </summary>
        public static string PrivateKey => "MIIEowIBAAKCAQEAveQx7Sbfcx4RmlfbSkzlvRghDhgA/kypC9+LWoVzjTNVpfQnzNCqealoZWCAmeJ3Ye9YLM1oAS/8Sv1OiN2I/mtpfrP2khkYl0RZy1JC5U5KaL9DHGsyqAyUPDiYFVYCMfQwqU3sP5qu5CloGurYFqqUwfuEbsaFS5zU5GZ/acA+bmFDpI7cKz64EpIqmAqkUsnFwRyzwATjBTj5L+o8VyZMq1oqgU6JWf+8rC/EW4x1eTmIow93nE8+XULJxk2mC6QICKHSbhcIU9yf57mvv/upflEJDKzB7+AIOajchGmuJwpd+XjpcnJTHqMlIXQHZkXXZ/EV0SeSxlG8ECtnIQIDAQABAoIBAEbvkf8HgH2eg/DmVRMCeugStXZwXR6iQJwg3AvqwmnC/YHLHXsTkDt2n3sPe7sAsJwzLvs9mFapOFRDIC1cpKp2MaiVTczx9w+7Btg/WKIUhxNuL4HUQc4pNM7yTU3bHWLP18XHSDPScvbkyPEVPbfp7Twx2x0OqAjBA353E63K73MBn/K2H6t0Yp7hY0agwlZoNpkS3gaJ1WHDccPSbsmOGKLVBNmWMoR0oifZjJZ4OkZQR9w05L01PQqMt4CfEV8JktYZ+avwVxbJVRPlLUOUcczvVxodrkyRrWHSnOLIAzqgFuZoGvJUXyacMcGPlRnUQsRk/Z9bLEXSMRy4LYkCgYEA9BD9bSh7pGdHMn0L570d80J1A9/RYyUXs2tge+gEXzOTcWmh5WOE+5VZyQYifFxMHVSuLauu+n7ZbwuSL+HVjsYvU6hyLpxjbV0S+uD7R+y1G2HxmfBdIxMw0ttWN/W5dmvD+xcI1OtWCa3rxkvMFXZBmJ7CiZLrkmpc3NiQumcCgYEAxy0XA2HOo5lYTtHb+7U3rT7Qzf8POCnpkZrh99HXEl0OHhteTd9pr564aW1r84colDiYLGMiqLfiaP4PW97WY5/wHY1fDYQXlMhlw5a6tnOUS+KDvTpALqN3PrN2BU8KKnHlsCIWY8OJRYpHevcv3+/15HmsAbWpfI2UOMIu7TcCgYBXNQ7ohxOOzdxRvP6ZAikGd5OKG9ocW++ZC2ABRgjx32Lqnjzb0vB8WIQpYQjHeM81l8FYzkSKevLES9UjSMVe64+Ti9eosfaQ6DXU8Li4nWqk6x1BzPHqi3vhi7/F5QYsuxrex/8+3Qv0D3H0e7bjYErV9rw6HgYQXfLqcnNcNwKBgQCQM3zt3eoVV/gvWJDD87eTnl7eRUNnjjCkUlY3bZ0glm6aLYZhKtcBZxBsg+QcNEaUyUSjHkMBk+A/03CbOwJMrobRXoDq8C+CcHP83yve3F8Jcb2fSoUdPwweQR+5SDg78qowkv1SzUadKjgGNuBaaQjFmbGGq1dB7d7aGPyQkQKBgBFKDkGoriovavJj9MkhjE0C23RNXbFXthMI5E1VJVVBv/1VAHde5/1Srabjbm0e+Jl8AknGQ48n4BV6O2dFHjBliNehUdyDWgPGG02EPYd4xVEfOYn9SXOELI4tZo31veXZUmEYi5I/7gLsXEYuZMNMcjT5Br/NF3pT/X5iEZZ8";
        /// <summary>
        /// 公钥
        /// </summary>
        public static string PublicKey => "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAveQx7Sbfcx4RmlfbSkzlvRghDhgA/kypC9+LWoVzjTNVpfQnzNCqealoZWCAmeJ3Ye9YLM1oAS/8Sv1OiN2I/mtpfrP2khkYl0RZy1JC5U5KaL9DHGsyqAyUPDiYFVYCMfQwqU3sP5qu5CloGurYFqqUwfuEbsaFS5zU5GZ/acA+bmFDpI7cKz64EpIqmAqkUsnFwRyzwATjBTj5L+o8VyZMq1oqgU6JWf+8rC/EW4x1eTmIow93nE8+XULJxk2mC6QICKHSbhcIU9yf57mvv/upflEJDKzB7+AIOajchGmuJwpd+XjpcnJTHqMlIXQHZkXXZ/EV0SeSxlG8ECtnIQIDAQAB";
    }
}
