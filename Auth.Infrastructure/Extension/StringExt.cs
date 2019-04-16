using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Auth.Infrastructure.Tools.Encrypt;

namespace Auth.Infrastructure.Extension
{
    public static class StringExt
    {
        /// <summary>
        /// 如果没有以c结尾，则添加c在尾部
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string EnsureEndsWith(this string str, char c)
        {
            return EnsureEndsWith(str, c, StringComparison.Ordinal);
        }

        /// <summary>
        /// 如果没有以c结尾，则添加c在尾部
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.EndsWith(c.ToString(), comparisonType))
            {
                return str;
            }
            return str + c.ToString();
        }

        /// <summary>
        /// 如果没有以c结尾，则添加c在尾部
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.EndsWith(c.ToString(culture), ignoreCase, culture))
            {
                return str;
            }
            return str + c.ToString();
        }

        /// <summary>
        /// 如果没有以c开始，则添加c在头部
        /// </summary>
        public static string EnsureStartsWith(this string str, char c)
        {
            return EnsureStartsWith(str, c, StringComparison.Ordinal);
        }

        /// <summary>
        /// 如果没有以c开始，则添加c在头部
        /// </summary>
        public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.StartsWith(c.ToString(), comparisonType))
            {
                return str;
            }
            return c.ToString() + str;
        }

        /// <summary>
        /// 如果没有以c开始，则添加c在头部
        /// </summary>
        public static string EnsureStartsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.StartsWith(c.ToString(culture), ignoreCase, culture))
            {
                return str;
            }
            return c.ToString() + str;
        }

        /// <summary>
        /// 是否为Null或空字符串
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 是否为Null或空白字符串
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="str" /> is null</exception>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="len" /> is bigger that string's length</exception>
        public static string Left(this string str, int len)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.Length < len)
            {
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            }
            return str.Substring(0, len);
        }

        /// <summary>
        /// Converts line endings in the string to <see cref="P:System.Environment.NewLine" />.
        /// </summary>
        public static string NormalizeLineEndings(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
        }

        /// <summary>
        /// Gets index of nth occurence of a char in a string.
        /// </summary>
        /// <param name="str">source string to be searched</param>
        /// <param name="c">Char to search in <see cref="!:str" /></param>
        /// <param name="n">Count of the occurence</param>
        public static int NthIndexOf(this string str, char c, int n)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c && ++count == n)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Removes first occurrence of the given postfixes from end of the given string.
        /// Ordering is important. If one of the postFixes is matched, others will not be tested.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="postFixes">one or more postfix.</param>
        /// <returns>Modified string or the same string if it has not any of given postfixes</returns>
        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            if (str == null)
            {
                return null;
            }
            if (str == string.Empty)
            {
                return string.Empty;
            }
            if (postFixes.IsNullOrEmpty())
            {
                return str;
            }
            foreach (string postFix in postFixes)
            {
                if (str.EndsWith(postFix))
                {
                    return Left(str, str.Length - postFix.Length);
                }
            }
            return str;
        }

        /// <summary>
        /// Removes first occurrence of the given prefixes from beginning of the given string.
        /// Ordering is important. If one of the preFixes is matched, others will not be tested.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="preFixes">one or more prefix.</param>
        /// <returns>Modified string or the same string if it has not any of given prefixes</returns>
        public static string RemovePreFix(this string str, params string[] preFixes)
        {
            if (str == null)
            {
                return null;
            }
            if (str == string.Empty)
            {
                return string.Empty;
            }
            if (preFixes.IsNullOrEmpty())
            {
                return str;
            }
            foreach (string preFix in preFixes)
            {
                if (str.StartsWith(preFix))
                {
                    return Right(str, str.Length - preFix.Length);
                }
            }
            return str;
        }

        /// <summary>
        /// Gets a substring of a string from end of the string.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="str" /> is null</exception>
        /// <exception cref="T:System.ArgumentException">Thrown if <paramref name="len" /> is bigger that string's length</exception>
        public static string Right(this string str, int len)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            if (str.Length < len)
            {
                throw new ArgumentException("len argument can not be bigger than given string's length!");
            }
            return str.Substring(str.Length - len, len);
        }

        /// <summary>
        /// Uses string.Split method to split given string by given separator.
        /// </summary>
        public static string[] Split(this string str, string separator)
        {
            return str.Split(new string[1]
            {
            separator
            }, StringSplitOptions.None);
        }

        /// <summary>
        /// Uses string.Split method to split given string by given separator.
        /// </summary>
        public static string[] Split(this string str, string separator, StringSplitOptions options)
        {
            return str.Split(new string[1]
            {
            separator
            }, options);
        }

        /// <summary>
        /// Uses string.Split method to split given string by <see cref="P:System.Environment.NewLine" />.
        /// </summary>
        public static string[] SplitToLines(this string str)
        {
            return Split(str, Environment.NewLine);
        }

        /// <summary>
        /// Uses string.Split method to split given string by <see cref="P:System.Environment.NewLine" />.
        /// </summary>
        public static string[] SplitToLines(this string str, StringSplitOptions options)
        {
            return Split(str, Environment.NewLine, options);
        }

        /// <summary>
        ///将PascalCase字符串转换为camelCase字符串。
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="invariantCulture">Invariant culture</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str, bool invariantCulture = true)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            if (str.Length == 1)
            {
                if (!invariantCulture)
                {
                    return str.ToLower();
                }
                return str.ToLowerInvariant();
            }
            return (invariantCulture ? char.ToLowerInvariant(str[0]) : char.ToLower(str[0])).ToString() + str.Substring(1);
        }

        /// <summary>
        /// Converts PascalCase string to camelCase string in specified culture.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="culture">An object that supplies culture-specific casing rules</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            if (str.Length == 1)
            {
                return str.ToLower(culture);
            }
            return char.ToLower(str[0], culture).ToString() + str.Substring(1);
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to sentence (by splitting words by space).
        /// Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <param name="invariantCulture">Invariant culture</param>
        public static string ToSentenceCase(this string str, bool invariantCulture = false)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            return Regex.Replace(str, "[a-z][A-Z]", delegate (Match m)
            {
                char c = m.Value[0];
                string str2 = c.ToString();
                c = (invariantCulture ? char.ToLowerInvariant(m.Value[1]) : char.ToLower(m.Value[1]));
                return str2 + " " + c.ToString();
            });
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to sentence (by splitting words by space).
        /// Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        public static string ToSentenceCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            return Regex.Replace(str, "[a-z][A-Z]", delegate (Match m)
            {
                char c = m.Value[0];
                string str2 = c.ToString();
                c = char.ToLower(m.Value[1], culture);
                return str2 + " " + c.ToString();
            });
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="ignoreCase">Ignore case</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value, bool ignoreCase) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMd5(this string str)
        {
            return MD5.Encrypt(str);
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="invariantCulture">Invariant culture</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str, bool invariantCulture = true)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            if (str.Length == 1)
            {
                if (!invariantCulture)
                {
                    return str.ToUpper();
                }
                return str.ToUpperInvariant();
            }
            return (invariantCulture ? char.ToUpperInvariant(str[0]) : char.ToUpper(str[0])).ToString() + str.Substring(1);
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string in specified culture.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="culture">An object that supplies culture-specific casing rules</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            if (str.Length == 1)
            {
                return str.ToUpper(culture);
            }
            return char.ToUpper(str[0], culture).ToString() + str.Substring(1);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="str" /> is null</exception>
        public static string Truncate(this string str, int maxLength)
        {
            if (str == null)
            {
                return null;
            }
            if (str.Length <= maxLength)
            {
                return str;
            }
            return Left(str, maxLength);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds a "..." postfix to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="str" /> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength)
        {
            return TruncateWithPostfix(str, maxLength, "...");
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds given <paramref name="postfix" /> to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="str" /> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength, string postfix)
        {
            if (str == null)
            {
                return null;
            }
            if (str == string.Empty || maxLength == 0)
            {
                return string.Empty;
            }
            if (str.Length <= maxLength)
            {
                return str;
            }
            if (maxLength <= postfix.Length)
            {
                return Left(postfix, maxLength);
            }
            return Left(str, maxLength - postfix.Length) + postfix;
        }
    }
}