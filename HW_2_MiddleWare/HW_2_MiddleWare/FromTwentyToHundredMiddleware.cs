namespace HW_2_MiddleWare
{
    public class FromTwentyToHundredMiddleware
    {
        private readonly RequestDelegate _next;

        public FromTwentyToHundredMiddleware(RequestDelegate next)
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

                string[] Tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                if (number>19&&number<91&&number%10==0)
                {
                    await context.Response.WriteAsync("Your number is " + Tens[number / 10 - 2]);


                }
                else if (number > 100 && number % 10 == 0)
                {
                    context.Session.SetString("number", Tens[(number % 100 / 10) - 2]);

                }
                else
                {

                    await _next.Invoke(context);
                }
                if(number>20&&number<100)
                {
                        await _next.Invoke(context); // Контекст запроса передаем следующему компоненту
                        string? result = string.Empty;
                         result = context.Session.GetString("number"); // получим число от компонента FromOneToTenMiddleware
                         await context.Response.WriteAsync("Your number is " + Tens[number / 10 - 2] + " " + result);

                }
      
            }
            catch (Exception)
            {
                
                await context.Response.WriteAsync("Incorrect parameter 20-90");
            }
        }
    }
}
