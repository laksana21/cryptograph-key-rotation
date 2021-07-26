using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keyrot_lib
{
    public class Keyrot
    {
        private char[] abcPlain1 = new char[26] { 'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm' };
        private char[] abcPlain2 = new char[26] { 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z' };
        private char[] qwePlain1 = new char[26] { 'Q', 'q', 'W', 'w', 'E', 'e', 'R', 'r', 'T', 't', 'Y', 'y', 'U', 'u', 'I', 'i', 'O', 'o', 'P', 'p', 'A', 'a', 'S', 's', 'D', 'd' };
        private char[] qwePlain2 = new char[26] { 'F', 'f', 'G', 'g', 'H', 'h', 'J', 'j', 'K', 'k', 'L', 'l', 'Z', 'z', 'X', 'x', 'C', 'c', 'V', 'v', 'B', 'b', 'N', 'n', 'M', 'm' };
        private char[] azePlain1 = new char[26] { 'A', 'a', 'Z', 'z', 'E', 'e', 'R', 'r', 'T', 't', 'Y', 'y', 'U', 'u', 'I', 'i', 'O', 'o', 'P', 'p', 'Q', 'q', 'S', 's', 'D', 'd' };
        private char[] azePlain2 = new char[26] { 'N', 'n', 'B', 'b', 'V', 'v', 'C', 'c', 'X', 'x', 'W', 'w', 'M', 'm', 'L', 'l', 'K', 'k', 'J', 'j', 'H', 'h', 'G', 'g', 'F', 'f' };

        private char EcrAlgorithm(char text, int rot)
        {
            int i = 0;
            bool kon = false;
            char ret = text;

            while (!kon && i < 26)
            {
                if (ret == abcPlain1[i])
                {
                    ret = abcPlain2[i];
                    kon = true;
                }
                else if (ret == abcPlain2[i])
                {
                    ret = abcPlain1[i];
                    kon = true;
                }
                i++;
            }
            kon = false;
            i = 0;
            while (!kon && i < 26)
            {
                if (ret == qwePlain1[i])
                {
                    ret = qwePlain2[i];
                    kon = true;
                }
                else if (ret == qwePlain2[i])
                {
                    ret = qwePlain1[i];
                    kon = true;
                }
                i++;
            }
            kon = false;
            i = 0;
            while (!kon && i < 26)
            {
                int rotKon = i + rot;
                if (ret == azePlain1[i])
                {
                    if (rotKon >= 25)
                    {
                        int setKon = rotKon - 25;
                        ret = azePlain2[setKon];
                        kon = true;
                    }
                    else
                    {
                        ret = azePlain2[rotKon];
                        kon = true;
                    }
                }
                else if (ret == azePlain2[i])
                {
                    if (rotKon >= 25)
                    {
                        int setKon = rotKon - 25;
                        ret = azePlain1[setKon];
                        kon = true;
                    }
                    else
                    {
                        ret = azePlain1[rotKon];
                        kon = true;
                    }
                }
                i++;
            }
            return ret;
        }

        private char DecrAlgorithm(char text, int rot)
        {
            int i = 0;
            bool kon = false;
            char ret = text;

            while (!kon && i < 26)
            {
                if (ret == azePlain1[i])
                {
                    int setKon;
                    if (i < rot)
                    {
                        setKon = 25 + i;
                        setKon = setKon - rot;
                        ret = azePlain2[setKon];
                        kon = true;
                    }
                    else
                    {
                        setKon = i - rot;
                        ret = azePlain2[setKon];
                        kon = true;
                    }
                }
                else if (ret == azePlain2[i])
                {
                    int setKon;
                    if (i < rot)
                    {
                        setKon = 25 + i;
                        setKon = setKon - rot;
                        ret = azePlain1[setKon];
                        kon = true;
                    }
                    else
                    {
                        setKon = i - rot;
                        ret = azePlain1[setKon];
                        kon = true;
                    }
                }
                i++;
            }

            kon = false;
            i = 0;
            while (!kon && i < 26)
            {
                if (ret == qwePlain1[i])
                {
                    ret = qwePlain2[i];
                    kon = true;
                }
                else if (ret == qwePlain2[i])
                {
                    ret = qwePlain1[i];
                    kon = true;
                }
                i++;
            }

            kon = false;
            i = 0;
            while (!kon && i < 26)
            {
                if (ret == abcPlain1[i])
                {
                    ret = abcPlain2[i];
                    kon = true;
                }
                else if (ret == abcPlain2[i])
                {
                    ret = abcPlain1[i];
                    kon = true;
                }
                i++;
            }
            return ret;
        }

        public string Encrypt(string textToEncrypt, int encryptKey)
        {
            StringBuilder inSb = new StringBuilder(textToEncrypt);
            StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
            char c;
            int i, r = encryptKey;
            int pTeks = textToEncrypt.Length;
            int Kunci = pTeks * (2 + ((8 * encryptKey) ^ 2));

            for (i = 0; i < textToEncrypt.Length; i++)
            {
                if (r < 1)
                { r = encryptKey; }
                c = inSb[i];
                c = EcrAlgorithm(c, r);
                outSb.Append(c);
                r--;
            }
            return outSb.ToString();
        }

        public string Decrypt(string textToDecrypt, int DecryptKey)
        {
            StringBuilder inSb = new StringBuilder(textToDecrypt);
            StringBuilder outSb = new StringBuilder(textToDecrypt.Length);
            char c;
            int i, r = DecryptKey;
            int pTeks = textToDecrypt.Length;
            int Kunci = pTeks * (2 + ((8 * DecryptKey) ^ 2));

            for (i = 0; i < textToDecrypt.Length; i++)
            {
                if (r < 1)
                { r = DecryptKey; }
                c = inSb[i];
                c = DecrAlgorithm(c, r);
                outSb.Append(c);
                r--;
            }
            return outSb.ToString();
        }
    }
}
