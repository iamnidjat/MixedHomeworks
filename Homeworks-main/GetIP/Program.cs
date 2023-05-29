using System.Net;
using System.Text.RegularExpressions;

var url = @"https://2ip.ru";
Console.WriteLine(await GetIP.GetExternalIP(url));

public class GetIP
{
    public async static Task<string> GetExternalIP(string api)
    {
        HttpClient httpClient = new ();
        HttpRequestMessage requestMessage = new (HttpMethod.Get, api);

        requestMessage.Headers.Add("User-Agent", "User-Agent-Here");
        HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

        //? - Соответствует нулю или одному экземпляру предшествующего шаблона; предшествующий шаблон является необязательным
        //+ - Соответствует одному или более экземплярам предшествующего шаблона
        //* - Соответствует нулю или более экземплярам предшествующего шаблона
        //[0-9] - только цифры
        //. - Любой символ, кроме перевода строки или другого разделителя Unicode-строки
        //(...) - Группировка. Группирует элементы в единое целое, которое может использоваться с символами *, +, ?, | и т.п. Также запоминает символы, соответствующие этой группе для использования в последующих ссылках.

        Match _match = Regex.Match(response.ToString(), "=([0-9]+.*?);");

        return $"Текущий IP: {_match.ToString().Substring(1)}";
    }
}

