namespace HW_2_MiddleWare
{
    public class OneHundredToThousandMiddleWare
    {
        private readonly RequestDelegate _next;

        public OneHundredToThousandMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Query["number"];
            try
            {
                int number = Convert.ToInt32(token);
                number = Math.Abs(number);
                if (number <100)
                {
                    await _next.Invoke(context);
                }
                else
                {
                    string[] hundred = { "One hundred","Two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };
                    if (number%100 == 0) {
                       
                        await context.Response.WriteAsync("Your number is " + hundred[number / 100 - 1]);
                    }
                    else
                    {
                        await _next.Invoke(context); 
                        string? result = string.Empty;
                        result = context.Session.GetString("number"); 
                        // Выдаем окончательный ответ клиенту
                        await context.Response.WriteAsync("Your number is " + hundred[number / 100 - 1] + " " + result);
                    }

                }
            }
            catch (Exception)
            {
                await context.Response.WriteAsync("100-900 Incorrect parameter ");
            }
        }
    }
}
