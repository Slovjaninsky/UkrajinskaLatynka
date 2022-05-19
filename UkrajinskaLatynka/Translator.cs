using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UkrajinskaLatynka
{
    class Translator
    {
        private static char[] vowels = { 'а', 'е', 'и', 'і', 'є', 'о', 'ю', 'я', 'А', 'Е', 'И', 'І', 'Є', 'О', 'Ю', 'Я', 'у', 'У', 'ї', 'Ї' };
        private static char[] consonants = { 'б', 'в', 'г', 'ґ', 'д', 'ж', 'з', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'Б', 'В', 'Г', 'Ґ', 'Д', 'Ж', 'З', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Й', 'й', 'ь', 'Ь' };
        private static string startMsg = "Привіт! Я можу перекласти твій текст на латинську абетку для української мови. Це не є офіційна абетка, а лише любительська! Бот заснований на варіанті алфавіту Юрія Повали, з ним ви детальніше можете ознайомитися тут http://latynka.tak.today/works/projekt-jurija-povali/. Є інші варіанти, але я вирішив обрати найновший та, на мою думку, найбільш пасуючий до нашої мови. Хочу зауважити, що в цьому боті будуть виконуватися не всі правила, представлені Юрієм Повалою. Так, я відкинув вживання ú , бо немає чітких правил її використання, літера ŭ позначає як губний Л, так і нескладовий В, позичені слова будуть повністю транслітуватися, бо немає відповідної бібліотеки в Інтернеті. Якщо Ви зауважили помилку, зв'яжіться з автором: /report *Повідомлення*. Для всіх повсякденних справ, якщо Вам зненацька знадобилася така штука, вистачить. \nKoristujteśa z zadovolenňam!😊\n/help - список команд.";
        private static string helpMsg = "/start - вивести початкове повідомлення; \n/help - вивести список команд; \n/report *повідомлення* - повідомити про помилку";

        public static string Reply(string text)
        {
            if (Regex.IsMatch(text, "^/start.*")) return startMsg;
            else if (Regex.IsMatch(text, "^/help.*")) return helpMsg;
            else if (Regex.IsMatch(text, "^/report.*")) return text;
            return Convert(text);
        }

        private static string Convert(string text)
        {
            StringBuilder ans = new StringBuilder(text.Length * 2);
            text += "  ";
            bool checkV = false;
            for (int iterator = 0; iterator < text.Length - 2; iterator++)
            {
                char currentChar = text[iterator];
                char followingChar = text[iterator + 1];
                char afterFollowingChar = text[iterator + 2];
                #region checkV
                if (iterator == 0)
                {
                    if (currentChar == 'в' && consonants.Contains(followingChar))
                    {
                        checkV = true;
                    }
                    else if (currentChar == 'В' && consonants.Contains(followingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'в' && consonants.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'В' && consonants.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'в' && !consonants.Contains(afterFollowingChar) && !vowels.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'В' && !consonants.Contains(afterFollowingChar) && !vowels.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                }
                else
                {
                    if (vowels.Contains(currentChar) && followingChar == 'в' && consonants.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'в' && !consonants.Contains(afterFollowingChar) && !vowels.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (!consonants.Contains(currentChar) && !vowels.Contains(currentChar) && followingChar == 'в' && consonants.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (!consonants.Contains(currentChar) && !vowels.Contains(currentChar) && followingChar == 'в' && !consonants.Contains(afterFollowingChar) && !vowels.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'В' && consonants.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (vowels.Contains(currentChar) && followingChar == 'В' && !consonants.Contains(afterFollowingChar) && !vowels.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (!consonants.Contains(currentChar) && !vowels.Contains(currentChar) && followingChar == 'В' && consonants.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                    else if (!consonants.Contains(currentChar) && !vowels.Contains(currentChar) && followingChar == 'В' && !consonants.Contains(afterFollowingChar) && !vowels.Contains(afterFollowingChar))
                    {
                        checkV = true;
                    }
                }
                #endregion
                switch (currentChar)
                {

                    #region A
                    case 'а':
                        currentChar = 'a'; ans.Append(currentChar); break;
                    #endregion
                    #region B
                    case 'б':
                        if (followingChar == 'я')
                        {
                            ans.Append("bia");
                            iterator++;
                        }
                        else if (followingChar == 'ю')
                        {
                            ans.Append("biu");
                            iterator++;
                        }
                        else if (followingChar == 'є')
                        {
                            ans.Append("bie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'b';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region V
                    case 'в':
                        if (followingChar == 'я')
                        {
                            ans.Append("via");
                            iterator++;
                        }
                        else if (followingChar == 'ю')
                        {
                            ans.Append("viu");
                            iterator++;
                        }
                        else if (followingChar == 'є')
                        {
                            ans.Append("vie");
                            iterator++;
                        }
                        else
                        {
                            if (checkV)
                            {
                                currentChar = 'ŭ';
                                checkV = false;
                            }
                            else
                            {
                                currentChar = 'v';
                            }
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region H
                    case 'г':
                        if (followingChar == 'я')
                        {
                            ans.Append("hia");
                            iterator++;
                        }
                        else if (followingChar == 'ю')
                        {
                            ans.Append("hiu");
                            iterator++;
                        }
                        else if (followingChar == 'є')
                        {
                            ans.Append("hie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'h';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region G
                    case 'ґ':
                        if (followingChar == 'я')
                        {
                            ans.Append("gia");
                            iterator++;
                        }
                        else if (followingChar == 'ю')
                        {
                            ans.Append("giu");
                            iterator++;
                        }
                        else if (followingChar == 'є')
                        {
                            ans.Append("gie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'g';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region D
                    case 'д':
                        if (followingChar == 'я')
                        {
                            ans.Append("ďa");
                            iterator++;
                        }
                        else if (followingChar == 'ю')
                        {
                            ans.Append("ďu");
                            iterator++;
                        }
                        else if (followingChar == 'є')
                        {
                            ans.Append("ďe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ď");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'd';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region E
                    case 'е':
                        currentChar = 'e'; ans.Append(currentChar); break;
                    #endregion
                    #region Je
                    case 'є':
                        ans.Append("je"); break;
                    #endregion
                    #region ż
                    case 'ж':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("žia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("žiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("žie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'ž';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region Z
                    case 'з':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("źa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("źu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("źe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ź");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'z';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region I
                    case 'и':
                        currentChar = 'i';
                        ans.Append(currentChar); break;
                    #endregion
                    #region í
                    case 'і':
                        currentChar = 'í';
                        ans.Append(currentChar); break;
                    #endregion
                    #region Ji
                    case 'ї':
                        ans.Append("jí");
                        break;
                    #endregion
                    #region J
                    case 'й':
                        currentChar = 'j'; ans.Append(currentChar); break;
                    #endregion
                    #region K
                    case 'к':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("kia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("kiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("kie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'k';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region L
                    case 'л':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("ľa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("ľu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("ľe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ľ");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'l';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region M
                    case 'м':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("mia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("miu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("mie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'm';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region N
                    case 'н':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("ňa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("ňu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("ňe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ň");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'n';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region O
                    case 'о':
                        currentChar = 'o'; ans.Append(currentChar); break;
                    #endregion
                    #region P
                    case 'п':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("pia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("piu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("pie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'p';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region R
                    case 'р':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("řa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("řu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("ře");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ř");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'r';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region S
                    case 'с':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("śa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("śu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("śe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ś");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 's';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region T
                    case 'т':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("ťa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("ťu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("ťe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ť");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 't';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region U
                    case 'у':
                        currentChar = 'u'; ans.Append(currentChar); break;
                    #endregion
                    #region F
                    case 'ф':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("fia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("fiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("fie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'f';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region Ch
                    case 'х':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("chia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("chiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("chie");
                            iterator++;
                        }
                        else
                        {
                            ans.Append("ch");
                        }; break;
                    #endregion
                    #region C
                    case 'ц':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("ća");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("ću");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("će");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("ć");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'c';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region č
                    case 'ч':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("čia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("čiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("čie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'č';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region š
                    case 'ш':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("šia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("šiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("šie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'š';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region šč
                    case 'щ':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("ščia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("ščiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("ščie");
                            iterator++;
                        }
                        else
                        {
                            ans.Append("šč");
                        }; break;
                    #endregion
                    #region ju
                    case 'ю':
                        ans.Append("ju"); break;
                    #endregion
                    #region ja
                    case 'я':
                        ans.Append("ja"); break;
                    #endregion
                    #region softSign and apostrophe
                    case 'ь':
                        break;
                    case (char)39:
                        break;
                    case 'Ь':
                        break;
                    #endregion
                    #region A
                    case 'А':
                        currentChar = 'A'; ans.Append(currentChar); break;
                    #endregion
                    #region B
                    case 'Б':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Bia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Biu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Bie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'B';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region V
                    case 'В':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Via");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Viu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Vie");
                            iterator++;
                        }
                        else
                        {
                            if (checkV)
                            {
                                currentChar = 'Ŭ';
                                checkV = false;
                            }
                            else
                            {
                                currentChar = 'V';
                            }
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region H
                    case 'Г':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Hia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Hiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Hie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'H';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region G
                    case 'Ґ':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Gia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Giu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Gie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'G';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region D
                    case 'Д':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Ďa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Ďu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Ďe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ď");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'D';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region E
                    case 'Е':
                        currentChar = 'E'; ans.Append(currentChar); break;
                    #endregion
                    #region Je
                    case 'Є':
                        ans.Append("Je"); break;
                    #endregion
                    #region ż
                    case 'Ж':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Žia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Žiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Žie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'Ž';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region Z
                    case 'З':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Źa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Źu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Źe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ź");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'Z';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region I
                    case 'И':
                        currentChar = 'I';
                        ans.Append(currentChar); break;
                    #endregion
                    #region í
                    case 'І':
                        currentChar = 'Í';
                        ans.Append(currentChar); break;
                    #endregion
                    #region Ji
                    case 'Ї':
                        ans.Append("Jí");
                        break;
                    #endregion
                    #region J
                    case 'Й':
                        currentChar = 'J'; ans.Append(currentChar); break;
                    #endregion
                    #region K
                    case 'К':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Kia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Kiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Kie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'K';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region L
                    case 'Л':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Ľa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Ľu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Ľe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ľ");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'L';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region M
                    case 'М':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Mia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Miu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Mie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'M';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region N
                    case 'Н':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Ňa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Ňu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Ňe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ň");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'N';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region O
                    case 'О':
                        currentChar = 'O'; ans.Append(currentChar); break;
                    #endregion
                    #region P
                    case 'П':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Pia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Piu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Pie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'P';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region R
                    case 'Р':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Řa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Řu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Ře");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ř");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'R';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region S
                    case 'С':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Śa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Śu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Śe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ś");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'S';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region T
                    case 'Т':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Ťa");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Ťu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Ťe");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ť");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'T';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region U
                    case 'У':
                        currentChar = 'U'; ans.Append(currentChar); break;
                    #endregion
                    #region F
                    case 'Ф':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Fia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Fiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Fie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'F';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region Ch
                    case 'Х':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Chia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Chiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Chie");
                            iterator++;
                        }
                        else
                        {
                            ans.Append("Ch");
                        }; break;
                    #endregion
                    #region C
                    case 'Ц':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Ća");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Ću");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Će");
                            iterator++;
                        }
                        else if (followingChar == 'ь' || followingChar == 'Ь')
                        {
                            ans.Append("Ć");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'C';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region č
                    case 'Ч':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Čia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Čiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Čie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'Č';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region š
                    case 'Ш':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Šia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Šiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Šie");
                            iterator++;
                        }
                        else
                        {
                            currentChar = 'Š';
                            ans.Append(currentChar);
                        }; break;
                    #endregion
                    #region šč
                    case 'Щ':
                        if (followingChar == 'я' || followingChar == 'Я')
                        {
                            ans.Append("Ščia");
                            iterator++;
                        }
                        else if (followingChar == 'ю' || followingChar == 'Ю')
                        {
                            ans.Append("Ščiu");
                            iterator++;
                        }
                        else if (followingChar == 'є' || followingChar == 'Є')
                        {
                            ans.Append("Ščie");
                            iterator++;
                        }
                        else
                        {
                            ans.Append("Šč");
                        }; break;
                    #endregion
                    #region ju
                    case 'Ю':
                        ans.Append("Ju"); break;
                    #endregion
                    #region ja
                    case 'Я':
                        ans.Append("Ja"); break;
                    #endregion
                    #region default
                    default:
                        ans.Append(currentChar);
                        break;
                    #endregion
                }
            }
            removeApostrophe(ans);
            return ans.ToString();
        }
        private static void removeApostrophe(StringBuilder text)
        {
            List<char> charsToRemove = new List<char>() { (char)39, '`', '´', '’', '‘', 'ʻ', 'ʽ', 'ʹ', '΄', '՚', '‛', '′' };
            foreach (char c in charsToRemove)
            {
                text.Replace(c.ToString(), String.Empty);
            }
        }
    }
}